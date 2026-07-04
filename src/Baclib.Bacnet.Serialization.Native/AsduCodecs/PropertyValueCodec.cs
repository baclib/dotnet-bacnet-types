// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyValueCodec :
    IAsduElementCodec<T::PropertyValue>,
    IAsduConstructedCodec<T::PropertyValue>
{
    public static T::PropertyValue Decode(ref AsduReader reader)
    {
        return new T::PropertyValue
        {
            Identifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 0),
            Index = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 1),
            Value = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 2),
            Priority = AsduElement.DecodeOptional<PropertyValueTPriorityCodec, T::PropertyValue.TPriority>(ref reader, 3)
        };
    }

    public static T::PropertyValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PropertyValueCodec, T::PropertyValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::PropertyValue value)
    {
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 0, value.Identifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 1, value.Index);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 2, value.Value);
        AsduElement.EncodeOptional<PropertyValueTPriorityCodec, T::PropertyValue.TPriority>(ref writer, 3, value.Priority);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::PropertyValue value)
        => AsduConstructed.Encode<PropertyValueCodec, T::PropertyValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::PropertyValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(0, value.Identifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(1, value.Index);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(2, value.Value);
        length += AsduElement.GetOptionalEncodedLength<PropertyValueTPriorityCodec, T::PropertyValue.TPriority>(3, value.Priority);
        return length;
    }

    public static int GetEncodedLength(in T::PropertyValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<PropertyValueCodec, T::PropertyValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
