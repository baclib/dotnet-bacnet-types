// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Integer8Asn1Codec : Asn1Codec<sbyte>
{
    private Integer8Asn1Codec()
    {
    }

    public static readonly Integer8Asn1Codec Instance = new();

    public override int GetEncodedSize(in sbyte value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger8(value));

    public override int GetEncodedSize(byte tagNumber, in sbyte value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger8(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in sbyte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Signed8);
        AsduEncoder.WriteInteger8(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in sbyte value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in sbyte value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static sbyte Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Signed8)
        {
            throw new AsduException();
        }
        return AsduDecoder.ReadInteger8(bytes);
    }

    public override sbyte Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override sbyte Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<sbyte> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Signed8)
            {
                throw new AsduException();
            }
            return AsduDecoder.ReadInteger8(bytes);
        }
        return default;
    }

    public override Optional<sbyte> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override Optional<sbyte> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
