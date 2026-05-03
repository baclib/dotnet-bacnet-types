// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Integer64Asn1Codec : Asn1CodecBase<long>
{
    private Integer64Asn1Codec()
    {
    }

    public static readonly Integer64Asn1Codec Instance = new();

    public override int GetEncodedSize(in long value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger64(value));

    public override int GetEncodedSize(byte tagNumber, in long value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger64(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in long value)
    {
        var length = AsduLength.FromInteger64(value);
        var bytes = encoder.Encode(tagNumber, tagClass, length);
        switch (length)
        {
            case AsduLength.Signed8:
                AsduPrimitives.WriteInteger8(bytes, (sbyte)value);
                break;
            case AsduLength.Signed16:
                AsduPrimitives.WriteInteger16(bytes, (short)value);
                break;
            case AsduLength.Signed24:
                AsduPrimitives.WriteInteger24(bytes, (int)value);
                break;
            case AsduLength.Signed32:
                AsduPrimitives.WriteInteger32(bytes, (int)value);
                break;
            case AsduLength.Signed40:
                AsduPrimitives.WriteInteger40(bytes, value);
                break;
            case AsduLength.Signed48:
                AsduPrimitives.WriteInteger48(bytes, value);
                break;
            case AsduLength.Signed56:
                AsduPrimitives.WriteInteger56(bytes, value);
                break;
            case AsduLength.Signed64:
                AsduPrimitives.WriteInteger64(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 64-bit integer.");
        }
    }

    public override void Encode(ref AsduEncoder encoder, in long value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in long value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static long ReadInteger64(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Signed8 => AsduPrimitives.ReadSigned8(bytes),
            AsduLength.Signed16 => AsduPrimitives.ReadSigned16(bytes),
            AsduLength.Signed24 => AsduPrimitives.ReadSigned24(bytes),
            AsduLength.Signed32 => AsduPrimitives.ReadSigned32(bytes),
            AsduLength.Signed40 => AsduPrimitives.ReadSigned40(bytes),
            AsduLength.Signed48 => AsduPrimitives.ReadSigned48(bytes),
            AsduLength.Signed56 => AsduPrimitives.ReadSigned56(bytes),
            AsduLength.Signed64 => AsduPrimitives.ReadSigned64(bytes),
            _ => throw new AsduException()
        };
    }

    private static long Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadInteger64(ref bytes);
    }

    public override long Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override long Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<long> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadInteger64(ref bytes);
        }

        return default;
    }

    public override Optional<long> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override Optional<long> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
