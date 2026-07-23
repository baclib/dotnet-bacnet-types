// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Diagnostics;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides semantic BACnet primitive payload read/write helpers built on top of <see cref="AsduBinaryPrimitives"/>.
/// </summary>
public static class AsduPrimitives
{
    public static uint ReadUnsigned(ReadOnlySpan<byte> source)
        => ReadUnsigned32(source);

    public static byte ReadUnsigned8(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    public static ushort ReadUnsigned16(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

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

    public static int ReadInteger(ReadOnlySpan<byte> source)
        => ReadInteger32(source);

    public static sbyte ReadInteger8(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    public static short ReadInteger16(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Integer8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Integer16 => AsduBinaryPrimitives.ReadInteger16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

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

    public static void WriteUnsigned(Span<byte> destination, uint value)
        => WriteUnsigned32(destination, value);

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
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

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
                break;
            case AsduLength.Unsigned24:
                Debug.Assert(value <= 0x00FF_FFFFul);
                AsduBinaryPrimitives.WriteUnsigned24(destination, (uint)value);
                break;
            case AsduLength.Unsigned32:
                Debug.Assert(value <= uint.MaxValue);
                AsduBinaryPrimitives.WriteUnsigned32(destination, (uint)value);
                break;
            case AsduLength.Unsigned40:
                AsduBinaryPrimitives.WriteUnsigned40(destination, value);
                break;
            case AsduLength.Unsigned48:
                AsduBinaryPrimitives.WriteUnsigned48(destination, value);
                break;
            case AsduLength.Unsigned56:
                AsduBinaryPrimitives.WriteUnsigned56(destination, value);
                break;
            case AsduLength.Unsigned64:
                AsduBinaryPrimitives.WriteUnsigned64(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    public static void WriteInteger(Span<byte> destination, int value)
        => WriteInteger32(destination, value);

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

    public static void WriteInteger16(Span<byte> destination, short value)
    {
        switch (destination.Length)
        {
            case AsduLength.Integer8:
                Debug.Assert(value >= sbyte.MinValue && value <= sbyte.MaxValue);
                AsduBinaryPrimitives.WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Integer16:
                AsduBinaryPrimitives.WriteInteger16(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

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
                WriteInteger16(destination, (short)value);
                break;
            case AsduLength.Integer24:
                Debug.Assert(value >= -0x800000 && value <= 0x7FFFFF);
                AsduBinaryPrimitives.WriteInteger24(destination, value);
                break;
            case AsduLength.Integer32:
                AsduBinaryPrimitives.WriteInteger32(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

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
                WriteInteger16(destination, (short)value);
                break;
            case AsduLength.Integer24:
                Debug.Assert(value >= -0x800000L && value <= 0x7FFFFFL);
                AsduBinaryPrimitives.WriteInteger24(destination, (int)value);
                break;
            case AsduLength.Integer32:
                Debug.Assert(value >= int.MinValue && value <= int.MaxValue);
                AsduBinaryPrimitives.WriteInteger32(destination, (int)value);
                break;
            case AsduLength.Integer40:
                AsduBinaryPrimitives.WriteInteger40(destination, value);
                break;
            case AsduLength.Integer48:
                AsduBinaryPrimitives.WriteInteger48(destination, value);
                break;
            case AsduLength.Integer56:
                AsduBinaryPrimitives.WriteInteger56(destination, value);
                break;
            case AsduLength.Integer64:
                AsduBinaryPrimitives.WriteInteger64(destination, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }
}
