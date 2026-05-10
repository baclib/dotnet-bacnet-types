// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Integer32Asn1Codec : Asn1Codec<int>
{
    private Integer32Asn1Codec()
    {
    }

    public static readonly Integer32Asn1Codec Instance = new();

    public override int GetEncodedSize(in int value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger32(value));

    public override int GetEncodedSize(byte tagNumber, in int value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger32(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in int value)
    {
        var length = AsduLength.FromInteger32(value);
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
                AsduEncoder.WriteInteger24(bytes, value);
                break;
            case AsduLength.Signed32:
                AsduEncoder.WriteInteger32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 32-bit integer.");
        }
    }

    public override void Encode(ref AsduEncoder encoder, in int value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in int value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static int ReadInteger32(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Signed8 => AsduDecoder.ReadInteger8(bytes),
            AsduLength.Signed16 => AsduDecoder.ReadInteger16(bytes),
            AsduLength.Signed24 => AsduDecoder.ReadInteger24(bytes),
            AsduLength.Signed32 => AsduDecoder.ReadInteger32(bytes),
            _ => throw new AsduException()
        };
    }

    private static int Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadInteger32(ref bytes);
    }

    public override int Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override int Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<int> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadInteger32(ref bytes);
        }

        return default;
    }

    public override Optional<int> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override Optional<int> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
