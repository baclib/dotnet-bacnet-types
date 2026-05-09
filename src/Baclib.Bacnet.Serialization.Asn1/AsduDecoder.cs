// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

global using Enumerated = uint;

using Baclib.Bacnet.Types;
using System.Buffers.Binary;
using System.Formats.Asn1;
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

    #region Decode required tag

    public int DecodeTag(AsduTagClass tagClass, byte tagNumber)
    {
        _index += ReadTag(_asdu[_index..], tagClass, tagNumber, out int dataLength);
        return dataLength;
    }

    public int DecodeTag(ApplicationTagNumber tagNumber) => DecodeTag(AsduTagClass.Application, (byte)tagNumber);

    public int DecodeTag(byte tagNumber) => DecodeTag(AsduTagClass.Context, tagNumber);

    #endregion

    #region Decode optional tag

    public bool DecodeTagOptional(AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        var length = PeekTag(_asdu[_index..], tagClass, tagNumber, out dataLength);
        if (length == 0)
        {
            return false;
        }

        _index += length;
        return true;
    }

    public bool DecodeOptionalTag(ApplicationTagNumber tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Application, (byte)tagNumber, out dataLength);

    public bool DecodeOptionalTag(byte tagNumber, out int dataLength) => DecodeTagOptional(AsduTagClass.Context, tagNumber, out dataLength);

    #endregion

    #region Decode opening/closing tags

    public void DecodeOpeningTag(byte tagNumber)
    {
        _index += ReadTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
    }

    public bool DecodeOpeningTagOptional(byte tagNumber)
    {
        var length = PeekTag(_asdu[_index..], tagNumber, AsduTagType.Opening);
        if (length == 0)
        {
            return false;
        }

        _index += length;
        return true;
    }

    public void DecodeClosingTag(byte tagNumber)
    {
        _index += ReadTag(_asdu[_index..], tagNumber, AsduTagType.Closing);
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

 

    public static int PeekTag(ReadOnlySpan<byte> bytes, AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        if (bytes.Length == 0)
        {
            dataLength = 0;
            return 0;
        }

        var control = bytes[0];
        var number = (byte)(control >> 4);
        var index = 1;

        if (number == 15)
        {
            if (bytes.Length < 2)
            {
                dataLength = 0;
                return 0;
            }
            number = bytes[1];
            index = 2;
        }

        if (number != tagNumber || ((control & 0x08) != 0 ? AsduTagClass.Context : AsduTagClass.Application) != tagClass)
        {
            dataLength = 0;
            return 0;
        }

        int lengthValue = control & 7;
        if (lengthValue < 5)
        {
            dataLength = lengthValue;
            return index;
        }

        if (lengthValue == 5)
        {
            if (bytes.Length <= index)
            {
                dataLength = 0;
                return 0;
            }

            dataLength = bytes[index];
            if (dataLength < 254)
            {
                return index + 1;
            }

            if (dataLength == 254)
            {
                if (bytes.Length < index + 3)
                {
                    dataLength = 0;
                    return 0;
                }
                dataLength = BinaryPrimitives.ReadUInt16BigEndian(bytes.Slice(index + 1, 2));
                return index + 3;
            }

            if (bytes.Length < index + 5)
            {
                dataLength = 0;
                return 0;
            }
            dataLength = BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(index + 1, 4));
            return index + 5;
        }

        dataLength = 0;
        return 0;
    }

    public static int PeekTag(ReadOnlySpan<byte> bytes, ApplicationTagNumber tagNumber, out int dataLength) => PeekTag(bytes, AsduTagClass.Application, (byte)tagNumber, out dataLength);

    public static int PeekTag(ReadOnlySpan<byte> bytes, byte tagNumber, out int dataLength) => PeekTag(bytes, AsduTagClass.Context, tagNumber, out dataLength);

    public static int PeekTag(ReadOnlySpan<byte> bytes, byte tagNumber, AsduTagType tagType)
    {
        if (tagNumber < 15)
        {
            if (bytes.Length == 0)
            {
                return 0;
            }

            byte expected = (byte)((tagNumber << 4) | (tagType == AsduTagType.Opening ? 6 : 7));
            return bytes[0] == expected ? 1 : 0;
        }

        if (bytes.Length < 2)
        {
            return 0;
        }

        byte expectedFirst = (byte)(tagType == AsduTagType.Opening ? 0xFE : 0xFF);
        return (bytes[0] == expectedFirst & bytes[1] == tagNumber) ? 2 : 0;
    }











    public static int ReadTag(ReadOnlySpan<byte> bytes, AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        var tagLength = PeekTag(bytes, tagClass, tagNumber, out dataLength);
        if (tagLength == 0)
        {
            throw new AsduException($"Tag number {tagNumber} with class {tagClass} does not exist.");
        }
        return tagLength;
    }

    public static int ReadTag(ReadOnlySpan<byte> bytes, ApplicationTagNumber tagNumber, out int dataLength) => ReadTag(bytes, AsduTagClass.Application, (byte)tagNumber, out dataLength);

    public static int ReadTag(ReadOnlySpan<byte> bytes, byte tagNumber, out int dataLength) => ReadTag(bytes, AsduTagClass.Context, tagNumber, out dataLength);

    public static int ReadTag(ReadOnlySpan<byte> bytes, byte tagNumber, AsduTagType tagType)
    {
        var tagLength = PeekTag(bytes, tagNumber, tagType);
        if (tagLength == 0)
        {
            throw new AsduException($"Tag number {tagNumber} with type {tagType} does not exist.");
        }
        return tagLength;
    }











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
    /// Reads an 8-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit signed integer.</returns>
    public static sbyte ReadSigned8(ReadOnlySpan<byte> bytes)
    {
        return (sbyte)bytes[0];
    }

    /// <summary>
    /// Reads a 16-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit signed integer.</returns>
    public static short ReadSigned16(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt16BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 24-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes.</param>
    /// <returns>The 24-bit signed integer as a 32-bit value.</returns>
    public static int ReadSigned24(ReadOnlySpan<byte> bytes)
    {
        int byte0 = bytes[0];
        int byte1 = bytes[1];
        int byte2 = bytes[2];

        int value = (byte0 << 16) | (byte1 << 8) | byte2;
        if ((value & 0x800000) != 0)
        {
            value |= unchecked((int)0xFF000000);
        }
        return value;
    }

    /// <summary>
    /// Reads a 32-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit signed integer.</returns>
    public static int ReadSigned32(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt32BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 40-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The 40-bit signed integer as a 64-bit value.</returns>
    public static long ReadSigned40(ReadOnlySpan<byte> bytes)
    {
        long byte0 = bytes[0];
        long byte1 = bytes[1];
        long byte2 = bytes[2];
        long byte3 = bytes[3];
        long byte4 = bytes[4];

        long value = (byte0 << 32) | (byte1 << 24) | (byte2 << 16) | (byte3 << 8) | byte4;
        if ((value & 0x8000000000L) != 0)
        {
            value |= unchecked((long)0xFFFFFF0000000000L);
        }
        return value;
    }

    /// <summary>
    /// Reads a 48-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The 48-bit signed integer as a 64-bit value.</returns>
    public static long ReadSigned48(ReadOnlySpan<byte> bytes)
    {
        long byte0 = bytes[0];
        long byte1 = bytes[1];
        long byte2 = bytes[2];
        long byte3 = bytes[3];
        long byte4 = bytes[4];
        long byte5 = bytes[5];

        long value = (byte0 << 40) | (byte1 << 32) | (byte2 << 24) | (byte3 << 16) | (byte4 << 8) | byte5;
        if ((value & 0x800000000000L) != 0)
        {
            value |= unchecked((long)0xFFFF000000000000L);
        }
        return value;
    }

    /// <summary>
    /// Reads a 56-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The 56-bit signed integer as a 64-bit value.</returns>
    public static long ReadSigned56(ReadOnlySpan<byte> bytes)
    {
        long byte0 = bytes[0];
        long byte1 = bytes[1];
        long byte2 = bytes[2];
        long byte3 = bytes[3];
        long byte4 = bytes[4];
        long byte5 = bytes[5];
        long byte6 = bytes[6];

        long value = (byte0 << 48) | (byte1 << 40) | (byte2 << 32) | (byte3 << 24) | (byte4 << 16) | (byte5 << 8) | byte6;
        if ((value & 0x80000000000000L) != 0)
        {
            value |= unchecked((long)0xFF00000000000000L);
        }
        return value;
    }

    /// <summary>
    /// Reads a 64-bit BACnet Signed Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit signed integer.</returns>
    public static long ReadSigned64(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt64BigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet Real Number Value (IEEE 754 single-precision floating point).
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit float value.</returns>
    public static float ReadReal(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadSingleBigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet Double Precision Real Number Value (IEEE 754 double-precision floating point).
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit double value.</returns>
    public static double ReadDouble(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadDoubleBigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet Octet String Value from the given bytes.
    /// </summary>
    /// <param name="bytes">A span containing zero or more bytes.</param>
    /// <returns>An <see cref="OctetString"/> instance.</returns>
    public static OctetString ReadOctetString(ReadOnlySpan<byte> bytes)
    {
        return new OctetString(bytes);
    }

    /// <summary>
    /// Reads a BACnet Character String Value from the given bytes.
    /// </summary>
    /// <param name="bytes">
    /// A span containing at least 1 byte. The first byte is the character set byte. If the character set
    /// is DBCS (first byte is <c>0x01</c>), the span must be at least 3 bytes long. Bytes two and three
    /// represent an unsigned integer that indicates the DBCS code page.
    /// </param>
    /// <returns>A <see cref="CharacterString"/> instance.</returns>
    public static CharacterString ReadCharacterString(ReadOnlySpan<byte> bytes)
    {
        return new CharacterString(bytes);
    }

    /// <summary>
    /// Reads a BACnet Bit String Value from the given bytes.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes. The first byte is the unused bits count.</param>
    /// <returns>A <see cref="BitString"/> instance.</returns>
    public static BitString ReadBitString(ReadOnlySpan<byte> bytes)
    {
        return new BitString(bytes);
    }

    /// <summary>
    /// Reads an 8-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 8-bit flags value.</returns>
    public static byte ReadBitFlags8(ReadOnlySpan<byte> bytes)
    {
        return BitReverser.Reverse8Bits(bytes[1]);
    }

    /// <summary>
    /// Reads a 16-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 16-bit flags value.</returns>
    public static ushort ReadBitFlags16(ReadOnlySpan<byte> bytes)
    {
        var value = BinaryPrimitives.ReadUInt16BigEndian(bytes[1..]);
        return BitReverser.Reverse16Bits(value);
    }

    /// <summary>
    /// Reads a 24-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 24-bit flags value as a 32-bit unsigned integer.</returns>
    public static uint ReadBitFlags24(ReadOnlySpan<byte> bytes)
    {
        var value = ReadUnsigned24(bytes[1..]);
        return BitReverser.Reverse32Bits(value);
    }

    /// <summary>
    /// Reads a 32-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The native 32-bit flags value.</returns>
    public static uint ReadBitFlags32(ReadOnlySpan<byte> bytes)
    {
        var value = BinaryPrimitives.ReadUInt32BigEndian(bytes[1..]);
        return BitReverser.Reverse32Bits(value);
    }

    /// <summary>
    /// Reads a 40-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The native 40-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags40(ReadOnlySpan<byte> bytes)
    {
        var value = ReadUnsigned40(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
    }

    /// <summary>
    /// Reads a 48-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The native 48-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags48(ReadOnlySpan<byte> bytes)
    {
        var value = ReadUnsigned48(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
    }

    /// <summary>
    /// Reads a 56-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes. The first byte is the unused bits count.</param>
    /// <param name="unusedBits">Outputs the number of unused bits in the last byte.</param>
    /// <returns>The native 56-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags56(ReadOnlySpan<byte> bytes)
    {
        var value = ReadUnsigned56(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
    }

    /// <summary>
    /// Reads a 64-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 9 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 64-bit flags value.</returns>
    public static ulong ReadBitFlags64(ReadOnlySpan<byte> bytes)
    {
        var value = BinaryPrimitives.ReadUInt64BigEndian(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
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










/*

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
