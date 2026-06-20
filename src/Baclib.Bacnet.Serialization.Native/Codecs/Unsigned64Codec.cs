// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned64Codec : INativeCodec<ulong>
{
    private Unsigned64Codec()
    {
    }

    public static readonly Unsigned64Codec Instance = new();

    public int GetEncodedSize(in ulong value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned64(value));

    public int GetEncodedSize(byte tagNumber, in ulong value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned64(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in ulong value)
    {
        var length = AsduLength.FromUnsigned64(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Unsigned8:
                AsduEncoder.WriteUnsigned8(bytes, (byte)value);
                break;
            case AsduLength.Unsigned16:
                AsduEncoder.WriteUnsigned16(bytes, (ushort)value);
                break;
            case AsduLength.Unsigned24:
                AsduEncoder.WriteUnsigned24(bytes, (uint)value);
                break;
            case AsduLength.Unsigned32:
                AsduEncoder.WriteUnsigned32(bytes, (uint)value);
                break;
            case AsduLength.Unsigned40:
                AsduEncoder.WriteUnsigned40(bytes, value);
                break;
            case AsduLength.Unsigned48:
                AsduEncoder.WriteUnsigned48(bytes, value);
                break;
            case AsduLength.Unsigned56:
                AsduEncoder.WriteUnsigned56(bytes, value);
                break;
            case AsduLength.Unsigned64:
                AsduEncoder.WriteUnsigned64(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 64-bit integer.");
        }
    }

    public void Encode(ref AsduEncoder encoder, in ulong value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in ulong value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static ulong ReadUnsigned64(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
            AsduLength.Unsigned24 => NativePrimitives.ReadUnsigned24(bytes),
            AsduLength.Unsigned32 => NativePrimitives.ReadUnsigned32(bytes),
            AsduLength.Unsigned40 => NativePrimitives.ReadUnsigned40(bytes),
            AsduLength.Unsigned48 => NativePrimitives.ReadUnsigned48(bytes),
            AsduLength.Unsigned56 => NativePrimitives.ReadUnsigned56(bytes),
            AsduLength.Unsigned64 => NativePrimitives.ReadUnsigned64(bytes),
            _ => throw new AsduException()
        };
    }

    private static ulong Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadUnsigned64(ref bytes);
    }

    public ulong Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public ulong Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<ulong> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadUnsigned64(ref bytes);
        }

        return default;
    }

    public Optional<ulong> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public Optional<ulong> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

