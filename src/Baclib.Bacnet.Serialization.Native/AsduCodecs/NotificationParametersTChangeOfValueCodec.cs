// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfValueCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfValue>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfValue>
{
    public static T::NotificationParameters.TChangeOfValue Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfValue
        {
            NewValue = AsduElement.Decode<NotificationParametersTChangeOfValueTNewValueCodec, T::NotificationParameters.TChangeOfValue.TNewValue>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::NotificationParameters.TChangeOfValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfValueCodec, T::NotificationParameters.TChangeOfValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfValue value)
    {
        AsduElement.Encode<NotificationParametersTChangeOfValueTNewValueCodec, T::NotificationParameters.TChangeOfValue.TNewValue>(ref writer, 0, value.NewValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfValue value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfValueCodec, T::NotificationParameters.TChangeOfValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<NotificationParametersTChangeOfValueTNewValueCodec, T::NotificationParameters.TChangeOfValue.TNewValue>(0, value.NewValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfValueCodec, T::NotificationParameters.TChangeOfValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
