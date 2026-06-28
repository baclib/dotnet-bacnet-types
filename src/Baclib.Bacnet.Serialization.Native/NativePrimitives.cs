// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class NativePrimitives
{
    /// <summary>
    /// Peeks an application or context tag and reads its payload length without advancing decoder state.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the candidate tag.</param>
    /// <param name="tagClass">The expected tag class.</param>
    /// <param name="tagNumber">The expected tag number.</param>
    /// <param name="dataLength">When matched, receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes, or 0 when no match is found.</returns>
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
                dataLength = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(bytes.Slice(index + 1, 2));
                return index + 3;
            }

            if (bytes.Length < index + 5)
            {
                dataLength = 0;
                return 0;
            }
            dataLength = System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes.Slice(index + 1, 4));
            return index + 5;
        }

        dataLength = 0;
        return 0;
    }

    /// <summary>
    /// Peeks an application tag without advancing decoder state.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the candidate tag.</param>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="dataLength">When matched, receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes, or 0 when no match is found.</returns>
    public static int PeekTag(ReadOnlySpan<byte> bytes, ApplicationTagNumber tagNumber, out int dataLength) => PeekTag(bytes, AsduTagClass.Application, (byte)tagNumber, out dataLength);

    /// <summary>
    /// Peeks a context tag without advancing decoder state.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the candidate tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="dataLength">When matched, receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes, or 0 when no match is found.</returns>
    public static int PeekTag(ReadOnlySpan<byte> bytes, byte tagNumber, out int dataLength) => PeekTag(bytes, AsduTagClass.Context, tagNumber, out dataLength);

    /// <summary>
    /// Peeks an opening or closing context tag without advancing decoder state.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the candidate tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="tagType">The expected enclosing tag type.</param>
    /// <returns>The encoded tag-header length in bytes, or 0 when no match is found.</returns>
    public static int PeekTag(ReadOnlySpan<byte> bytes, byte tagNumber, AsduTagType tagType)
    {
        if (tagNumber < 15)
        {
            if (bytes.Length == 0)
            {
                return 0;
            }

            byte expected = (byte)((tagNumber << 4) | (byte)tagType);
            return bytes[0] == expected ? 1 : 0;
        }

        if (bytes.Length < 2)
        {
            return 0;
        }

        byte expectedFirst = (byte)(tagType == AsduTagType.Opening ? 0xFE : 0xFF);
        return (bytes[0] == expectedFirst && bytes[1] == tagNumber) ? 2 : 0;
    }

    /// <summary>
    /// Reads a required application or context tag header.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the required tag.</param>
    /// <param name="tagClass">The required tag class.</param>
    /// <param name="tagNumber">The required tag number.</param>
    /// <param name="dataLength">Receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes.</returns>
    /// <exception cref="AsduException">Thrown when the required tag is not present.</exception>
    public static int ReadTag(ReadOnlySpan<byte> bytes, AsduTagClass tagClass, byte tagNumber, out int dataLength)
    {
        var tagLength = PeekTag(bytes, tagClass, tagNumber, out dataLength);
        if (tagLength == 0)
        {
            throw new AsduException($"Tag number {tagNumber} with class {tagClass} does not exist.");
        }
        return tagLength;
    }

    /// <summary>
    /// Reads a required application tag header.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the required tag.</param>
    /// <param name="tagNumber">The required application tag number.</param>
    /// <param name="dataLength">Receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes.</returns>
    public static int ReadTag(ReadOnlySpan<byte> bytes, ApplicationTagNumber tagNumber, out int dataLength) => ReadTag(bytes, AsduTagClass.Application, (byte)tagNumber, out dataLength);

    /// <summary>
    /// Reads a required context tag header.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the required tag.</param>
    /// <param name="tagNumber">The required context tag number.</param>
    /// <param name="dataLength">Receives the decoded payload length.</param>
    /// <returns>The encoded tag-header length in bytes.</returns>
    public static int ReadTag(ReadOnlySpan<byte> bytes, byte tagNumber, out int dataLength) => ReadTag(bytes, AsduTagClass.Context, tagNumber, out dataLength);

    /// <summary>
    /// Reads a required opening or closing context tag header.
    /// </summary>
    /// <param name="bytes">Input bytes beginning at the required tag.</param>
    /// <param name="tagNumber">The required context tag number.</param>
    /// <param name="tagType">The required enclosing tag type.</param>
    /// <returns>The encoded tag-header length in bytes.</returns>
    /// <exception cref="AsduException">Thrown when the required tag is not present.</exception>
    public static int ReadTag(ReadOnlySpan<byte> bytes, byte tagNumber, AsduTagType tagType)
    {
        var tagLength = PeekTag(bytes, tagNumber, tagType);
        if (tagLength == 0)
        {
            throw new AsduException($"Tag number {tagNumber} with type {tagType} does not exist.");
        }
        return tagLength;
    }





    #region Reading functions

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
        return System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(bytes);
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
        return System.Buffers.Binary.BinaryPrimitives.ReadUInt32BigEndian(bytes);
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
        return System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(bytes);
    }

    /// <summary>
    /// Reads an 8-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit integer value.</returns>
    public static sbyte ReadInteger8(ReadOnlySpan<byte> bytes)
    {
        return (sbyte)bytes[0];
    }

    /// <summary>
    /// Reads a 16-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit integer value.</returns>
    public static short ReadInteger16(ReadOnlySpan<byte> bytes)
    {
        return System.Buffers.Binary.BinaryPrimitives.ReadInt16BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 24-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes.</param>
    /// <returns>The 24-bit integer value as a 32-bit value.</returns>
    public static int ReadInteger24(ReadOnlySpan<byte> bytes)
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
    /// Reads a 32-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit integer value.</returns>
    public static int ReadInteger32(ReadOnlySpan<byte> bytes)
    {
        return System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 40-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The 40-bit integer value as a 64-bit value.</returns>
    public static long ReadInteger40(ReadOnlySpan<byte> bytes)
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
    /// Reads a 48-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The 48-bit integer value as a 64-bit value.</returns>
    public static long ReadInteger48(ReadOnlySpan<byte> bytes)
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
    /// Reads a 56-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The 56-bit integer value as a 64-bit value.</returns>
    public static long ReadInteger56(ReadOnlySpan<byte> bytes)
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
    /// Reads a 64-bit BACnet Integer Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit integer value.</returns>
    public static long ReadInteger64(ReadOnlySpan<byte> bytes)
    {
        return System.Buffers.Binary.BinaryPrimitives.ReadInt64BigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet Real Number Value (IEEE 754 single-precision floating point).
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit float value.</returns>
    public static float ReadReal(ReadOnlySpan<byte> bytes)
    {
        return System.Buffers.Binary.BinaryPrimitives.ReadSingleBigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet Double Precision Real Number Value (IEEE 754 double-precision floating point).
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit double value.</returns>
    public static double ReadDouble(ReadOnlySpan<byte> bytes)
    {
        return System.Buffers.Binary.BinaryPrimitives.ReadDoubleBigEndian(bytes);
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
        var value = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(bytes[1..]);
        return BitReverser.Reverse16Bits(value);
    }

    /// <summary>
    /// Reads a 24-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 24-bit flags value as a 32-bit unsigned integer.</returns>
    public static uint ReadBitFlags24(ReadOnlySpan<byte> bytes)
        => BitReverser.Reverse32Bits(ReadUnsigned24(bytes[1..]) << 8);

    /// <summary>
    /// Reads a 32-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The native 32-bit flags value.</returns>
    public static uint ReadBitFlags32(ReadOnlySpan<byte> bytes)
    {
        var value = System.Buffers.Binary.BinaryPrimitives.ReadUInt32BigEndian(bytes[1..]);
        return BitReverser.Reverse32Bits(value);
    }

    /// <summary>
    /// Reads a 40-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The native 40-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags40(ReadOnlySpan<byte> bytes)
        => BitReverser.Reverse64Bits(ReadUnsigned40(bytes[1..]) << 24);

    /// <summary>
    /// Reads a 48-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The native 48-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags48(ReadOnlySpan<byte> bytes)
        => BitReverser.Reverse64Bits(ReadUnsigned48(bytes[1..]) << 16);

    /// <summary>
    /// Reads a 56-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 56-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags56(ReadOnlySpan<byte> bytes)
        => BitReverser.Reverse64Bits(ReadUnsigned56(bytes[1..]) << 8);

    /// <summary>
    /// Reads a 64-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 9 bytes. The first byte is the unused bits count.</param>
    /// <returns>The native 64-bit flags value.</returns>
    public static ulong ReadBitFlags64(ReadOnlySpan<byte> bytes)
    {
        var value = System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
    }

    /// <summary>
    /// Reads an 8-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit enumerated value.</returns>
    public static Enumerated8 ReadEnumerated8(ReadOnlySpan<byte> bytes) => (Enumerated8)ReadUnsigned8(bytes);

    /// <summary>
    /// Reads a 16-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit enumerated value.</returns>
    public static Enumerated16 ReadEnumerated16(ReadOnlySpan<byte> bytes) => (Enumerated16)ReadUnsigned16(bytes);

    /// <summary>
    /// Reads a 24-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes.</param>
    /// <returns>The 24-bit enumerated value as a 32-bit enumerated.</returns>
    public static Enumerated32 ReadEnumerated24(ReadOnlySpan<byte> bytes) => (Enumerated32)ReadUnsigned24(bytes);

    /// <summary>
    /// Reads a 32-bit enumerated value from the specified read-only byte span.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit enumerated value.</returns>
    public static Enumerated32 ReadEnumerated32(ReadOnlySpan<byte> bytes) => (Enumerated32)ReadUnsigned32(bytes);

    /// <summary>
    /// Reads a 40-bit unsigned integer from the specified byte span and returns it as an Enumerated64 value.
    /// </summary>
    /// <param name="bytes">A read-only span of bytes containing the 40-bit unsigned integer to read. Must contain at least 5 bytes.</param>
    /// <returns>An Enumerated64 value representing the 40-bit unsigned integer read from the byte span.</returns>
    public static Enumerated64 ReadEnumerated40(ReadOnlySpan<byte> bytes) => (Enumerated64)ReadUnsigned40(bytes);

    /// <summary>
    /// Reads a 48-bit enumerated value from the specified read-only byte span.
    /// </summary>
    /// <param name="bytes">A read-only span of bytes containing the 48-bit value to read. Must be at least 6 bytes in length.</param>
    /// <returns>An Enumerated64 value representing the 48-bit enumerated value read from the byte span.</returns>
    public static Enumerated64 ReadEnumerated48(ReadOnlySpan<byte> bytes) => (Enumerated64)ReadUnsigned48(bytes);

    /// <summary>
    /// Reads a 56-bit unsigned integer from the specified byte span and returns it as an Enumerated64 value.
    /// </summary>
    /// <param name="bytes">A read-only span of bytes containing the 56-bit unsigned integer to read. Must contain at least 7 bytes.</param>
    /// <returns>An Enumerated64 value representing the 56-bit unsigned integer read from the specified bytes.</returns>
    public static Enumerated64 ReadEnumerated56(ReadOnlySpan<byte> bytes) => (Enumerated64)ReadUnsigned56(bytes);

    /// <summary>
    /// Reads a 64-bit enumerated value from the specified read-only byte span.
    /// </summary>
    /// <param name="bytes">A read-only span of bytes containing the encoded 64-bit enumerated value to read.</param>
    /// <returns>An <see cref="Enumerated64"/> value representing the decoded 64-bit enumerated value from the input bytes.</returns>
    public static Enumerated64 ReadEnumerated64(ReadOnlySpan<byte> bytes) => (Enumerated64)ReadUnsigned64(bytes);












    public static T ReadEnumerated<T>(ReadOnlySpan<byte> source)
        where T : struct, Enum
    {
        throw new NotImplementedException();
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
        var value = System.Buffers.Binary.BinaryPrimitives.ReadUInt32BigEndian(bytes);
        return new ObjectIdentifier(value);
    }

    #endregion
}

