// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Buffers.Binary;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides low-level big-endian read and write methodes for BACnet numeric primitive values.
/// </summary>
public static class AsduBinaryPrimitives
{
    /// <summary>
    /// Reads an 8-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit unsigned integer.</returns>
    public static byte ReadUnsigned8(ReadOnlySpan<byte> bytes)
    {
        return bytes[0];
    }

    /// <summary>
    /// Reads a 16-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit unsigned integer.</returns>
    public static ushort ReadUnsigned16(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt16BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 24-bit BACnet unsigned integer value.
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
    /// Reads a 32-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit unsigned integer.</returns>
    public static uint ReadUnsigned32(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt32BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 40-bit BACnet unsigned integer value.
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
    /// Reads a 48-bit BACnet unsigned integer value.
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
    /// Reads a 56-bit BACnet unsigned integer value.
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
    /// Reads a 64-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit unsigned integer.</returns>
    public static ulong ReadUnsigned64(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadUInt64BigEndian(bytes);
    }

    /// <summary>
    /// Reads an 8-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 1 byte.</param>
    /// <returns>The 8-bit signed integer value.</returns>
    public static sbyte ReadInteger8(ReadOnlySpan<byte> bytes)
    {
        return (sbyte)bytes[0];
    }

    /// <summary>
    /// Reads a 16-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 2 bytes.</param>
    /// <returns>The 16-bit signed integer value.</returns>
    public static short ReadInteger16(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt16BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 24-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 3 bytes.</param>
    /// <returns>The 24-bit signed integer value as a 32-bit value.</returns>
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
    /// Reads a 32-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit signed integer value.</returns>
    public static int ReadInteger32(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt32BigEndian(bytes);
    }

    /// <summary>
    /// Reads a 40-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 5 bytes.</param>
    /// <returns>The 40-bit signed integer value as a 64-bit value.</returns>
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
    /// Reads a 48-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 6 bytes.</param>
    /// <returns>The 48-bit signed integer value as a 64-bit value.</returns>
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
    /// Reads a 56-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 7 bytes.</param>
    /// <returns>The 56-bit signed integer value as a 64-bit value.</returns>
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
    /// Reads a 64-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit signed integer value.</returns>
    public static long ReadInteger64(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadInt64BigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet real number value (IEEE 754 single-precision floating-point).
    /// </summary>
    /// <param name="bytes">A span containing at least 4 bytes.</param>
    /// <returns>The 32-bit float value.</returns>
    public static float ReadReal(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadSingleBigEndian(bytes);
    }

    /// <summary>
    /// Reads a BACnet double precision real number value (IEEE 754 double-precision floating-point).
    /// </summary>
    /// <param name="bytes">A span containing at least 8 bytes.</param>
    /// <returns>The 64-bit double value.</returns>
    public static double ReadDouble(ReadOnlySpan<byte> bytes)
    {
        return BinaryPrimitives.ReadDoubleBigEndian(bytes);
    }

    /// <summary>
    /// Writes an 8-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit unsigned integer to write.</param>
    public static void WriteUnsigned8(Span<byte> bytes, byte value)
    {
        bytes[0] = value;
    }

    /// <summary>
    /// Writes a 16-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit unsigned integer to write.</param>
    public static void WriteUnsigned16(Span<byte> bytes, ushort value)
    {
        BinaryPrimitives.WriteUInt16BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 24-bit BACnet unsigned integer value.
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
    /// Writes a 32-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit unsigned integer to write.</param>
    public static void WriteUnsigned32(Span<byte> bytes, uint value)
    {
        BinaryPrimitives.WriteUInt32BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 40-bit BACnet unsigned integer value.
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
    /// Writes a 48-bit BACnet unsigned integer value.
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
    /// Writes a 56-bit BACnet unsigned integer value.
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
    /// Writes a 64-bit BACnet unsigned integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit unsigned integer to write.</param>
    public static void WriteUnsigned64(Span<byte> bytes, ulong value)
    {
        BinaryPrimitives.WriteUInt64BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes an 8-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The 8-bit signed integer value to write.</param>
    public static void WriteInteger8(Span<byte> bytes, sbyte value)
    {
        bytes[0] = (byte)value;
    }

    /// <summary>
    /// Writes a 16-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 2 bytes capacity.</param>
    /// <param name="value">The 16-bit signed integer value to write.</param>
    public static void WriteInteger16(Span<byte> bytes, short value)
    {
        BinaryPrimitives.WriteInt16BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 24-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 3 bytes capacity.</param>
    /// <param name="value">The 24-bit signed integer value to write (as a 32-bit value).</param>
    public static void WriteInteger24(Span<byte> bytes, int value)
    {
        bytes[0] = (byte)(value >> 16);
        bytes[1] = (byte)(value >> 8);
        bytes[2] = (byte)value;
    }

    /// <summary>
    /// Writes a 32-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit signed integer value to write.</param>
    public static void WriteInteger32(Span<byte> bytes, int value)
    {
        BinaryPrimitives.WriteInt32BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a 40-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 5 bytes capacity.</param>
    /// <param name="value">The 40-bit signed integer value to write (as a 64-bit value).</param>
    public static void WriteInteger40(Span<byte> bytes, long value)
    {
        bytes[0] = (byte)(value >> 32);
        bytes[1] = (byte)(value >> 24);
        bytes[2] = (byte)(value >> 16);
        bytes[3] = (byte)(value >> 8);
        bytes[4] = (byte)value;
    }

    /// <summary>
    /// Writes a 48-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 6 bytes capacity.</param>
    /// <param name="value">The 48-bit signed integer value to write (as a 64-bit value).</param>
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
    /// Writes a 56-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 7 bytes capacity.</param>
    /// <param name="value">The 56-bit signed integer value to write (as a 64-bit value).</param>
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
    /// Writes a 64-bit BACnet signed integer value.
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit signed integer value to write.</param>
    public static void WriteInteger64(Span<byte> bytes, long value)
    {
        BinaryPrimitives.WriteInt64BigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a BACnet real number value (IEEE 754 single-precision floating-point).
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The 32-bit float value to write.</param>
    public static void WriteReal(Span<byte> bytes, float value)
    {
        BinaryPrimitives.WriteSingleBigEndian(bytes, value);
    }

    /// <summary>
    /// Writes a BACnet double precision real number value (IEEE 754 double-precision floating-point).
    /// </summary>
    /// <param name="bytes">A span with at least 8 bytes capacity.</param>
    /// <param name="value">The 64-bit double value to write.</param>
    public static void WriteDouble(Span<byte> bytes, double value)
    {
        BinaryPrimitives.WriteDoubleBigEndian(bytes, value);
    }
}
