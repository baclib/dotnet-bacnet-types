// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Unsigned16Asn1Codec : Asn1Codec<ushort>
{
    private Unsigned16Asn1Codec()
    {
    }

    public static readonly Unsigned16Asn1Codec Instance = new();

    public override int GetEncodedSize(in ushort value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned16(value));

    public override int GetEncodedSize(byte tagNumber, in ushort value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned16(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in ushort value)
    {
        var length = AsduLength.FromUnsigned16(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        if (length == AsduLength.Unsigned8)
        {
            AsduEncoder.WriteUnsigned8(bytes, (byte)value);
            return;
        }

        AsduEncoder.WriteUnsigned16(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in ushort value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in ushort value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static ushort ReadUnsigned16(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => AsduDecoder.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => AsduDecoder.ReadUnsigned16(bytes),
            _ => throw new AsduException()
        };
    }

    private static ushort Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadUnsigned16(ref bytes);
    }

    public override ushort Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override ushort Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<ushort> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadUnsigned16(ref bytes);
        }
        return default;
    }

    public override Optional<ushort> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override Optional<ushort> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
