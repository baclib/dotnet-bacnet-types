// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;
using System.Buffers.Binary;

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Provides static methods for reading and writing BACnet ASDU primitives.
/// All multi-byte values are in big-endian (network) byte order with the most significant byte (MSB) first.
/// </summary>
public static class AsduPrimitives
{

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
        var value = AsduDecoder.ReadUnsigned24(bytes[1..]);
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
        var value = AsduDecoder.ReadUnsigned40(bytes[1..]);
        return BitReverser.Reverse64Bits(value);
    }

    /// <summary>
    /// Reads a 48-bit BACnet Bit String Value and returns it as a native flags value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The native 48-bit flags value as a 64-bit unsigned integer.</returns>
    public static ulong ReadBitFlags48(ReadOnlySpan<byte> bytes)
    {
        var value = AsduDecoder.ReadUnsigned48(bytes[1..]);
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
        var value = AsduDecoder.ReadUnsigned56(bytes[1..]);
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
    /// Reads a BACnet Date Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes (year, month, day, dayOfWeek).</param>
    /// <returns>A <see cref="Date"/> instance.</returns>
    public static Date ReadDate(ReadOnlySpan<byte> bytes)
    {
        var year = bytes[0];
        var month = bytes[1];
        var day = bytes[2];
        var dayOfWeek = bytes[3];

        return new Date(year, month, day, dayOfWeek);
    }

    /// <summary>
    /// Reads a BACnet Time Value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes (hour, minute, second, hundredths).</param>
    /// <returns>A <see cref="Time"/> instance.</returns>
    public static Time ReadTime(ReadOnlySpan<byte> bytes)
    {
        var hour = bytes[0];
        var minute = bytes[1];
        var second = bytes[2];
        var hundredths = bytes[3];

        return new Time(hour, minute, second, hundredths);
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
        BinaryPrimitives.WriteUInt16BigEndian(bytes, value);
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
        BinaryPrimitives.WriteUInt32BigEndian(bytes, value);
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
        BinaryPrimitives.WriteUInt64BigEndian(bytes, value);
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
        BinaryPrimitives.WriteInt16BigEndian(bytes, value);
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
        BinaryPrimitives.WriteInt32BigEndian(bytes, value);
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
        BinaryPrimitives.WriteInt64BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 32-bit BACnet Real Number Value (IEEE 754 single-precision floating point).
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit float value to write.</param>
    public static void WriteReal(Span<byte> bytes, float value)
    {
        BinaryPrimitives.WriteSingleBigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 64-bit BACnet Double Precision Real Number Value (IEEE 754 double-precision floating point).
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit double value to write.</param>
    public static void WriteDouble(Span<byte> bytes, double value)
    {
        BinaryPrimitives.WriteDoubleBigEndian(bytes, value);
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
        BinaryPrimitives.WriteUInt16BigEndian(bytes[1..], reversed);
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
        BinaryPrimitives.WriteUInt32BigEndian(bytes[1..], reversed);
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
        BinaryPrimitives.WriteUInt64BigEndian(bytes[1..], reversed);
    }

    /// <summary>
    /// Writes an 8-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit enumerated value to write.</param>
    public static void WriteEnumerated8(Span<byte> bytes, byte value) => WriteUnsigned8(bytes, value);

    /// <summary>
    /// Writes a 16-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit enumerated value to write.</param>
    public static void WriteEnumerated16(Span<byte> bytes, ushort value) => WriteUnsigned16(bytes, value);

    /// <summary>
    /// Writes a 24-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity.</param>
    /// <param name="value">The 24-bit enumerated value to write (as a 32-bit unsigned integer).</param>
    public static void WriteEnumerated24(Span<byte> bytes, uint value) => WriteUnsigned24(bytes, value);

    /// <summary>
    /// Writes a 32-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit enumerated value to write.</param>
    public static void WriteEnumerated32(Span<byte> bytes, uint value) => WriteUnsigned32(bytes, value);

    /// <summary>
    /// Writes a 40-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity.</param>
    /// <param name="value">The 40-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated40(Span<byte> bytes, ulong value) => WriteUnsigned40(bytes, value);

    /// <summary>
    /// Writes a 48-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity.</param>
    /// <param name="value">The 48-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated48(Span<byte> bytes, ulong value) => WriteUnsigned48(bytes, value);

    /// <summary>
    /// Writes a 56-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity.</param>
    /// <param name="value">The 56-bit enumerated value to write (as a 64-bit unsigned integer).</param>
    public static void WriteEnumerated56(Span<byte> bytes, ulong value) => WriteUnsigned56(bytes, value);

    /// <summary>
    /// Writes a 64-bit BACnet Enumerated Value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit enumerated value to write.</param>
    public static void WriteEnumerated64(Span<byte> bytes, ulong value) => WriteUnsigned64(bytes, value);

    /// <summary>
    /// Writes a BACnet Date Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity (year, month, day, dayOfWeek).</param>
    /// <param name="value">The Date Value to write.</param>
    public static void WriteDate(Span<byte> bytes, Date value)
    {
        bytes[0] = value.Year;
        bytes[1] = value.Month;
        bytes[2] = value.Day;
        bytes[3] = value.DayOfWeek;
    }

    /// <summary>
    /// Writes a BACnet Time Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity (hour, minute, second, hundredths).</param>
    /// <param name="value">The Time Value to write.</param>
    public static void WriteTime(Span<byte> bytes, Time value)
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
        BinaryPrimitives.WriteUInt32BigEndian(bytes, value.Value);
    }
}
