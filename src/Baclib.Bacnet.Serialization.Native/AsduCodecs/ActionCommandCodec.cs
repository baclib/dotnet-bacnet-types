// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ActionCommandCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ActionCommand>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ActionCommand>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)1);
    }

    public static global::Baclib.Bacnet.Types.Application.ActionCommand Decode(ref NativeReader reader)
    {
        var _deviceIdentifier = Asdu.DecodeOptional<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _propertyIdentifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 2);
        var _propertyArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 3);
        var _propertyValue = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 4);
        var _priority = Asdu.DecodeOptional<ActionCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.ActionCommand.TPriority>(ref reader, 5);
        var _postDelay = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 6);
        var _quitOnFailure = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 7);
        var _writeSuccessful = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 8);

        return new global::Baclib.Bacnet.Types.Application.ActionCommand
        {
            DeviceIdentifier = _deviceIdentifier,
            ObjectIdentifier = _objectIdentifier,
            PropertyIdentifier = _propertyIdentifier,
            PropertyArrayIndex = _propertyArrayIndex,
            PropertyValue = _propertyValue,
            Priority = _priority,
            PostDelay = _postDelay,
            QuitOnFailure = _quitOnFailure,
            WriteSuccessful = _writeSuccessful
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ActionCommand Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ActionCommand value)
    {
        if (value.DeviceIdentifier.HasValue)
        {
            Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier.Value);
        }
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 2, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.PropertyArrayIndex.Value);
        }
        Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 4, value.PropertyValue);
        if (value.Priority.HasValue)
        {
            Asdu.EncodePrimitive<ActionCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.ActionCommand.TPriority>(ref writer, 5, value.Priority.Value);
        }
        if (value.PostDelay.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 6, value.PostDelay.Value);
        }
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 7, value.QuitOnFailure);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 8, value.WriteSuccessful);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ActionCommand value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ActionCommand value)
    {
        return (value.DeviceIdentifier.HasValue ? Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.DeviceIdentifier.Value) : 0) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.ObjectIdentifier) + Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(2, value.PropertyIdentifier) + (value.PropertyArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.PropertyArrayIndex.Value) : 0) + Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(4, value.PropertyValue) + (value.Priority.HasValue ? Asdu.GetPrimitiveLength<ActionCommandTPriorityCodec, global::Baclib.Bacnet.Types.Application.ActionCommand.TPriority>(5, value.Priority.Value) : 0) + (value.PostDelay.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(6, value.PostDelay.Value) : 0) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(7, value.QuitOnFailure) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(8, value.WriteSuccessful);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ActionCommand value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
