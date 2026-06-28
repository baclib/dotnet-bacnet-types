// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.PropertyValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.PropertyValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyValue Decode(ref NativeReader reader)
    {
        var _identifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 0);
        var _index = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 1);
        var _value = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 2);
        var _priority = Asdu.DecodeOptional<PropertyValueTPriorityCodec, global::Baclib.Bacnet.Types.Application.PropertyValue.TPriority>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.PropertyValue
        {
            Identifier = _identifier,
            Index = _index,
            Value = _value,
            Priority = _priority
        };
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.PropertyValue value)
    {
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 0, value.Identifier);
        if (value.Index.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.Index.Value);
        }
        Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 2, value.Value);
        if (value.Priority.HasValue)
        {
            Asdu.EncodePrimitive<PropertyValueTPriorityCodec, global::Baclib.Bacnet.Types.Application.PropertyValue.TPriority>(ref writer, 3, value.Priority.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.PropertyValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyValue value)
    {
        return Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(0, value.Identifier) + (value.Index.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.Index.Value) : 0) + Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(2, value.Value) + (value.Priority.HasValue ? Asdu.GetPrimitiveLength<PropertyValueTPriorityCodec, global::Baclib.Bacnet.Types.Application.PropertyValue.TPriority>(3, value.Priority.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
