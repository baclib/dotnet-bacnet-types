// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfDiscreteValueCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfDiscreteValue>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfDiscreteValue>
{
    public static T::EventParameter.TChangeOfDiscreteValue Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfDiscreteValue
        {
            NewValue = AsduElement.Decode<EventParameterTChangeOfDiscreteValueTNewValueCodec, T::EventParameter.TChangeOfDiscreteValue.TNewValue>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::EventParameter.TChangeOfDiscreteValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfDiscreteValueCodec, T::EventParameter.TChangeOfDiscreteValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfDiscreteValue value)
    {
        AsduElement.Encode<EventParameterTChangeOfDiscreteValueTNewValueCodec, T::EventParameter.TChangeOfDiscreteValue.TNewValue>(ref writer, 0, value.NewValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfDiscreteValue value)
        => AsduConstructed.Encode<EventParameterTChangeOfDiscreteValueCodec, T::EventParameter.TChangeOfDiscreteValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfDiscreteValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<EventParameterTChangeOfDiscreteValueTNewValueCodec, T::EventParameter.TChangeOfDiscreteValue.TNewValue>(0, value.NewValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfDiscreteValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfDiscreteValueCodec, T::EventParameter.TChangeOfDiscreteValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
