// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class ObjectIdentifierAsn1Codec : Asn1Codec<ObjectIdentifier>
{
    private ObjectIdentifierAsn1Codec()
    {
    }

    public static readonly ObjectIdentifierAsn1Codec Instance = new();

    public override int GetEncodedSize(in ObjectIdentifier value) => AsduLength.Sum(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);

    public override int GetEncodedSize(byte tagNumber, in ObjectIdentifier value) => AsduLength.Sum(tagNumber, AsduLength.ObjectIdentifier);

    public override void Encode(ref AsduEncoder encoder, in ObjectIdentifier value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        AsduEncoder.WriteObjectIdentifier(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in ObjectIdentifier value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.ObjectIdentifier);
        AsduEncoder.WriteObjectIdentifier(bytes, value);
    }

    public override ObjectIdentifier Decode(ref AsduDecoder decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        return AsduDecoder.ReadObjectIdentifier(bytes);
    }

    public override ObjectIdentifier Decode(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.ObjectIdentifier);
        return AsduDecoder.ReadObjectIdentifier(bytes);
    }

    public override Optional<ObjectIdentifier> DecodeOptional(ref AsduDecoder decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadObjectIdentifier(bytes);
        }
        return default;
    }

    public override Optional<ObjectIdentifier> DecodeOptional(ref AsduDecoder decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.ObjectIdentifier);
        if (!bytes.IsEmpty)
        {
            return AsduDecoder.ReadObjectIdentifier(bytes);
        }
        return default;
    }
}
