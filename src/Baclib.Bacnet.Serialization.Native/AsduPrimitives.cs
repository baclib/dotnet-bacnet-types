// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Diagnostics;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides semantic BACnet primitive payload read/write helpers built on top of <see cref="AsduBinaryPrimitives"/>.
/// </summary>
public static class AsduPrimitives
{
    /// <summary>
    /// Reads a variable-length BACnet unsigned integer, returning a 32-bit result.
    /// Convenience alias for <see cref="ReadUnsigned32"/>.
    /// </summary>
    /// <param name="source">A span containing 1 to 4 bytes.</param>
    /// <returns>The unsigned integer value.</returns>
    public static uint ReadUnsigned(ReadOnlySpan<byte> source)
        => ReadUnsigned32(source);

    /// <summary>
    /// Reads a 1-byte BACnet unsigned integer value.
    /// </summary>
    /// <param name="source">A span containing exactly 1 byte.</param>
    /// <returns>The 8-bit unsigned integer.</returns>
    public static byte ReadUnsigned8(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet unsigned integer value, returning a 16-bit result.
    /// Accepts spans of 1 or 2 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 2 bytes.</param>
    /// <returns>The unsigned integer value as a 16-bit value.</returns>
    public static ushort ReadUnsigned16(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet unsigned integer value, returning a 32-bit result.
    /// Accepts spans of 1 to 4 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 4 bytes.</param>
    /// <returns>The unsigned integer value as a 32-bit value.</returns>
    public static uint ReadUnsigned32(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            AsduLength.Unsigned24 => AsduBinaryPrimitives.ReadUnsigned24(source),
            AsduLength.Unsigned32 => AsduBinaryPrimitives.ReadUnsigned32(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet unsigned integer value, returning a 64-bit result.
    /// Accepts spans of 1 to 8 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 8 bytes.</param>
    /// <returns>The unsigned integer value as a 64-bit value.</returns>
    public static ulong ReadUnsigned64(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            AsduLength.Unsigned24 => AsduBinaryPrimitives.ReadUnsigned24(source),
            AsduLength.Unsigned32 => AsduBinaryPrimitives.ReadUnsigned32(source),
            AsduLength.Unsigned40 => AsduBinaryPrimitives.ReadUnsigned40(source),
            AsduLength.Unsigned48 => AsduBinaryPrimitives.ReadUnsigned48(source),
            AsduLength.Unsigned56 => AsduBinaryPrimitives.ReadUnsigned56(source),
            AsduLength.Unsigned64 => AsduBinaryPrimitives.ReadUnsigned64(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet signed integer, returning a 32-bit result.
    /// Convenience alias for <see cref="ReadInteger32"/>.
    /// </summary>
    /// <param name="source">A span containing 1 to 4 bytes.</param>
    /// <returns>The signed integer value.</returns>
    public static int ReadInteger(ReadOnlySpan<byte> source)
        => ReadInteger32(source);

    /// <summary>
    /// Reads a 1-byte BACnet signed integer value.
    /// </summary>
    /// <param name="source">A span containing exactly 1 byte.</param>
    /// <returns>The 8-bit signed integer value.</returns>
    public static sbyte ReadInteger8(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet signed integer value, returning a 16-bit result.
    /// Accepts spans of 1 or 2 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 2 bytes.</param>
    /// <returns>The signed integer value as a 16-bit value.</returns>
    public static short ReadInteger16(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Integer16 => AsduBinaryPrimitives.ReadInteger16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet signed integer value, returning a 32-bit result.
    /// Accepts spans of 1 to 4 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 4 bytes.</param>
    /// <returns>The signed integer value as a 32-bit value.</returns>
    public static int ReadInteger32(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Integer16 => AsduBinaryPrimitives.ReadInteger16(source),
            AsduLength.Integer24 => AsduBinaryPrimitives.ReadInteger24(source),
            AsduLength.Integer32 => AsduBinaryPrimitives.ReadInteger32(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Reads a variable-length BACnet signed integer value, returning a 64-bit result.
    /// Accepts spans of 1 to 8 bytes.
    /// </summary>
    /// <param name="source">A span containing 1 to 8 bytes.</param>
    /// <returns>The signed integer value as a 64-bit value.</returns>
    public static long ReadInteger64(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Integer16 => AsduBinaryPrimitives.ReadInteger16(source),
            AsduLength.Integer24 => AsduBinaryPrimitives.ReadInteger24(source),
            AsduLength.Integer32 => AsduBinaryPrimitives.ReadInteger32(source),
            AsduLength.Integer40 => AsduBinaryPrimitives.ReadInteger40(source),
            AsduLength.Integer48 => AsduBinaryPrimitives.ReadInteger48(source),
            AsduLength.Integer56 => AsduBinaryPrimitives.ReadInteger56(source),
            AsduLength.Integer64 => AsduBinaryPrimitives.ReadInteger64(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Writes a variable-length BACnet unsigned integer value.
    /// Convenience alias for <see cref="WriteUnsigned32"/>.
    /// </summary>
    /// <param name="destination">A span with 1 to 4 bytes capacity.</param>
    /// <param name="value">The unsigned integer value to write.</param>
    public static void WriteUnsigned(Span<byte> destination, uint value)
        => WriteUnsigned32(destination, value);

    /// <summary>
    /// Writes a 1-byte BACnet unsigned integer value.
    /// </summary>
    /// <param name="destination">A span with exactly 1 byte capacity.</param>
    /// <param name="value">The 8-bit unsigned integer to write.</param>
    public static void WriteUnsigned8(Span<byte> destination, byte value)
    {
        switch (destination.Length)
        {
            case AsduLength.Unsigned8:
                AsduBinaryPrimitives.WriteUnsigned8(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet unsigned integer value of up to 16-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 2 bytes capacity.</param>
    /// <param name="value">The unsigned integer value to write.</param>
    public static void WriteUnsigned16(Span<byte> destination, ushort value)
    {
        switch (destination.Length)
        {
            case AsduLength.Unsigned8:
                Debug.Assert(value <= byte.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            case AsduLength.Unsigned16:
                AsduBinaryPrimitives.WriteUnsigned16(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet unsigned integer value of up to 32-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 4 bytes capacity.</param>
    /// <param name="value">The unsigned integer value to write.</param>
    public static void WriteUnsigned32(Span<byte> destination, uint value)
    {
        switch (destination.Length)
        {
            case AsduLength.Unsigned8:
                Debug.Assert(value <= byte.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            case AsduLength.Unsigned16:
                Debug.Assert(value <= ushort.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned16(destination, (ushort)value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned24:
                Debug.Assert(value <= 0xFFFFFF);
                AsduBinaryPrimitives.WriteUnsigned24(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned32:
                AsduBinaryPrimitives.WriteUnsigned32(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet unsigned integer value of up to 64-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 8 bytes capacity.</param>
    /// <param name="value">The unsigned integer value to write.</param>
    public static void WriteUnsigned64(Span<byte> destination, ulong value)
    {
        switch (destination.Length)
        {
            case AsduLength.Unsigned8:
                Debug.Assert(value <= byte.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            case AsduLength.Unsigned16:
                Debug.Assert(value <= ushort.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned16(destination, (ushort)value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned24:
                Debug.Assert(value <= 0x00FF_FFFFul);
                AsduBinaryPrimitives.WriteUnsigned24(destination, (uint)value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned32:
                Debug.Assert(value <= uint.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned32(destination, (uint)value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned40:
                AsduBinaryPrimitives.WriteUnsigned40(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned48:
                AsduBinaryPrimitives.WriteUnsigned48(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned56:
                AsduBinaryPrimitives.WriteUnsigned56(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            case AsduLength.Unsigned64:
                AsduBinaryPrimitives.WriteUnsigned64(destination, value);
                Debug.Assert(destination[0] != 0);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet signed integer value.
    /// Convenience alias for <see cref="WriteInteger32"/>.
    /// </summary>
    /// <param name="destination">A span with 1 to 4 bytes capacity.</param>
    /// <param name="value">The signed integer value to write.</param>
    public static void WriteInteger(Span<byte> destination, int value)
        => WriteInteger32(destination, value);

    /// <summary>
    /// Writes a 1-byte BACnet signed integer value.
    /// </summary>
    /// <param name="destination">A span with exactly 1 byte capacity.</param>
    /// <param name="value">The 8-bit signed integer value to write.</param>
    public static void WriteInteger8(Span<byte> destination, sbyte value)
    {
        switch (destination.Length)
        {
            case AsduLength.Integer8:
                AsduBinaryPrimitives.WriteInteger8(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet signed integer value of up to 16-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 2 bytes capacity.</param>
    /// <param name="value">The signed integer value to write.</param>
    public static void WriteInteger16(Span<byte> destination, short value)
    {
        switch (destination.Length)
        {
            case AsduLength.Integer8:
                Debug.Assert(value >= sbyte.MinValue && value <= sbyte.MaxValue);
                AsduBinaryPrimitives.WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Integer16:
                Debug.Assert(value < sbyte.MinValue || value > sbyte.MaxValue);
                AsduBinaryPrimitives.WriteInteger16(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet signed integer value of up to 32-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 4 bytes capacity.</param>
    /// <param name="value">The signed integer value to write.</param>
    public static void WriteInteger32(Span<byte> destination, int value)
    {
        switch (destination.Length)
        {
            case AsduLength.Integer8:
                Debug.Assert(value >= sbyte.MinValue && value <= sbyte.MaxValue);
                WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Integer16:
                Debug.Assert(value >= short.MinValue && value <= short.MaxValue);
                Debug.Assert(value < sbyte.MinValue || value > sbyte.MaxValue);
                WriteInteger16(destination, (short)value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer24:
                Debug.Assert(value >= -0x800000 && value <= 0x7FFFFF);
                Debug.Assert(value < short.MinValue || value > short.MaxValue);
                AsduBinaryPrimitives.WriteInteger24(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer32:
                Debug.Assert(value < -0x800000 || value > 0x7FFFFF);
                AsduBinaryPrimitives.WriteInteger32(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Writes a variable-length BACnet signed integer value of up to 64-bit precision.
    /// The destination length determines the encoding width; use the minimum width that fits the value.
    /// </summary>
    /// <param name="destination">A span with 1 to 8 bytes capacity.</param>
    /// <param name="value">The signed integer value to write.</param>
    public static void WriteInteger64(Span<byte> destination, long value)
    {
        switch (destination.Length)
        {
            case AsduLength.Integer8:
                Debug.Assert(value >= sbyte.MinValue && value <= sbyte.MaxValue);
                WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Integer16:
                Debug.Assert(value >= short.MinValue && value <= short.MaxValue);
                Debug.Assert(value < sbyte.MinValue || value > sbyte.MaxValue);
                WriteInteger16(destination, (short)value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer24:
                Debug.Assert(value >= -0x800000L && value <= 0x7FFFFFL);
                Debug.Assert(value < short.MinValue || value > short.MaxValue);
                AsduBinaryPrimitives.WriteInteger24(destination, (int)value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer32:
                Debug.Assert(value >= int.MinValue && value <= int.MaxValue);
                Debug.Assert(value < -0x800000L || value > 0x7FFFFFL);
                AsduBinaryPrimitives.WriteInteger32(destination, (int)value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer40:
                Debug.Assert(value < int.MinValue || value > int.MaxValue);
                AsduBinaryPrimitives.WriteInteger40(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer48:
                Debug.Assert(value < -(1L << 39) || value > ((1L << 39) - 1));
                AsduBinaryPrimitives.WriteInteger48(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer56:
                Debug.Assert(value < -(1L << 47) || value > ((1L << 47) - 1));
                AsduBinaryPrimitives.WriteInteger56(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            case AsduLength.Integer64:
                Debug.Assert(value < -(1L << 55) || value > ((1L << 55) - 1));
                AsduBinaryPrimitives.WriteInteger64(destination, value);
                Debug.Assert(destination[0] != (byte)((sbyte)destination[1] >> 7));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }
}
