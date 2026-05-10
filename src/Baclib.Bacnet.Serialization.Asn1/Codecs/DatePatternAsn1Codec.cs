// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class DatePatternAsn1Codec : Asn1Codec<DatePattern>
{
    private DatePatternAsn1Codec()
    {
    }

    public static readonly DatePatternAsn1Codec Instance = new();

    public override int GetEncodedSize(in DatePattern value) => AsduLength.Sum(ApplicationTagNumber.Date, AsduLength.Date);

    public override int GetEncodedSize(byte tagNumber, in DatePattern value) => AsduLength.Sum(tagNumber, AsduLength.Date);

    public override void Encode(ref AsduEncoder encoder, in DatePattern value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.Date, AsduLength.Date);
        AsduEncoder.WriteDatePattern(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in DatePattern value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Date);
        AsduEncoder.WriteDatePattern(bytes, value);
    }

    public override DatePattern Decode(ref AsduDecoder decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.Date, AsduLength.Date);
        return AsduDecoder.ReadDatePattern(bytes);
    }

    public override DatePattern Decode(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Date);
        return AsduDecoder.ReadDatePattern(bytes);
    }

    public override Optional<DatePattern> DecodeOptional(ref AsduDecoder decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.Date, AsduLength.Date);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadDatePattern(bytes);
        }
        return default;
    }

    public override Optional<DatePattern> DecodeOptional(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Date);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadDatePattern(bytes);
        }
        return default;
    }
}
