// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

global using Enumerated = uint;

using Baclib.Bacnet.Types;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Asn1;


/// <summary>
/// Provides methods for reading BACnet ASDU (Application Service Data Unit) encoded data from a byte buffer.
/// </summary>
/// <remarks>
/// This class implements deserialization according to ANSI/ASHRAE 135-2024 Clause 20.2 (ASN.1 Encoding Rules).
/// It supports all BACnet primitive types, constructed types, and context-specific encoding.
/// The reader maintains an internal position index that advances as data is read.
/// </remarks>
public ref struct AsduDecoder(ReadOnlySpan<byte> asdu)
{
    private readonly ReadOnlySpan<byte> _asdu = asdu;

    private int _index;

    public readonly bool End => _index >= _asdu.Length;

    #region Decode tag only

    public int DecodeTag(AsduTagClass tagClass, byte tagNumber)
    {
        if (End)
        {
            throw new AsduException();
        }

        var tagLength = AsduTag.PeekTag(_asdu[_index..], tagNumber, tagClass, out int dataLength);
        if (tagLength <= 0)
        {
            throw new AsduException();
        }

        _index += tagLength;
        return dataLength;
    }

    public int DecodeTag(ApplicationTagNumber tagNumber) => DecodeTag(AsduTagClass.Application, (byte)tagNumber);

    public int DecodeTag(byte tagNumber) => DecodeTag(AsduTagClass.Context, tagNumber);

    #endregion

    #region Decode optional tag only

    public bool DecodeTagOptional(AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        if (End)
        {
            dataLength = 0;
            return false;
        }

        var tagLength = AsduTag.PeekTag(_asdu[_index..], tagNumber, tagClass, out dataLength);
        if (tagLength <= 0)
        {
            return false;
        }

        _index += tagLength;
        return true;
    }

    public bool DecodeOptionalTag(ApplicationTagNumber tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Application, (byte)tagNumber, out dataLength);

    public bool DecodeOptionalTag(byte tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Context, tagNumber, out dataLength);

    #endregion

    #region Decode opening/closing tags

    public void DecodeOpeningTag(byte tagNumber)
    {
        if (End)
        {
            throw new AsduException();
        }

        var tagLength = AsduTag.PeekTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
        if (tagLength <= 0)
        {
            throw new AsduException();
        }

        _index += tagLength;
    }

    public bool DecodeOpeningTagOptional(byte tagNumber)
    {
        if (End)
        {
            return false;
        }

        var tagLength = AsduTag.PeekTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
        if (tagLength <= 0)
        {
            return false;
        }

        _index += tagLength;
        return true;
    }

    public bool DecodeClosingTag(byte tagNumber)
    {
        if (_index >= _asdu.Length)
        {
            throw new AsduException();
        }
        var tagLength = AsduTag.PeekTag(_asdu[_index..], tagNumber, AsduTagType.Closing);
        if (tagLength > 0)
        {
            _index += tagLength;
            return true;
        }
        throw new AsduException();
    }

    #endregion

    #region Decode

    public ReadOnlySpan<byte> Decode(AsduTagClass tagClass, byte tagNumber)
    {
        var dataLength = DecodeTag(tagClass, tagNumber);
        var bytes = _asdu.Slice(_index, dataLength);
        _index += bytes.Length;
        return bytes;
    }

    public ReadOnlySpan<byte> Decode(ApplicationTagNumber tagNumber) => Decode(AsduTagClass.Application, (byte)tagNumber);

    public ReadOnlySpan<byte> Decode(byte tagNumber) => Decode(AsduTagClass.Context, tagNumber);

    #endregion

    #region Decode optional

    public bool DecodeOptional(AsduTagClass tagClass, byte tagNumber, out ReadOnlySpan<byte> bytes)
    {
        if (!DecodeTagOptional(tagClass, tagNumber, out int dataLength))
        {
            bytes = default;
            return false;
        }

        bytes = _asdu.Slice(_index, dataLength);
        _index += bytes.Length;
        return true;
    }

    public bool DecodeOptional(ApplicationTagNumber tagNumber, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Application, (byte)tagNumber, out bytes);

    public bool DecodeOptional(byte tagNumber, out ReadOnlySpan<byte> bytes) => DecodeOptional(AsduTagClass.Context, tagNumber, out bytes);

    #endregion

    #region Decode with fixed length

    public ReadOnlySpan<byte> Decode(AsduTagClass tagClass, byte tagNumber, int fixedDataLength)
    {
        var dataLength = DecodeTag(tagClass, tagNumber);
        if (dataLength != fixedDataLength)
        {
            throw new AsduException();
        }

        var bytes = _asdu.Slice(_index, dataLength);
        _index += bytes.Length;
        return bytes;
    }

    public ReadOnlySpan<byte> Decode(ApplicationTagNumber tagNumber, int fixedDataLength) => Decode(AsduTagClass.Application, (byte)tagNumber, fixedDataLength);

    public ReadOnlySpan<byte> Decode(byte tagNumber, int fixedDataLength) => Decode(AsduTagClass.Context, tagNumber, fixedDataLength);

    #endregion

    #region Decode optional with fixed length

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
        _index += bytes.Length;
        return bytes;
    }

    public ReadOnlySpan<byte> DecodeOptional(ApplicationTagNumber tagNumber, int fixedDataLength) => DecodeOptional(AsduTagClass.Application, (byte)tagNumber, fixedDataLength);

    public ReadOnlySpan<byte> DecodeOptional(byte tagNumber, int fixedDataLength) => DecodeOptional(AsduTagClass.Context, tagNumber, fixedDataLength);

    #endregion

    /*
#region Construct

/// <summary>Reads a BACnet construct that implements <see cref="IAsduConstruct{T}"/>.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <returns>The deserialized construct.</returns>
public T Decode<T>() where T : IAsduConstruct<T> => T.Deserialize(this);

/// <summary>Reads a BACnet construct enclosed in opening/closing tags.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <param name="number">The context tag number for the enclosing tags.</param>
/// <returns>The deserialized construct.</returns>
public T Decode<T>(int number) where T : IAsduConstruct<T> => DecodeOptional<T>(number) ?? throw new AsduException();

/// <summary>Tries to read an optional BACnet construct.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <returns>The deserialized construct if present; otherwise, default.</returns>
public T? DecodeOptional<T>() where T : IAsduConstruct<T> => EndOfSeries() ? default : Decode<T>();

/// <summary>Tries to read an optional BACnet construct enclosed in opening/closing tags.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <param name="number">The context tag number for the enclosing tags.</param>
/// <returns>The deserialized construct if tags are present; otherwise, default.</returns>
public T? DecodeOptional<T>(int number) where T : IAsduConstruct<T>
{
if (!DecodeOptionalOpeningTag(number))
{
    return default;
}

var result = T.Deserialize(this);
DecodeClosingTag(number);
return result;
}

#endregion

#region Series

[MethodImpl(MethodImplOptions.AggressiveInlining)]
private bool EndOfSeries() => _index >= _asdu.Length || (_asdu[_index] & 15) == 15;

/// <summary>Reads a series of BACnet constructs until end of buffer or closing tag.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <returns>An immutable array of constructs.</returns>
public ImmutableArray<T> DecodeSeries<T>() where T : IAsduConstruct<T>
{
var items = new List<T>();
while (!EndOfSeries())
{
    var item = Decode<T>();
    items.Add(item);
}
return [.. items];
}

/// <summary>Reads a series of BACnet constructs enclosed in opening/closing tags.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <param name="number">The context tag number for the enclosing tags.</param>
/// <returns>An immutable array of constructs.</returns>
public ImmutableArray<T> DecodeSeries<T>(int number) where T : IAsduConstruct<T> => DecodeOptionalSeries<T>(number) ?? throw new AsduException();

/// <summary>Tries to read an optional series of BACnet constructs.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <returns>An immutable array of constructs if present; otherwise, default.</returns>
public ImmutableArray<T>? DecodeOptionalSeries<T>() where T : IAsduConstruct<T> => EndOfSeries() ? default : DecodeSeries<T>();

/// <summary>Tries to read an optional series of BACnet constructs enclosed in opening/closing tags.</summary>
/// <typeparam name="T">The construct type to read.</typeparam>
/// <param name="number">The context tag number for the enclosing tags.</param>
/// <returns>An immutable array of constructs if tags are present; otherwise, default.</returns>
public ImmutableArray<T>? DecodeOptionalSeries<T>(int number) where T : IAsduConstruct<T>
{
if (!DecodeOptionalOpeningTag(number))
{
    return default;
}

var result = DecodeSeries<T>();
DecodeClosingTag(number);
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
public ImmutableArray<byte> DecodeAny(int openingTagNumber) => DecodeOptionalAny(openingTagNumber) ?? throw new AsduException();

/// <summary>Tries to read optional ASDU data as raw bytes.</summary>
/// <returns>An immutable array of raw ASDU bytes if present; otherwise, null.</returns>
public ImmutableArray<byte>? DecodeOptionalAny()
{
var start = _index;
var length = ForwardIndex(0);
return length > 0 ? ImmutableArray.Create(_asdu, start, length) : null;
}

/// <summary>Tries to read optional ASDU data enclosed in opening/closing tags as raw bytes.</summary>
/// <param name="openingTagNumber">The context tag number for the enclosing tags.</param>
/// <returns>An immutable array of raw ASDU bytes if tags are present; otherwise, null.</returns>
public ImmutableArray<byte>? DecodeOptionalAny(int openingTagNumber)
{
if (!DecodeOptionalOpeningTag(openingTagNumber))
{
    return null;
}
var start = _index;
var length = ForwardIndex(openingTagNumber);
return length > 0 ? ImmutableArray.Create(_asdu, start, length) : null;
}

private int ForwardIndex(int closingTagNumber)
{
var start = _index;
while (!EndOfBuffer)
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

*/

    #region Reading function

    /// <summary>
    /// Reads a BACnet Boolean Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>True if the first byte is non-zero; otherwise, false.</returns>
    public static bool ReadBoolean(ReadOnlySpan<byte> bytes)
    {
        return 0 != bytes[0];
    }

    /// <summary>
    /// Reads an 8-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit unsigned integer.</returns>
    public static byte ReadUnsigned8(ReadOnlySpan<byte> bytes)
    {
        return bytes[0];
    }

    /// <summary>
    /// Reads a 16-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit unsigned integer.</returns>
    public static ushort ReadUnsigned16(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt16BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 24-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes.</param>
    /// <returns>The 24-bit unsigned integer as a 32-bit value.</returns>
    public static uint ReadUnsigned24(ReadOnlySpan<byte> bytes)
    {
        uint byte0 = bytes[0];
        uint byte1 = bytes[1];
        uint byte2 = bytes[2];

        return (byte0 << 16) | (byte1 << 8) | byte2;
    }

    /// <summary>
    /// Reads a 32-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit unsigned integer.</returns>
    public static uint ReadUnsigned32(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt32BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 40-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The 40-bit unsigned integer as a 64-bit value.</returns>
    public static ulong ReadUnsigned40(ReadOnlySpan<byte> bytes)
    {
        ulong byte0 = bytes[0];
        ulong byte1 = bytes[1];
        ulong byte2 = bytes[2];
        ulong byte3 = bytes[3];
        ulong byte4 = bytes[4];

        return (byte0 << 32) | (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
    }

    /// <summary>
    /// Reads a 48-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The 48-bit unsigned integer as a 64-bit value.</returns>
    public static ulong ReadUnsigned48(ReadOnlySpan<byte> bytes)
    {
        ulong byte0 = bytes[0];
        ulong byte1 = bytes[1];
        ulong byte2 = bytes[2];
        ulong byte3 = bytes[3];
        ulong byte4 = bytes[4];
        ulong byte5 = bytes[5];

        return (byte0 << 40) | (byte1 << 32) | (byte2 << 24) | (byte3 << 16) | (byte4 << 8) | byte5;
    }

    /// <summary>
    /// Reads a 56-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The 56-bit unsigned integer as a 64-bit value.</returns>
    public static ulong ReadUnsigned56(ReadOnlySpan<byte> bytes)
    {
        ulong byte0 = bytes[0];
        ulong byte1 = bytes[1];
        ulong byte2 = bytes[2];
        ulong byte3 = bytes[3];
        ulong byte4 = bytes[4];
        ulong byte5 = bytes[5];
        ulong byte6 = bytes[6];

        return (byte0 << 48) | (byte1 << 40) | (byte2 << 32) | (byte3 << 24) | (byte4 << 16) | (byte5 << 8) | byte6;
    }

    /// <summary>
    /// Reads a 64-bit BACnet Unsigned Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit unsigned integer.</returns>
    public static ulong ReadUnsigned64(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt64BigEndian(bytes);
    }





    /// <summary>
    /// Reads a BACnet DatePattern Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes (year, month, day, dayOfWeek).</param>
    /// <returns>A <see cref="DatePattern"/> instance.</returns>
    public static DatePattern ReadDatePattern(ReadOnlySpan<byte> bytes)
    {
        var year = bytes[0];
        var month = bytes[1];
        var day = bytes[2];
        var dayOfWeek = bytes[3];

        return new DatePattern(year, month, day, dayOfWeek);
    }

    /// <summary>
    /// Reads a BACnet TimePattern Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes (hour, minute, second, hundredths).</param>
    /// <returns>A <see cref="TimePattern"/> instance.</returns>
    public static TimePattern ReadTimePattern(ReadOnlySpan<byte> bytes)
    {
        var hour = bytes[0];
        var minute = bytes[1];
        var second = bytes[2];
        var hundredths = bytes[3];

        return new TimePattern(hour, minute, second, hundredths);
    }

    /// <summary>
    /// Reads a BACnet Object Identifier Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>An <see cref="ObjectIdentifier"/> instance.</returns>
    public static ObjectIdentifier ReadObjectIdentifier(ReadOnlySpan<byte> bytes)
    {
        var value = BinaryPrimitives.ReadUInt32BigEndian(bytes);
        return new ObjectIdentifier(value);
    }

    #endregion
}
