// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class BooleanAsn1Codec : Asn1Codec<bool>
{
    private BooleanAsn1Codec()
    {
    }

    public static readonly BooleanAsn1Codec Instance = new();

    public override int GetEncodedSize(in bool value) => AsduLength.Boolean;

    public override int GetEncodedSize(byte tagNumber, in bool value) => AsduLength.Sum(tagNumber, AsduLength.Boolean);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in double value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Boolean);
        AsduEncoder.WriteDouble(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in bool value)
    {
        encoder.Encode(ApplicationTagNumber.Boolean, value ? 1 : 0);
    }

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in bool value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.Boolean);
        AsduEncoder.WriteBoolean(bytes, value);
    }

    private static bool Convert(int value)
    {
        return value switch
        {
            0 => false,
            1 => true,
            _ => throw new AsduException($"Invalid boolean value: {value}")
        };
    }

    public override bool Decode(ref AsduDecoder decoder)
    {
        var value = decoder.DecodeTag(ApplicationTagNumber.Boolean);
        return Convert(value);
    }

    public override bool Decode(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.Boolean);
        if (bytes.Length != 1)
        {
            throw new AsduException($"Invalid boolean length: {bytes.Length}");
        }
        return Convert(bytes[0]);
    }

    public override Optional<bool> DecodeOptional(ref AsduDecoder decoder)
    {
        if (decoder.DecodeOptionalTag(ApplicationTagNumber.Boolean, out var value))
        {
            return Convert(value);
        }
        return default;
    }

    public override Optional<bool> DecodeOptional(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.Boolean);
        if (!bytes.IsEmpty)
        {
            if (bytes.Length != 1)
            {
                throw new AsduException($"Invalid boolean length: {bytes.Length}");
            }
            return Convert(bytes[0]);
        }
        return default;
    }
}
