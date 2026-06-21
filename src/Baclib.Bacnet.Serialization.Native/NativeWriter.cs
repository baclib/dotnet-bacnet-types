// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: BSD-2-Clause

using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides methods for writing BACnet ASDU (Application Service Data Unit) encoded data to a byte buffer.
/// </summary>
/// <remarks>
/// This class implements serialization according to ANSI/ASHRAE 135-2024 Clause 20.2 (ASN.1 Encoding Rules).
/// It supports all BACnet primitive types, constructed types, and context-specific encoding.
/// The writer maintains an internal position index that advances as data is written.
/// </remarks>
public ref struct NativeWriter
{
    /// <summary>
    /// Backing buffer used for encoded output.
    /// </summary>
    private readonly byte[] _buffer;

    #region State and buffer views

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
    /// Current write offset into <see cref="_buffer"/>.
    /// </summary>
    private int _index = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="NativeWriter"/> class with the specified buffer size.
    /// </summary>
    /// <param name="size">The size of the buffer to allocate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when size is negative.</exception>
    public NativeWriter(int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be non-negative.");
        }
        _buffer = new byte[size];
    }

    /// <summary>
    /// Resets the write position to the beginning so the buffer can be reused.
    /// Existing bytes are not cleared.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() => _index = 0;

    /// <summary>
    /// Copies the encoded bytes into a new array.
    /// </summary>
    public readonly byte[] ToArray() => _buffer.AsSpan(0, _index).ToArray();

    /// <summary>
    /// Copies encoded bytes into a destination span.
    /// </summary>
    /// <returns>
    /// True if destination has enough capacity and copy succeeded; otherwise false.
    /// </returns>
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

    #region Raw writing

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


    #region Tag handling


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

    /// <summary>Writes an opening tag with the specified context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    public void WriteOpeningTag(int number) => WriteEnclosingTag(number, AsduTagKind.Opening);

    /// <summary>Writes a closing tag with the specified context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    public void WriteClosingTag(int number) => WriteEnclosingTag(number, AsduTagKind.Closing);

    #endregion

    #region Construct and series

    /// <summary>
    /// Encodes a value using the provided codec.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode the value.</param>
    /// <param name="value">The value to encode.</param>
    public void Encode<T>(INativeCodec<T> codec, in T value)
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
    public void Encode<T>(INativeCodec<T> codec, byte contextTagNumber, in T value)
    {
        codec.Encode(ref this, contextTagNumber, in value);
    }

    /// <summary>
    /// Encodes a sequence of values using the provided codec.
    /// </summary>
    /// <typeparam name="T">The value type encoded by the codec.</typeparam>
    /// <param name="codec">The codec used to encode each value.</param>
    /// <param name="values">The values to encode.</param>
    public void EncodeSeries<T>(INativeCodec<T> codec, IEnumerable<T> values)
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
    public void EncodeSeries<T>(INativeCodec<T> codec, byte openingTagNumber, IEnumerable<T> values)
    {
        WriteOpeningTag(openingTagNumber);
        EncodeSeries(codec, values);
        WriteClosingTag(openingTagNumber);
    }

    #endregion

    #region Tag and payload encoding


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
    public Span<byte> Encode(ApplicationTagNumber tagNumber, int dataLength) => Encode(AsduTagClass.Application, (byte)tagNumber, dataLength);

    /// <summary>
    /// Writes a context tag header and reserves a payload span.
    /// </summary>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="dataLength">The payload length in bytes.</param>
    /// <returns>A writable span for the payload bytes.</returns>
    public Span<byte> Encode(byte tagNumber, int dataLength) => Encode(AsduTagClass.Context, tagNumber, dataLength);

    #endregion

    #region Writing functions

    /// <summary>
    /// Writes a BACnet Boolean Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The boolean to write.</param>
    public static void WriteBoolean(Span<byte> bytes, bool value)
    {
        bytes[0] = value ? (byte)1 : (byte)0;
    }

    /// <summary>
    /// Writes an 8-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit unsigned integer to write.</param>
    public static void WriteUnsigned8(Span<byte> bytes, byte value)
    {
        bytes[0] = value;
    }

    /// <summary>
    /// Writes a 16-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit unsigned integer to write.</param>
    public static void WriteUnsigned16(Span<byte> bytes, ushort value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteUInt16BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 24-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity.</param>
    /// <param name="value">The 24-bit unsigned integer to write (as a 32-bit value).</param>
    public static void WriteUnsigned24(Span<byte> bytes, uint value)
    {
        bytes[0] = (byte)(value >> 16);
        bytes[1] = (byte)(value >> 8);
        bytes[2] = (byte)value;
    }

    /// <summary>
    /// Writes a 32-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit unsigned integer to write.</param>
    public static void WriteUnsigned32(Span<byte> bytes, uint value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 40-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity.</param>
    /// <param name="value">The 40-bit unsigned integer to write (as a 64-bit value).</param>
    public static void WriteUnsigned40(Span<byte> bytes, ulong value)
    {
        bytes[0] = (byte)(value >> 32);
        bytes[1] = (byte)(value >> 24);
        bytes[2] = (byte)(value >> 16);
        bytes[3] = (byte)(value >> 8);
        bytes[4] = (byte)value;
    }

    /// <summary>
    /// Writes a 48-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity.</param>
    /// <param name="value">The 48-bit unsigned integer to write (as a 64-bit value).</param>
    public static void WriteUnsigned48(Span<byte> bytes, ulong value)
    {
        bytes[0] = (byte)(value >> 40);
        bytes[1] = (byte)(value >> 32);
        bytes[2] = (byte)(value >> 24);
        bytes[3] = (byte)(value >> 16);
        bytes[4] = (byte)(value >> 8);
        bytes[5] = (byte)value;
    }

    /// <summary>
    /// Writes a 56-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity.</param>
    /// <param name="value">The 56-bit unsigned integer to write (as a 64-bit value).</param>
    public static void WriteUnsigned56(Span<byte> bytes, ulong value)
    {
        bytes[0] = (byte)(value >> 48);
        bytes[1] = (byte)(value >> 40);
        bytes[2] = (byte)(value >> 32);
        bytes[3] = (byte)(value >> 24);
        bytes[4] = (byte)(value >> 16);
        bytes[5] = (byte)(value >> 8);
        bytes[6] = (byte)value;
    }

    /// <summary>
    /// Writes a 64-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit unsigned integer to write.</param>
    public static void WriteUnsigned64(Span<byte> bytes, ulong value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteUInt64BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes an 8-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit signed integer to write.</param>
    public static void WriteInteger8(Span<byte> bytes, sbyte value)
    {
        bytes[0] = (byte)value;
    }

    /// <summary>
    /// Writes a 16-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit signed integer to write.</param>
    public static void WriteInteger16(Span<byte> bytes, short value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteInt16BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 24-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity.</param>
    /// <param name="value">The 24-bit signed integer to write (as a 32-bit value).</param>
    public static void WriteInteger24(Span<byte> bytes, int value)
    {
        bytes[0] = (byte)(value >> 16);
        bytes[1] = (byte)(value >> 8);
        bytes[2] = (byte)value;
    }

    /// <summary>
    /// Writes a 32-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit signed integer to write.</param>
    public static void WriteInteger32(Span<byte> bytes, int value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteInt32BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 40-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity.</param>
    /// <param name="value">The 40-bit signed integer to write (as a 64-bit value).</param>
    public static void WriteInteger40(Span<byte> bytes, long value)
    {
        bytes[0] = (byte)(value >> 32);
        bytes[1] = (byte)(value >> 24);
        bytes[2] = (byte)(value >> 16);
        bytes[3] = (byte)(value >> 8);
        bytes[4] = (byte)value;
    }

    /// <summary>
    /// Writes a 48-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity.</param>
    /// <param name="value">The 48-bit signed integer to write (as a 64-bit value).</param>
    public static void WriteInteger48(Span<byte> bytes, long value)
    {
        bytes[0] = (byte)(value >> 40);
        bytes[1] = (byte)(value >> 32);
        bytes[2] = (byte)(value >> 24);
        bytes[3] = (byte)(value >> 16);
        bytes[4] = (byte)(value >> 8);
        bytes[5] = (byte)value;
    }

    /// <summary>
    /// Writes a 56-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity.</param>
    /// <param name="value">The 56-bit signed integer to write (as a 64-bit value).</param>
    public static void WriteInteger56(Span<byte> bytes, long value)
    {
        bytes[0] = (byte)(value >> 48);
        bytes[1] = (byte)(value >> 40);
        bytes[2] = (byte)(value >> 32);
        bytes[3] = (byte)(value >> 24);
        bytes[4] = (byte)(value >> 16);
        bytes[5] = (byte)(value >> 8);
        bytes[6] = (byte)value;
    }

    /// <summary>
    /// Writes a 64-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit signed integer to write.</param>
    public static void WriteInteger64(Span<byte> bytes, long value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteInt64BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 32-bit BACnet Real Number Value (IEEE 754 single-precision floating point).
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit float value to write.</param>
    public static void WriteReal(Span<byte> bytes, float value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteSingleBigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 64-bit BACnet Double Precision Real Number Value (IEEE 754 double-precision floating point).
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit double value to write.</param>
    public static void WriteDouble(Span<byte> bytes, double value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteDoubleBigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a BACnet Octet String Value to the given bytes.
    /// </summary>
    /// <param name="bytes">A span with sufficient capacity to hold the octet string data.</param>
    /// <param name="value">The octet string to write.</param>
    public static void WriteOctetString(Span<byte> bytes, OctetString value)
    {
        value.CopyTo(bytes);
    }

    /// <summary>
    /// Writes a BACnet Character String Value to the given bytes.
    /// </summary>
    /// <param name="bytes">A span with sufficient capacity to hold the character string data.</param>
    /// <param name="value">The character string to write.</param>
    public static void WriteCharacterString(Span<byte> bytes, CharacterString value)
    {
        value.CopyTo(bytes);
    }

    /// <summary>
    /// Writes a BACnet Bit String Value to the given bytes.
    /// </summary>
    /// <param name="bytes">A span with sufficient capacity to hold the bit string data.</param>
    /// <param name="value">The bit string to write.</param>
    /// <remarks>
    /// This method writes the bit string in BACnet format, including the unused bits count as the first byte.
    /// </remarks>
    public static void WriteBitString(Span<byte> bytes, BitString value)
    {
        value.CopyTo(bytes);
    }

    /// <summary>
    /// Writes an 8-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 8-bit flags value to write.</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags8(Span<byte> bytes, byte value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        bytes[1] = BitReverser.Reverse8Bits(value);
    }

    /// <summary>
    /// Writes a 16-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 16-bit flags value to write.</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags16(Span<byte> bytes, ushort value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse16Bits(value);
        System.Buffers.Binary.BinaryPrimitives.WriteUInt16BigEndian(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 24-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 24-bit flags value to write (as a 32-bit unsigned integer).</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags24(Span<byte> bytes, uint value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse32Bits(value);
        WriteUnsigned24(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 32-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 32-bit flags value to write.</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags32(Span<byte> bytes, uint value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse32Bits(value);
        System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 40-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 40-bit flags value to write (as a 64-bit unsigned integer).</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags40(Span<byte> bytes, ulong value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse64Bits(value);
        WriteUnsigned40(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 48-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 48-bit flags value to write (as a 64-bit unsigned integer).</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags48(Span<byte> bytes, ulong value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse64Bits(value);
        WriteUnsigned48(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 56-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 56-bit flags value to write (as a 64-bit unsigned integer).</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags56(Span<byte> bytes, ulong value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse64Bits(value);
        WriteUnsigned56(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes a 64-bit native flags value as a BACnet Bit String Value.
    /// </summary>
    /// <param name="bytes">A span with at least 9 bytes capacity. The first byte will be the unused bits count.</param>
    /// <param name="value">The native 64-bit flags value to write.</param>
    /// <param name="unusedBits">The number of unused bits in the last byte.</param>
    public static void WriteBitStringFromFlags64(Span<byte> bytes, ulong value, byte unusedBits)
    {
        bytes[0] = unusedBits;
        var reversed = BitReverser.Reverse64Bits(value);
        System.Buffers.Binary.BinaryPrimitives.WriteUInt64BigEndian(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes an 8-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit enumerated value to write.</param>
    public static void WriteEnumerated8(Span<byte> bytes, Enumerated8 value) => WriteUnsigned8(bytes, (byte)value);

    /// <summary>
    /// Writes a 16-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit enumerated value to write.</param>
    public static void WriteEnumerated16(Span<byte> bytes, Enumerated16 value) => WriteUnsigned16(bytes, (ushort)value);

    /// <summary>
    /// Writes a 24-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity.</param>
    /// <param name="value">The 24-bit enumerated value to write (as a 32-bit unsigned integer).</param>
    public static void WriteEnumerated24(Span<byte> bytes, Enumerated32 value) => WriteUnsigned24(bytes, (uint)value);

    /// <summary>
    /// Writes a 32-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit enumerated value to write.</param>
    public static void WriteEnumerated32(Span<byte> bytes, Enumerated32 value) => WriteUnsigned32(bytes, (uint)value);

    /// <summary>
    /// Writes a 40-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity.</param>
    /// <param name="value">The 40-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated40(Span<byte> bytes, Enumerated64 value) => WriteUnsigned40(bytes, (ulong)value);

    /// <summary>
    /// Writes a 48-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity.</param>
    /// <param name="value">The 48-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated48(Span<byte> bytes, Enumerated64 value) => WriteUnsigned48(bytes, (ulong)value);

    /// <summary>
    /// Writes a 56-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity.</param>
    /// <param name="value">The 56-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated56(Span<byte> bytes, Enumerated64 value) => WriteUnsigned56(bytes, (ulong)value);

    /// <summary>
    /// Writes a 64-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit enumerated value to write.</param>
    public static void WriteEnumerated64(Span<byte> bytes, Enumerated64 value) => WriteUnsigned64(bytes, (ulong)value);

    /// <summary>
    /// Writes a BACnet Date Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Date Value to write (year, month, day, dayOfWeek).</param>
    public static void WriteDatePattern(Span<byte> bytes, DatePattern value)
    {
        bytes[0] = value.Year;
        bytes[1] = value.Month;
        bytes[2] = value.Day;
        bytes[3] = value.DayOfWeek;
    }

    /// <summary>
    /// Writes a BACnet Time Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Time Value to write (hour, minute, second, hundredths).</param>
    public static void WriteTimePattern(Span<byte> bytes, TimePattern value)
    {
        bytes[0] = value.Hour;
        bytes[1] = value.Minute;
        bytes[2] = value.Second;
        bytes[3] = value.Hundredths;
    }

    /// <summary>
    /// Writes a BACnet Object Identifier Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Object Identifier Value to write.</param>
    public static void WriteObjectIdentifier(Span<byte> bytes, ObjectIdentifier value)
    {
        System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(bytes, value.Value);
    }

    #endregion
}

