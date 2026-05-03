// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class DoubleAsn1Codec : Asn1CodecBase<double>
{
    private DoubleAsn1Codec()
    {
    }

    public static readonly DoubleAsn1Codec Instance = new();

    public override int GetEncodedSize(in double value) => AsduLength.Sum(ApplicationTagNumber.Double, AsduLength.Double);

    public override int GetEncodedSize(byte tagNumber, in double value) => AsduLength.Sum(tagNumber, AsduLength.Double);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in double value)
    {
        var bytes = encoder.Encode(tagNumber, tagClass, AsduLength.Double);
        AsduPrimitives.WriteDouble(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in double value) => Encode(ref encoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in double value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static double Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Double)
        {
            throw new AsduException();
        }

        return AsduPrimitives.ReadDouble(bytes);
    }

    public override double Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application);

    public override double Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<double> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Double)
            {
                throw new AsduException();
            }

            return AsduPrimitives.ReadDouble(bytes);
        }

        return default;
    }

    public override Optional<double> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Double, AsduTagClass.Application);

    public override Optional<double> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
