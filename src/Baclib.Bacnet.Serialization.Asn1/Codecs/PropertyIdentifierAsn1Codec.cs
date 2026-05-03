// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class PropertyIdentifierAsn1Codec : Asn1CodecBase<PropertyIdentifier>
{
    public static readonly PropertyIdentifierAsn1Codec Instance = new();

    private PropertyIdentifierAsn1Codec()
    {
    }

    public override int GetEncodedSize(in PropertyIdentifier value)
    {
        int dataLength = AsduLength.FromUnsigned32((uint)value);
        return 1 + dataLength;
    }

    public override int GetEncodedSize(byte contextTagNumber, in PropertyIdentifier value)
    {
        int dataLength = AsduLength.FromUnsigned32((uint)value);
        int tagHeaderLength = contextTagNumber < 15 ? 1 : 2;
        return tagHeaderLength + dataLength;
    }

    public override void Encode(ref AsduEncoder encoder, in PropertyIdentifier value)
    {
        encoder.WriteEnumerated((Enumerated)(uint)value);
    }

    public override void Encode(ref AsduEncoder encoder, byte contextTagNumber, in PropertyIdentifier value)
    {
        encoder.WriteEnumerated(contextTagNumber, (Enumerated)(uint)value);
    }

    public override PropertyIdentifier Decode(ref AsduDecoder decoder)
    {
        return (PropertyIdentifier)0;// decoder.DecodeEnumerated32();
    }

    public override PropertyIdentifier Decode(ref AsduDecoder decoder, byte contextTagNumber)
    {
        return (PropertyIdentifier)0;// decoder.DecodeEnumerated32();
    }

    public override Optional<PropertyIdentifier> DecodeOptional(ref AsduDecoder decoder)
    {
        throw new NotImplementedException();
    }

    public override Optional<PropertyIdentifier> DecodeOptional(ref AsduDecoder decoder, byte contextTagNumber)
    {
        throw new NotImplementedException();
    }
}
