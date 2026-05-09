// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

/*
public sealed class DeviceObjectPropertyReferenceAsn1Codec : Asn1CodecBase<DeviceObjectPropertyReference>
{
    public static readonly DeviceObjectPropertyReferenceAsn1Codec Instance = new();

    private DeviceObjectPropertyReferenceAsn1Codec()
    {
    }

    public IAsn1Codec<ObjectIdentifier> ObjectIdentifierCodec { get; init; } = ObjectIdentifierAsn1Codec.Instance;

    public IAsn1Codec<PropertyIdentifier> PropertyIdentifierCodec { get; init; } = PropertyIdentifierAsn1Codec.Instance;

    public IAsn1Codec<uint> Unsigned32Codec { get; init; } = Unsigned32Asn1Codec.Instance;

    public IAsn1Codec<ObjectIdentifier> DeviceIdentifierCodec { get; init; } = ObjectIdentifierAsn1Codec.Instance;


    public override int GetEncodedSize(in DeviceObjectPropertyReference value)
    {
        int size = 0;

        size += 1 + AsduLength.ObjectIdentifier; // [0] object-identifier
        size += 1 + AsduLength.FromUnsigned32((uint)value.PropertyIdentifier); // [1] property-identifier (enumerated)

        if (value.PropertyArrayIndex.HasValue)
        {
            size += 1 + AsduLength.FromUnsigned32(value.PropertyArrayIndex.Value); // [2] property-array-index
        }

        if (value.DeviceIdentifier.HasValue)
        {
            size += 1 + AsduLength.ObjectIdentifier; // [3] device-identifier
        }

        return size;
    }

    public override int GetEncodedSize(byte contextTagNumber, in DeviceObjectPropertyReference value)
    {
        int enclosingTagLength = contextTagNumber < 15 ? 1 : 2;
        return enclosingTagLength + GetEncodedSize(in value) + enclosingTagLength;
    }

    public override void Encode(ref AsduEncoder encoder, in DeviceObjectPropertyReference value)
    {
        ObjectIdentifierAsn1Codec.Instance.Encode(ref encoder, 0, value.ObjectIdentifier);
        PropertyIdentifierAsn1Codec.Instance.Encode(ref encoder, 1, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Unsigned32Asn1Codec.Instance.Encode(ref encoder, 2, value.PropertyArrayIndex.Value);
        }
        if (value.DeviceIdentifier.HasValue)
        {
            ObjectIdentifierAsn1Codec.Instance.Encode(ref encoder, 3, value.DeviceIdentifier.Value);
        }
    }

    public override void Encode(ref AsduEncoder encoder, byte contextTagNumber, in DeviceObjectPropertyReference value)
    {
        encoder.WriteOpeningTag(contextTagNumber);
        Encode(ref encoder, in value);
        encoder.WriteClosingTag(contextTagNumber);
    }

    public override DeviceObjectPropertyReference Decode(ref AsduDecoder decoder)
    {
        var objectIdentifier = ObjectIdentifierCodec.Decode(ref decoder, 0);
        var propertyIdentifier = PropertyIdentifierCodec.Decode(ref decoder, 1);
        var propertyArrayIndex = Unsigned32Codec.DecodeOptional(ref decoder, 2);
        var deviceIdentifier = DeviceIdentifierCodec.Decode(ref decoder, 3);

        return new DeviceObjectPropertyReference
        {
            ObjectIdentifier = objectIdentifier,
            PropertyIdentifier = propertyIdentifier,
            PropertyArrayIndex = propertyArrayIndex,
            DeviceIdentifier = deviceIdentifier
        };
    }

    public override DeviceObjectPropertyReference Decode(ref AsduDecoder decoder, byte contextTagNumber)
    {
        decoder.DecodeOpeningTag(contextTagNumber);
        DeviceObjectPropertyReference value = Decode(ref decoder);
        decoder.DecodeClosingTag(contextTagNumber);
        return value;
    }

    public override Optional<DeviceObjectPropertyReference> DecodeOptional(ref AsduDecoder decoder)
    {
        throw new NotImplementedException();
    }

    public override Optional<DeviceObjectPropertyReference> DecodeOptional(ref AsduDecoder decoder, byte contextTagNumber)
    {
        throw new NotImplementedException();
    }
}
*/