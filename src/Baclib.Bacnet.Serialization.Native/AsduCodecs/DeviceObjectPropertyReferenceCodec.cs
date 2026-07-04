// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceObjectPropertyReferenceCodec :
    IAsduElementCodec<T::DeviceObjectPropertyReference>,
    IAsduConstructedCodec<T::DeviceObjectPropertyReference>
{
    public static T::DeviceObjectPropertyReference Decode(ref AsduReader reader)
    {
        return new T::DeviceObjectPropertyReference
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            DeviceIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 3)
        };
    }

    public static T::DeviceObjectPropertyReference Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeviceObjectPropertyReference value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 3, value.DeviceIdentifier);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeviceObjectPropertyReference value)
        => AsduConstructed.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeviceObjectPropertyReference value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(3, value.DeviceIdentifier);
        return length;
    }

    public static int GetEncodedLength(in T::DeviceObjectPropertyReference value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
