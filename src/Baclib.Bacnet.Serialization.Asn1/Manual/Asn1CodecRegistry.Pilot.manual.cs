// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1;

public static partial class Asn1CodecRegistry
{
    static partial void RegisterGenerated(IDictionary<Type, IAsn1CodecUntyped> codecs)
    {
        codecs[typeof(bool)] = Baclib.Bacnet.Serialization.Asn1.Codecs.BooleanAsn1Codec.Instance;
        codecs[typeof(sbyte)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Integer8Asn1Codec.Instance;
        codecs[typeof(short)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Integer16Asn1Codec.Instance;
        codecs[typeof(int)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Integer32Asn1Codec.Instance;
        codecs[typeof(long)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Integer64Asn1Codec.Instance;
        codecs[typeof(byte)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Unsigned8Asn1Codec.Instance;
        codecs[typeof(ushort)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Unsigned16Asn1Codec.Instance;
        codecs[typeof(uint)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Unsigned32Asn1Codec.Instance;
        codecs[typeof(ulong)] = Baclib.Bacnet.Serialization.Asn1.Codecs.Unsigned64Asn1Codec.Instance;
        codecs[typeof(float)] = Baclib.Bacnet.Serialization.Asn1.Codecs.RealAsn1Codec.Instance;
        codecs[typeof(double)] = Baclib.Bacnet.Serialization.Asn1.Codecs.DoubleAsn1Codec.Instance;
        codecs[typeof(OctetString)] = Baclib.Bacnet.Serialization.Asn1.Codecs.OctetStringAsn1Codec.Instance;
        codecs[typeof(CharacterString)] = Baclib.Bacnet.Serialization.Asn1.Codecs.CharacterStringAsn1Codec.Instance;
        codecs[typeof(BitString8)] = Baclib.Bacnet.Serialization.Asn1.Codecs.BitString8Asn1Codec.Instance;
        codecs[typeof(BitString16)] = Baclib.Bacnet.Serialization.Asn1.Codecs.BitString16Asn1Codec.Instance;
        codecs[typeof(BitString32)] = Baclib.Bacnet.Serialization.Asn1.Codecs.BitString32Asn1Codec.Instance;
        codecs[typeof(BitString64)] = Baclib.Bacnet.Serialization.Asn1.Codecs.BitString64Asn1Codec.Instance;
        codecs[typeof(PropertyIdentifier)] = Baclib.Bacnet.Serialization.Asn1.Codecs.PropertyIdentifierAsn1Codec.Instance;
        codecs[typeof(ObjectIdentifier)] = Baclib.Bacnet.Serialization.Asn1.Codecs.ObjectIdentifierAsn1Codec.Instance;
        codecs[typeof(DeviceObjectPropertyReference)] = Baclib.Bacnet.Serialization.Asn1.Codecs.DeviceObjectPropertyReferenceAsn1Codec.Instance;
        codecs[typeof(DatePattern)] = Baclib.Bacnet.Serialization.Asn1.Codecs.DatePatternAsn1Codec.Instance;
        codecs[typeof(TimePattern)] = Baclib.Bacnet.Serialization.Asn1.Codecs.TimePatternAsn1Codec.Instance;
    }
}
