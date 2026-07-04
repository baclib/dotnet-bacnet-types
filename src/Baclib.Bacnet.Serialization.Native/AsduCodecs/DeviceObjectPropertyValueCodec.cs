// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceObjectPropertyValueCodec :
    IAsduElementCodec<T::DeviceObjectPropertyValue>,
    IAsduConstructedCodec<T::DeviceObjectPropertyValue>
{
    public static T::DeviceObjectPropertyValue Decode(ref AsduReader reader)
    {
        return new T::DeviceObjectPropertyValue
        {
            DeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 2),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3),
            PropertyValue = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 4)
        };
    }

    public static T::DeviceObjectPropertyValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeviceObjectPropertyValueCodec, T::DeviceObjectPropertyValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeviceObjectPropertyValue value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 2, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.PropertyArrayIndex);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 4, value.PropertyValue);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeviceObjectPropertyValue value)
        => AsduConstructed.Encode<DeviceObjectPropertyValueCodec, T::DeviceObjectPropertyValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeviceObjectPropertyValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(2, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(4, value.PropertyValue);
        return length;
    }

    public static int GetEncodedLength(in T::DeviceObjectPropertyValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeviceObjectPropertyValueCodec, T::DeviceObjectPropertyValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
