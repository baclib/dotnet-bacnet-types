// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Enumerated32Asn1Codec : Asn1Codec<Enumerated32>
{
    private Enumerated32Asn1Codec()
    {
    }

    public static readonly Enumerated32Asn1Codec Instance = new();

    public override int GetEncodedSize(in Enumerated32 value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned32((uint)value));

    public override int GetEncodedSize(byte tagNumber, in Enumerated32 value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned32((uint)value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in Enumerated32 value)
    {
        var length = AsduLength.FromUnsigned32((uint)value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case AsduLength.Enumerated8:
                AsduEncoder.WriteEnumerated8(bytes, (Enumerated8)value);
                break;
            case AsduLength.Enumerated16:
                AsduEncoder.WriteEnumerated16(bytes, (Enumerated16)value);
                break;
            case AsduLength.Enumerated24:
                AsduEncoder.WriteEnumerated24(bytes, value);
                break;
            case AsduLength.Enumerated32:
                AsduEncoder.WriteEnumerated32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    public override void Encode(ref AsduEncoder encoder, in Enumerated32 value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in Enumerated32 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static Enumerated32 ReadEnumerated32(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => (Enumerated32)AsduDecoder.ReadEnumerated8(bytes),
            AsduLength.Unsigned16 => (Enumerated32)AsduDecoder.ReadEnumerated16(bytes),
            AsduLength.Unsigned24 => AsduDecoder.ReadEnumerated24(bytes),
            AsduLength.Unsigned32 => AsduDecoder.ReadEnumerated32(bytes),
            _ => throw new AsduException()
        };
    }

    private static Enumerated32 Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadEnumerated32(ref bytes);
    }

    public override Enumerated32 Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override Enumerated32 Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<Enumerated32> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadEnumerated32(ref bytes);
        }

        return default;
    }

    public override Optional<Enumerated32> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Enumerated, AsduTagClass.Application);

    public override Optional<Enumerated32> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
