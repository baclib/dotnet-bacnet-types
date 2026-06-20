// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Integer64Codec : INativeCodec<long>
{
    private Integer64Codec()
    {
    }

    public static readonly Integer64Codec Instance = new();

    public int GetEncodedSize(in long value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger64(value));

    public int GetEncodedSize(byte tagNumber, in long value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger64(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in long value)
    {
        var length = AsduLength.FromInteger64(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Signed8:
                AsduEncoder.WriteInteger8(bytes, (sbyte)value);
                break;
            case AsduLength.Signed16:
                AsduEncoder.WriteInteger16(bytes, (short)value);
                break;
            case AsduLength.Signed24:
                AsduEncoder.WriteInteger24(bytes, (int)value);
                break;
            case AsduLength.Signed32:
                AsduEncoder.WriteInteger32(bytes, (int)value);
                break;
            case AsduLength.Signed40:
                AsduEncoder.WriteInteger40(bytes, value);
                break;
            case AsduLength.Signed48:
                AsduEncoder.WriteInteger48(bytes, value);
                break;
            case AsduLength.Signed56:
                AsduEncoder.WriteInteger56(bytes, value);
                break;
            case AsduLength.Signed64:
                AsduEncoder.WriteInteger64(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 64-bit integer.");
        }
    }

    public void Encode(ref AsduEncoder encoder, in long value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in long value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static long ReadInteger64(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(bytes),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(bytes),
            AsduLength.Signed24 => NativePrimitives.ReadInteger24(bytes),
            AsduLength.Signed32 => NativePrimitives.ReadInteger32(bytes),
            AsduLength.Signed40 => NativePrimitives.ReadInteger40(bytes),
            AsduLength.Signed48 => NativePrimitives.ReadInteger48(bytes),
            AsduLength.Signed56 => NativePrimitives.ReadInteger56(bytes),
            AsduLength.Signed64 => NativePrimitives.ReadInteger64(bytes),
            _ => throw new AsduException()
        };
    }

    private static long Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadInteger64(ref bytes);
    }

    public long Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public long Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<long> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadInteger64(ref bytes);
        }

        return default;
    }

    public Optional<long> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public Optional<long> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

