// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides methods for writing BACnet ASDU (Application Service Data Unit) encoded data
/// to a byte buffer.
/// </summary>
/// <remarks>
/// This class implements serialization according to ANSI/ASHRAE 135-2024 Clause 20.2
/// (ASN.1 Encoding Rules). It supports primitive and constructed values and context-specific
/// encoding. The writer maintains an internal position index that advances as data is written.
/// </remarks>
public ref struct AsduWriter
{
    /// <summary>
    /// Backing buffer used for encoded output.
    /// </summary>
    private readonly byte[] _buffer;

    /// <summary>
    /// Current write offset into <see cref="_buffer"/>.
    /// </summary>
    private int _index = 0;

    #region Construction

    /// <summary>
    /// Initializes a new instance of the <see cref="AsduWriter"/> class with the specified
    /// buffer size.
    /// </summary>
    /// <param name="size">The size of the buffer to allocate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="size"/> is negative.</exception>
    public AsduWriter(int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be non-negative.");
        }
        _buffer = new byte[size];
    }

    #endregion

    #region State And Buffer Views

    /// <summary>
    /// Gets a copy of the encoded ASDU bytes.
    /// Prefer <see cref="WrittenSpan"/> for zero-copy access in internal hot paths.
    /// </summary>
    public byte[] Buffer => ToArray();

    /// <summary>
    /// Gets the current write position from the start of the buffer.
    /// </summary>
    public readonly int Position => _index;

    /// <summary>
    /// Gets the number of bytes written so far.
    /// </summary>
    public readonly int WrittenLength => _index;

    /// <summary>
    /// Gets the number of remaining writable bytes in the backing buffer.
    /// </summary>
    public readonly int RemainingLength => _buffer.Length - _index;

    /// <summary>
    /// Gets a span over the bytes written so far.
    /// </summary>
    public readonly ReadOnlySpan<byte> WrittenSpan => _buffer.AsSpan(0, _index);

    /// <summary>
    /// Resets the write position to the beginning so the buffer can be reused.
    /// Existing bytes are not cleared.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() => _index = 0;

    /// <summary>
    /// Copies the encoded bytes into a new array.
    /// </summary>
    /// <returns>A newly allocated array containing the bytes written so far.</returns>
    public readonly byte[] ToArray() => _buffer.AsSpan(0, _index).ToArray();

    /// <summary>
    /// Copies encoded bytes into a destination span.
    /// </summary>
    /// <param name="destination">The destination span to receive written bytes.</param>
    /// <returns><see langword="true"/> when destination has enough capacity; otherwise
    /// <see langword="false"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly bool TryCopyTo(Span<byte> destination)
    {
        if (destination.Length < _index)
        {
            return false;
        }

        _buffer.AsSpan(0, _index).CopyTo(destination);
        return true;
    }

    #endregion

    #region Raw Writing

    /// <summary>
    /// Writes a single raw byte and advances the write position.
    /// </summary>
    /// <param name="value">The raw byte to write.</param>
    public void WriteByte(byte value)
    {
        _buffer[_index++] = value;
    }

    /// <summary>
    /// Writes raw bytes directly into the output buffer.
    /// </summary>
    /// <param name="bytes">The bytes to copy.</param>
    public void EncodeAny(ReadOnlySpan<byte> bytes)
    {
        bytes.CopyTo(_buffer.AsSpan(_index));
        _index += bytes.Length;
    }

    /// <summary>
    /// Alias for <see cref="EncodeAny(ReadOnlySpan{byte})"/>.
    /// </summary>
    /// <param name="bytes">The bytes to copy.</param>
    public void WriteAny(ReadOnlySpan<byte> bytes) => EncodeAny(bytes);

    /// <summary>
    /// Writes raw bytes enclosed by opening and closing context tags.
    /// </summary>
    /// <param name="openingTagNumber">The opening/closing context tag number.</param>
    /// <param name="bytes">The bytes to copy inside the enclosing tags.</param>
    public void EncodeAny(byte openingTagNumber, ReadOnlySpan<byte> bytes)
    {
        WriteOpeningTag(openingTagNumber);
        EncodeAny(bytes);
        WriteClosingTag(openingTagNumber);
    }

    /// <summary>
    /// Alias for <see cref="EncodeAny(byte, ReadOnlySpan{byte})"/>.
    /// </summary>
    /// <param name="openingTagNumber">The opening/closing context tag number.</param>
    /// <param name="bytes">The bytes to copy inside the enclosing tags.</param>
    public void WriteAny(byte openingTagNumber, ReadOnlySpan<byte> bytes) => EncodeAny(openingTagNumber, bytes);

    #endregion

    #region Tag Handling

    /// <summary>
    /// Specifies the kind of BACnet ASN.1 enclosing tag used in APDU encoding.
    /// </summary>
    private enum AsduTagKind
    {
        /// <summary>
        /// Opening tag: marks the start of a constructed value.
        /// </summary>
        Opening = 0xE00,

        /// <summary>
        /// Closing tag: marks the end of a constructed value.
        /// </summary>
        Closing = 0xF00
    }

    /// <summary>
    /// Writes an enclosing context tag (opening or closing).
    /// </summary>
    /// <param name="number">The context tag number to encode.</param>
    /// <param name="kind">The enclosing tag kind.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="number"/> is outside 0..254.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void WriteEnclosingTag(int number, AsduTagKind kind)
    {
        if (number < 0 || number > 254)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 0 and 254.");
        }

        var mask = (int)kind >> 8;
        if (number < 15)
        {
            _buffer[_index++] = (byte)(number << 4 | mask);
        }
        else
        {
            mask |= 0xF0;
            _buffer[_index++] = (byte)mask;
            _buffer[_index++] = (byte)number;
        }
    }

    /// <summary>
    /// Writes an opening tag with the specified context tag number.
    /// </summary>
    /// <param name="number">The context tag number.</param>
    public void WriteOpeningTag(int number) => WriteEnclosingTag(number, AsduTagKind.Opening);

    /// <summary>
    /// Writes a closing tag with the specified context tag number.
    /// </summary>
    /// <param name="number">The context tag number.</param>
    public void WriteClosingTag(int number) => WriteEnclosingTag(number, AsduTagKind.Closing);

    #endregion

    #region Construct And Series

    /// <summary>
    /// Encodes a value using the provided codec.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode the value.</param>
    /// <param name="value">The value to encode.</param>
    public void Encode<T>(IAsduElementDynamicCodec<T> codec, in T value)
    {
        codec.Encode(ref this, in value);
    }

    /// <summary>
    /// Encodes a value using the provided codec as a context-tagged value.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode the value.</param>
    /// <param name="contextTagNumber">The context tag number to encode with.</param>
    /// <param name="value">The value to encode.</param>
    /// <remarks>
    /// This overload is currently a no-op because context-aware dynamic codec dispatch
    /// is not yet wired in this writer.
    /// </remarks>
    public void Encode<T>(IAsduElementDynamicCodec<T> codec, byte contextTagNumber, in T value)
    {
        // codec.Encode(ref this, contextTagNumber, in value);
    }

    /// <summary>
    /// Encodes a sequence of values using the provided codec.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode each value.</param>
    /// <param name="values">The values to encode.</param>
    public void EncodeSeries<T>(IAsduElementDynamicCodec<T> codec, IEnumerable<T> values)
    {
        foreach (var value in values)
        {
            codec.Encode(ref this, in value);
        }
    }

    /// <summary>
    /// Encodes a sequence of values enclosed by opening and closing context tags.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode each value.</param>
    /// <param name="openingTagNumber">The opening/closing context tag number.</param>
    /// <param name="values">The values to encode.</param>
    public void EncodeSeries<T>(IAsduElementDynamicCodec<T> codec, byte openingTagNumber, IEnumerable<T> values)
    {
        WriteOpeningTag(openingTagNumber);
        EncodeSeries(codec, values);
        WriteClosingTag(openingTagNumber);
    }

    #endregion

    #region Tag And Payload Encoding

    /// <summary>
    /// Writes an ASN.1 tag header into a destination span.
    /// </summary>
    /// <param name="bytes">The destination span to receive the encoded tag header.</param>
    /// <param name="tagClass">The tag class to encode.</param>
    /// <param name="tagNumber">The tag number to encode.</param>
    /// <param name="dataLength">The payload length encoded in the tag header.</param>
    /// <returns>The number of bytes written for the tag header.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="dataLength"/> is negative.</exception>
    public static int WriteTag(Span<byte> bytes, AsduTagClass tagClass, byte tagNumber, int dataLength)
    {
        if (dataLength < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(dataLength), "Data length must be non-negative.");
        }

        int index;
        ref byte initialOctet = ref bytes[0];
        if (tagNumber < 15)
        {
            index = 1;
            initialOctet = (byte)(tagNumber << 4);
        }
        else
        {
            index = 2;
            initialOctet = 0xF0;
            bytes[1] = tagNumber;
        }
        if (tagClass == AsduTagClass.Context)
        {
            initialOctet |= 0x08;
        }
        if (dataLength < 5)
        {
            initialOctet |= (byte)dataLength;
        }
        else
        {
            initialOctet |= 0x05;
            if (dataLength < 0xFE)
            {
                bytes[index++] = (byte)dataLength;
            }
            else if (dataLength < 0x10000)
            {
                bytes[index++] = 254;
                System.Buffers.Binary.BinaryPrimitives.WriteUInt16BigEndian(bytes.Slice(index, 2), (ushort)dataLength);
                index += 2;
            }
            else
            {
                bytes[index++] = 255;
                System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(bytes.Slice(index, 4), unchecked((uint)dataLength));
                index += 4;
            }
        }
        return index;
    }

    /// <summary>
    /// Writes a tag header and reserves a payload span.
    /// </summary>
    /// <param name="tagClass">The tag class to encode.</param>
    /// <param name="tagNumber">The tag number to encode.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the payload bytes.</returns>
    public Span<byte> Encode(AsduTagClass tagClass, byte tagNumber, int dataLength)
    {
        _index += WriteTag(_buffer.AsSpan(_index), tagClass, tagNumber, dataLength);
        var bytes = _buffer.AsSpan(_index, dataLength);
        _index += dataLength;
        return bytes;
    }

    /// <summary>
    /// Writes an application tag header and reserves a payload span.
    /// </summary>
    /// <param name="tagNumber">The application tag number.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the payload bytes.</returns>
    public Span<byte> Encode(ApplicationTagNumber tagNumber, int dataLength)
        => Encode(AsduTagClass.Application, (byte)tagNumber, dataLength);

    /// <summary>
    /// Writes a context tag header and reserves a payload span.
    /// </summary>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the payload bytes.</returns>
    public Span<byte> Encode(byte tagNumber, int dataLength)
        => Encode(AsduTagClass.Context, tagNumber, dataLength);

    /// <summary>
    /// Alias for <see cref="Encode(ApplicationTagNumber, int)"/>.
    /// Writes an application tag and reserves payload bytes.
    /// </summary>
    /// <param name="tagNumber">The application tag number.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the reserved payload bytes.</returns>
    public Span<byte> WriteTagAndReserve(ApplicationTagNumber tagNumber, int dataLength)
    {
        return Encode(tagNumber, dataLength);
    }

    /// <summary>
    /// Alias for <see cref="Encode(byte, int)"/>.
    /// Writes a context tag and reserves payload bytes.
    /// </summary>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the reserved payload bytes.</returns>
    public Span<byte> WriteTagAndReserve(byte tagNumber, int dataLength)
    {
        return Encode(tagNumber, dataLength);
    }

    #endregion
}
