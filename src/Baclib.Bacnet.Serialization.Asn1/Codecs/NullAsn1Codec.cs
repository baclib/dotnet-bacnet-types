// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class NullAsn1Codec : Asn1CodecBase<Null>
{
    private NullAsn1Codec()
    {
    }

    public static readonly NullAsn1Codec Instance = new();

    public override int GetEncodedSize(in Null value) => AsduLength.Sum(ApplicationTagNumber.Null, AsduLength.Null);

    public override int GetEncodedSize(byte tagNumber, in Null value) => AsduLength.Sum(tagNumber, AsduLength.Null);

    public override void Encode(ref AsduEncoder encoder, in Null _) => encoder.Encode(ApplicationTagNumber.Null, AsduLength.Null);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in Null _) => encoder.Encode(tagNumber, AsduLength.Null);

    public override Null Decode(ref AsduDecoder decoder)
    {
        decoder.Decode(ApplicationTagNumber.Null, AsduLength.Null);
        return Null.Value;
    }

    public override Null Decode(ref AsduDecoder decoder, byte tagNumber)
    {
        decoder.Decode(tagNumber, AsduLength.Null);
        return Null.Value;
    }

    public override Optional<Null> DecodeOptional(ref AsduDecoder decoder)
    {
        return decoder.DecodeOptional(ApplicationTagNumber.Null, out _) ? Null.Value : default;
    }

    public override Optional<Null> DecodeOptional(ref AsduDecoder decoder, byte tagNumber)
    {
        return decoder.DecodeOptional(tagNumber, out _) ? Null.Value : default;
    }
}
