// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ActionCommandCodec :
    IAsduElementCodec<T::ActionCommand>,
    IAsduConstructedCodec<T::ActionCommand>
{
    public static T::ActionCommand Decode(ref AsduReader reader)
    {
        return new T::ActionCommand
        {
            DeviceIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 2),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3),
            PropertyValue = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 4),
            Priority = AsduElement.DecodeOptional<ActionCommandTPriorityCodec, T::ActionCommand.TPriority>(ref reader, 5),
            PostDelay = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 6),
            QuitOnFailure = AsduElement.Decode<BooleanCodec, bool>(ref reader, 7),
            WriteSuccessful = AsduElement.Decode<BooleanCodec, bool>(ref reader, 8)
        };
    }

    public static T::ActionCommand Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ActionCommandCodec, T::ActionCommand>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ActionCommand value)
    {
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.DeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 2, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.PropertyArrayIndex);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 4, value.PropertyValue);
        AsduElement.EncodeOptional<ActionCommandTPriorityCodec, T::ActionCommand.TPriority>(ref writer, 5, value.Priority);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 6, value.PostDelay);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 7, value.QuitOnFailure);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 8, value.WriteSuccessful);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ActionCommand value)
        => AsduConstructed.Encode<ActionCommandCodec, T::ActionCommand>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ActionCommand value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(2, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(4, value.PropertyValue);
        length += AsduElement.GetOptionalEncodedLength<ActionCommandTPriorityCodec, T::ActionCommand.TPriority>(5, value.Priority);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(6, value.PostDelay);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(7, value.QuitOnFailure);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(8, value.WriteSuccessful);
        return length;
    }

    public static int GetEncodedLength(in T::ActionCommand value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ActionCommandCodec, T::ActionCommand>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        return reader.PeekContextTag(1);
    }
}
