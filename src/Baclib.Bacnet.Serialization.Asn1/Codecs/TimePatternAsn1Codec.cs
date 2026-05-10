// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class TimePatternAsn1Codec : Asn1Codec<TimePattern>
{
    private TimePatternAsn1Codec()
    {
    }

    public static readonly TimePatternAsn1Codec Instance = new();

    public override int GetEncodedSize(in TimePattern value) => AsduLength.Sum(ApplicationTagNumber.Time, AsduLength.Time);

    public override int GetEncodedSize(byte tagNumber, in TimePattern value) => AsduLength.Sum(tagNumber, AsduLength.Time);

    public override void Encode(ref AsduEncoder encoder, in TimePattern value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.Time, AsduLength.Time);
        AsduEncoder.WriteTimePattern(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in TimePattern value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Time);
        AsduEncoder.WriteTimePattern(bytes, value);
    }

    public override TimePattern Decode(ref AsduDecoder decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.Time, AsduLength.Time);
        return AsduDecoder.ReadTimePattern(bytes);
    }

    public override TimePattern Decode(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Time);
        return AsduDecoder.ReadTimePattern(bytes);
    }

    public override Optional<TimePattern> DecodeOptional(ref AsduDecoder decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.Time, AsduLength.Time);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadTimePattern(bytes);
        }
        return default;
    }

    public override Optional<TimePattern> DecodeOptional(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Time);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadTimePattern(bytes);
        }
        return default;
    }
}
