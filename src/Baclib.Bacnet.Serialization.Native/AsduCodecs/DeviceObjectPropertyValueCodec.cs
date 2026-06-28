// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceObjectPropertyValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue Decode(ref NativeReader reader)
    {
        var _deviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _propertyIdentifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 2);
        var _propertyArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 3);
        var _propertyValue = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue
        {
            DeviceIdentifier = _deviceIdentifier,
            ObjectIdentifier = _objectIdentifier,
            PropertyIdentifier = _propertyIdentifier,
            PropertyArrayIndex = _propertyArrayIndex,
            PropertyValue = _propertyValue
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 2, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.PropertyArrayIndex.Value);
        }
        Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 4, value.PropertyValue);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.DeviceIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.ObjectIdentifier) + Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(2, value.PropertyIdentifier) + (value.PropertyArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.PropertyArrayIndex.Value) : 0) + Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(4, value.PropertyValue);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
