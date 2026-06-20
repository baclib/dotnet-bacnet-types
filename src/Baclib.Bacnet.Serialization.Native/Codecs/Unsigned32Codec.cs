// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned32Codec : INativeCodec<uint>
{
    private Unsigned32Codec()
    {
    }

    public static readonly Unsigned32Codec Instance = new();

    public int GetEncodedSize(in uint value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned32(value));

    public int GetEncodedSize(byte tagNumber, in uint value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned32(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in uint value)
    {
        var length = AsduLength.FromUnsigned32(value);
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
                AsduEncoder.WriteUnsigned24(bytes, value);
                break;
            case AsduLength.Unsigned32:
                AsduEncoder.WriteUnsigned32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    public void Encode(ref AsduEncoder encoder, in uint value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in uint value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static uint ReadUnsigned32(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => NativePrimitives.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => NativePrimitives.ReadUnsigned16(bytes),
            AsduLength.Unsigned24 => NativePrimitives.ReadUnsigned24(bytes),
            AsduLength.Unsigned32 => NativePrimitives.ReadUnsigned32(bytes),
            _ => throw new AsduException()
        };
    }

    private static uint Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadUnsigned32(ref bytes);
    }

    public uint Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public uint Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<uint> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadUnsigned32(ref bytes);
        }

        return default;
    }

    public Optional<uint> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public Optional<uint> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

