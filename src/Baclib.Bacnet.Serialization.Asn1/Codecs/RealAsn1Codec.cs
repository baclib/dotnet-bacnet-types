// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class RealAsn1Codec : Asn1CodecBase<float>
{
    private RealAsn1Codec()
    {
    }

    public static readonly RealAsn1Codec Instance = new();

    public override int GetEncodedSize(in float value) => AsduLength.Sum(ApplicationTagNumber.Real, AsduLength.Real);

    public override int GetEncodedSize(byte tagNumber, in float value) => AsduLength.Sum(tagNumber, AsduLength.Real);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in float value)
    {
        var bytes = encoder.Encode(tagNumber, tagClass, AsduLength.Real);
        AsduPrimitives.WriteReal(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in float value) => Encode(ref encoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in float value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static float Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Real)
        {
            throw new AsduException();
        }

        return AsduPrimitives.ReadReal(bytes);
    }

    public override float Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application);

    public override float Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<float> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Real)
            {
                throw new AsduException();
            }

            return AsduPrimitives.ReadReal(bytes);
        }

        return default;
    }

    public override Optional<float> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Real, AsduTagClass.Application);

    public override Optional<float> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
