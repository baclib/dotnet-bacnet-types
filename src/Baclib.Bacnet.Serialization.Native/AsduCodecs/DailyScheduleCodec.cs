// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DailyScheduleCodec :
    IAsduElementCodec<T::DailySchedule>,
    IAsduConstructedCodec<T::DailySchedule>
{
    public static T::DailySchedule Decode(ref AsduReader reader)
    {
        return new T::DailySchedule
        {
            DaySchedule = AsduElement.DecodeSequenceOf<TimeValueCodec, T::TimeValue>(ref reader, 0)
        };
    }

    public static T::DailySchedule Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DailyScheduleCodec, T::DailySchedule>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DailySchedule value)
    {
        AsduElement.EncodeSequenceOf<TimeValueCodec, T::TimeValue>(ref writer, 0, value.DaySchedule);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DailySchedule value)
        => AsduConstructed.Encode<DailyScheduleCodec, T::DailySchedule>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DailySchedule value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<TimeValueCodec, T::TimeValue>(0, value.DaySchedule);
        return length;
    }

    public static int GetEncodedLength(in T::DailySchedule value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DailyScheduleCodec, T::DailySchedule>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
