// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides methods for decoding and reading BACnet ASDU (Application Service Data Unit) encoded data from a byte buffer.
/// </summary>
/// <remarks>
/// This class implements deserialization according to ANSI/ASHRAE 135-2024 Clause 20.2 (ASN.1 Encoding Rules).
/// It supports all BACnet primitive types, constructed types, and context-specific encoding.
/// The decoder maintains an internal position index that advances as data is read.
/// </remarks>
/// <param name="asdu">The input ASDU bytes to decode.</param>
public ref struct NativeReader(ReadOnlySpan<byte> asdu)
{
    /// <summary>
    /// The full input ASDU span being decoded.
    /// </summary>
    private readonly ReadOnlySpan<byte> _asdu = asdu;

    /// <summary>
    /// Current read offset into <see cref="_asdu"/>.
    /// </summary>
    private int _index;

    /// <summary>
    /// Gets the current read position in bytes from the start of the ASDU.
    /// </summary>
    public readonly int Position => _index;

    /// <summary>
    /// Gets the number of unread bytes remaining in the ASDU.
    /// </summary>
    public readonly int RemainingLength => _asdu.Length - _index;

    /// <summary>
    /// Gets a value indicating whether the decoder has consumed the full input.
    /// </summary>
    public readonly bool End => _index >= _asdu.Length;

    #region Decode required tag

    /// <summary>
    /// Decodes a required application or context tag and advances past the tag header.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <returns>The decoded payload length for the tag.</returns>
    /// <exception cref="AsduException">Thrown when the expected tag is not present.</exception>
    public int DecodeTag(AsduTagClass tagClass, byte tagNumber)
    {
        _index += NativePrimitives.ReadTag(_asdu[_index..], tagClass, tagNumber, out int dataLength);
        return dataLength;
    }

    /// <summary>
    /// Decodes a required application tag and advances past the tag header.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <returns>The decoded payload length for the tag.</returns>
    public int DecodeTag(ApplicationTagNumber tagNumber) => DecodeTag(AsduTagClass.Application, (byte)tagNumber);

    /// <summary>
    /// Decodes a required context tag and advances past the tag header.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded payload length for the tag.</returns>
    public int DecodeTag(byte tagNumber) => DecodeTag(AsduTagClass.Context, tagNumber);

    #endregion

    #region Decode optional tag

    /// <summary>
    /// Tries to decode an optional application or context tag and advances past the tag header when found.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="dataLength">When found, receives the decoded payload length.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeTagOptional(AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        var length = NativePrimitives.PeekTag(_asdu[_index..], tagClass, tagNumber, out dataLength);
        if (length == 0)
        {
            return false;
        }

        _index += length;
        return true;
    }

    /// <summary>
    /// Alias for <see cref="DecodeTagOptional(AsduTagClass, byte, out int)"/>.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="dataLength">When found, receives the decoded payload length.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptionalTag(AsduTagClass tagClass, byte tagNumber, out int dataLength) => DecodeTagOptional(tagClass, tagNumber, out dataLength);

    /// <summary>
    /// Tries to decode an optional application tag and advances past the tag header when found.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="dataLength">When found, receives the decoded payload length.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptionalTag(ApplicationTagNumber tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Application, (byte)tagNumber, out dataLength);

    /// <summary>
    /// Tries to decode an optional context tag and advances past the tag header when found.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="dataLength">When found, receives the decoded payload length.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptionalTag(byte tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Context, tagNumber, out dataLength);

    #endregion

    #region Decode opening/closing tags

    /// <summary>
    /// Decodes a required opening context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <exception cref="AsduException">Thrown when the expected opening tag is not present.</exception>
    public void DecodeOpeningTag(byte tagNumber)
    {
        _index += NativePrimitives.ReadTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
    }

    /// <summary>
    /// Tries to decode an optional opening context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the opening tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOpeningTagOptional(byte tagNumber)
    {
        var length = NativePrimitives.PeekTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
        if (length == 0)
        {
            return false;
        }

        _index += length;
        return true;
    }

    /// <summary>
    /// Alias for <see cref="DecodeOpeningTagOptional(byte)"/>.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the opening tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptionalOpeningTag(byte tagNumber) => DecodeOpeningTagOptional(tagNumber);

    /// <summary>
    /// Decodes a required closing context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <exception cref="AsduException">Thrown when the expected closing tag is not present.</exception>
    public void DecodeClosingTag(byte tagNumber)
    {
        _index += NativePrimitives.ReadTag(_asdu[_index..], tagNumber, AsduTagType.Closing);
    }

    #endregion

    #region Decode

    /// <summary>
    /// Decodes a required application or context tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    public ReadOnlySpan<byte> Decode(AsduTagClass tagClass, byte tagNumber)
    {
        var dataLength = DecodeTag(tagClass, tagNumber);
        var bytes = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return bytes;
    }

    /// <summary>
    /// Decodes a required application tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    public ReadOnlySpan<byte> Decode(ApplicationTagNumber tagNumber) => Decode(AsduTagClass.Application, (byte)tagNumber);

    /// <summary>
    /// Decodes a required context tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    public ReadOnlySpan<byte> Decode(byte tagNumber) => Decode(AsduTagClass.Context, tagNumber);

    #endregion

    #region Decode optional

    /// <summary>
    /// Tries to decode an optional application or context tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptional(AsduTagClass tagClass, byte tagNumber, out ReadOnlySpan<byte> bytes)
    {
        if (!DecodeTagOptional(tagClass, tagNumber, out int dataLength))
        {
            bytes = default;
            return false;
        }

        bytes = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return true;
    }

    /// <summary>
    /// Tries to decode an optional application tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptional(ApplicationTagNumber tagNumber, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Application, (byte)tagNumber, out bytes);

    /// <summary>
    /// Tries to decode an optional context tag and returns its payload bytes.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptional(byte tagNumber, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Context, tagNumber, out bytes);

    #endregion

    #region Decode with fixed length

    /// <summary>
    /// Decodes a required application or context tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    /// <exception cref="AsduException">Thrown when the tag is missing or payload length does not match.</exception>
    public ReadOnlySpan<byte> Decode(AsduTagClass tagClass, byte tagNumber, int fixedDataLength)
    {
        var dataLength = DecodeTag(tagClass, tagNumber);
        if (dataLength != fixedDataLength)
        {
            throw new AsduException();
        }

        var bytes = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return bytes;
    }

    /// <summary>
    /// Decodes a required application tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    public ReadOnlySpan<byte> Decode(ApplicationTagNumber tagNumber, int fixedDataLength) => Decode(AsduTagClass.Application, (byte)tagNumber, fixedDataLength);

    /// <summary>
    /// Decodes a required context tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes.</param>
    /// <returns>A span over the decoded payload bytes.</returns>
    public ReadOnlySpan<byte> Decode(byte tagNumber, int fixedDataLength) => Decode(AsduTagClass.Context, tagNumber, fixedDataLength);

    #endregion

    #region Decode optional with fixed length

    /// <summary>
    /// Tries to decode an optional application or context tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <returns>
    /// A span over the decoded payload bytes when found; otherwise, <see cref="ReadOnlySpan{T}.Empty"/>.
    /// </returns>
    /// <exception cref="AsduException">Thrown when the tag is present but payload length does not match.</exception>
    public ReadOnlySpan<byte> DecodeOptional(AsduTagClass tagClass, byte tagNumber, int fixedDataLength)
    {
        if (!DecodeTagOptional(tagClass, tagNumber, out int dataLength))
        {
            return default;
        }
        if (dataLength != fixedDataLength)
        {
            throw new AsduException();
        }
        var bytes = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return bytes;
    }

    /// <summary>
    /// Tries to decode an optional application or context tag with a fixed payload length.
    /// </summary>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="AsduException">Thrown when the tag is present but payload length does not match.</exception>
    public bool DecodeOptional(AsduTagClass tagClass, byte tagNumber, int fixedDataLength, out ReadOnlySpan<byte> bytes)
    {
        if (!DecodeTagOptional(tagClass, tagNumber, out int dataLength))
        {
            bytes = default;
            return false;
        }

        if (dataLength != fixedDataLength)
        {
            throw new AsduException();
        }

        bytes = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return true;
    }

    /// <summary>
    /// Tries to decode an optional application tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <returns>
    /// A span over the decoded payload bytes when found; otherwise, <see cref="ReadOnlySpan{T}.Empty"/>.
    /// </returns>
    public ReadOnlySpan<byte> DecodeOptional(ApplicationTagNumber tagNumber, int fixedDataLength) => DecodeOptional(AsduTagClass.Application, (byte)tagNumber, fixedDataLength);

    /// <summary>
    /// Tries to decode an optional context tag and validates a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <returns>
    /// A span over the decoded payload bytes when found; otherwise, <see cref="ReadOnlySpan{T}.Empty"/>.
    /// </returns>
    public ReadOnlySpan<byte> DecodeOptional(byte tagNumber, int fixedDataLength) => DecodeOptional(AsduTagClass.Context, tagNumber, fixedDataLength);

    /// <summary>
    /// Tries to decode an optional application tag with a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptional(ApplicationTagNumber tagNumber, int fixedDataLength, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Application, (byte)tagNumber, fixedDataLength, out bytes);

    /// <summary>
    /// Tries to decode an optional context tag with a fixed payload length.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="fixedDataLength">The required payload length in bytes when present.</param>
    /// <param name="bytes">When found, receives a span over the decoded payload bytes.</param>
    /// <returns><see langword="true"/> when the tag is present; otherwise, <see langword="false"/>.</returns>
    public bool DecodeOptional(byte tagNumber, int fixedDataLength, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Context, tagNumber, fixedDataLength, out bytes);

    #endregion

    #region Series

    /// <summary>
    /// Determines whether series decoding should stop at the current position.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> when input ended or the next tag is a closing tag; otherwise, <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly bool EndOfSeries() => End || (_asdu[_index] & 15) == 15;

    /// <summary>Reads a series of BACnet constructs until end of buffer or closing tag.</summary>
    /// <typeparam name="T">The construct type to read.</typeparam>
    /// <param name="decoder">The decoder implementation used for each series item.</param>
    /// <returns>An immutable array of constructs.</returns>
    public ImmutableArray<T> DecodeSeries<T>(INativeCodec<T> decoder)
    {
        var items = new List<T>();
        while (!EndOfSeries())
        {
            var item = decoder.Decode(ref this);
            items.Add(item);
        }
        return [.. items];
    }

    /// <summary>Reads a series of BACnet constructs enclosed in opening/closing tags.</summary>
    /// <typeparam name="T">The construct type to read.</typeparam>
    /// <param name="decoder">The decoder implementation used for each series item.</param>
    /// <param name="tagNumber">The context tag number for the enclosing tags.</param>
    /// <returns>An immutable array of constructs.</returns>
    public ImmutableArray<T> DecodeSeries<T>(INativeCodec<T> decoder, byte tagNumber) => DecodeOptionalSeries(decoder, tagNumber) ?? throw new AsduException();

    /// <summary>Tries to read an optional series of BACnet constructs.</summary>
    /// <typeparam name="T">The construct type to read.</typeparam>
    /// <param name="decoder">The decoder implementation used for each series item.</param>
    /// <returns>An immutable array of constructs if present; otherwise, default.</returns>
    public ImmutableArray<T>? DecodeOptionalSeries<T>(INativeCodec<T> decoder) => EndOfSeries() ? default : DecodeSeries(decoder);

    /// <summary>Tries to read an optional series of BACnet constructs enclosed in opening/closing tags.</summary>
    /// <typeparam name="T">The construct type to read.</typeparam>
    /// <param name="decoder">The decoder implementation used for each series item.</param>
    /// <param name="tagNumber">The context tag number for the enclosing tags.</param>
    /// <returns>An immutable array of constructs if tags are present; otherwise, default.</returns>
    public ImmutableArray<T>? DecodeOptionalSeries<T>(INativeCodec<T> decoder, byte tagNumber)
    {
        if (!DecodeOptionalOpeningTag(tagNumber))
        {
            return default;
        }

        var result = DecodeSeries(decoder);
        DecodeClosingTag(tagNumber);
        return result;
    }

    #endregion

    #region Any

    /// <summary>Reads any ASDU data as raw bytes until the next closing tag or end of buffer.</summary>
    /// <returns>An immutable array of raw ASDU bytes.</returns>
    public ImmutableArray<byte> DecodeAny() => DecodeOptionalAny() ?? throw new AsduException();

    /// <summary>Reads any ASDU data enclosed in opening/closing tags as raw bytes.</summary>
    /// <param name="openingTagNumber">The context tag number for the enclosing tags.</param>
    /// <returns>An immutable array of raw ASDU bytes.</returns>
    public ImmutableArray<byte> DecodeAny(byte openingTagNumber) => DecodeOptionalAny(openingTagNumber) ?? throw new AsduException();

    /// <summary>Tries to read optional ASDU data as raw bytes.</summary>
    /// <returns>An immutable array of raw ASDU bytes if present; otherwise, null.</returns>
    public ImmutableArray<byte>? DecodeOptionalAny()
    {
        var start = _index;
        var length = ForwardIndex(0);
        return length > 0 ? ImmutableArray.CreateRange(_asdu.Slice(start, length).ToArray()) : null;
    }

    /// <summary>Tries to read optional ASDU data enclosed in opening/closing tags as raw bytes.</summary>
    /// <param name="openingTagNumber">The context tag number for the enclosing tags.</param>
    /// <returns>An immutable array of raw ASDU bytes if tags are present; otherwise, null.</returns>
    public ImmutableArray<byte>? DecodeOptionalAny(byte openingTagNumber)
    {
        if (!DecodeOptionalOpeningTag(openingTagNumber))
        {
            return null;
        }
        var start = _index;
        var length = ForwardIndex(openingTagNumber);
        return length > 0 ? ImmutableArray.CreateRange(_asdu.Slice(start, length).ToArray()) : null;
    }

    /// <summary>
    /// Advances the decoder index until the specified closing tag is found or end of input is reached.
    /// </summary>
    /// <param name="closingTagNumber">The closing context tag number that terminates the scan.</param>
    /// <returns>The number of payload bytes traversed.</returns>
    /// <exception cref="ArgumentException">Thrown when an unexpected closing tag is encountered.</exception>
    private int ForwardIndex(int closingTagNumber)
    {
        var start = _index;
        while (!End)
        {
            var control = _asdu[_index++];
            var number = control >> 4;
            if (number == 15)
            {
                number = _asdu[_index++];
            }
            int length = control & 0x07;
            switch (length)
            {
                case < 5:
                {
                    _index += length;
                    break;
                }
                case 5:
                {
                    length = _asdu[_index++];
                    if (length > 253)
                    {
                        length = length == 254 ? _asdu[_index++] << 8 | _asdu[_index++] : _asdu[_index++] << 24 | _asdu[_index++] << 16 | _asdu[_index++] << 8 | _asdu[_index++];
                    }
                    _index += length;
                    break;
                }
                case 6:
                {
                    ForwardIndex(number);
                    break;
                }
                case 7:
                {
                    if (number == closingTagNumber)
                    {
                        return _index - (number < 15 ? 1 : 2) - start;
                    }
                    throw new ArgumentException($"Invalid closing tag number {number}.");
                }
            }
        }
        return _index - start;
    }

    #endregion
}

