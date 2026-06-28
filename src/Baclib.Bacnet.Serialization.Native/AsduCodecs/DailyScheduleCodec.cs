// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DailyScheduleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DailySchedule>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DailySchedule>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.DailySchedule Decode(ref NativeReader reader)
    {
        var _daySchedule = Asdu.DecodeSequenceOf<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(ref reader, 0);

        return new global::Baclib.Bacnet.Types.Application.DailySchedule
        {
            DaySchedule = _daySchedule
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DailySchedule Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DailySchedule value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.DaySchedule)
        {
            Asdu.EncodeElement<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DailySchedule value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DailySchedule value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.DaySchedule.Items.Sum(static item => Asdu.GetElementLength<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(0, item))) + AsduLength.FromTagNumber((byte)0));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DailySchedule value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
