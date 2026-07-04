// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SpecialEventCodec :
    IAsduElementCodec<T::SpecialEvent>,
    IAsduConstructedCodec<T::SpecialEvent>
{
    public static T::SpecialEvent Decode(ref AsduReader reader)
    {
        return new T::SpecialEvent
        {
            Period = AsduElement.Decode<SpecialEventTPeriodCodec, T::SpecialEvent.TPeriod>(ref reader),
            ListOfTimeValues = AsduElement.DecodeSequenceOf<TimeValueCodec, T::TimeValue>(ref reader, 2),
            EventPriority = AsduElement.Decode<SpecialEventTEventPriorityCodec, T::SpecialEvent.TEventPriority>(ref reader, 3)
        };
    }

    public static T::SpecialEvent Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SpecialEventCodec, T::SpecialEvent>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SpecialEvent value)
    {
        AsduElement.Encode<SpecialEventTPeriodCodec, T::SpecialEvent.TPeriod>(ref writer, value.Period);
        AsduElement.EncodeSequenceOf<TimeValueCodec, T::TimeValue>(ref writer, 2, value.ListOfTimeValues);
        AsduElement.Encode<SpecialEventTEventPriorityCodec, T::SpecialEvent.TEventPriority>(ref writer, 3, value.EventPriority);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SpecialEvent value)
        => AsduConstructed.Encode<SpecialEventCodec, T::SpecialEvent>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SpecialEvent value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<SpecialEventTPeriodCodec, T::SpecialEvent.TPeriod>(value.Period);
        length += AsduElement.GetSequenceOfEncodedLength<TimeValueCodec, T::TimeValue>(2, value.ListOfTimeValues);
        length += AsduElement.GetEncodedLength<SpecialEventTEventPriorityCodec, T::SpecialEvent.TEventPriority>(3, value.EventPriority);
        return length;
    }

    public static int GetEncodedLength(in T::SpecialEvent value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SpecialEventCodec, T::SpecialEvent>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return SpecialEventTPeriodCodec.Matches(ref reader);
    }
}
