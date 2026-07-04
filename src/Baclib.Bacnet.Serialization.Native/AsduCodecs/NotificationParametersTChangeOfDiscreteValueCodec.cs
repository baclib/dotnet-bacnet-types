// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfDiscreteValueCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfDiscreteValue>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfDiscreteValue>
{
    public static T::NotificationParameters.TChangeOfDiscreteValue Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfDiscreteValue
        {
            NewValue = AsduElement.Decode<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, T::NotificationParameters.TChangeOfDiscreteValue.TNewValue>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::NotificationParameters.TChangeOfDiscreteValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfDiscreteValueCodec, T::NotificationParameters.TChangeOfDiscreteValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfDiscreteValue value)
    {
        AsduElement.Encode<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, T::NotificationParameters.TChangeOfDiscreteValue.TNewValue>(ref writer, 0, value.NewValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfDiscreteValue value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfDiscreteValueCodec, T::NotificationParameters.TChangeOfDiscreteValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfDiscreteValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, T::NotificationParameters.TChangeOfDiscreteValue.TNewValue>(0, value.NewValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfDiscreteValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfDiscreteValueCodec, T::NotificationParameters.TChangeOfDiscreteValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
