// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CalendarEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CalendarEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CalendarEntry>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.CalendarEntry Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _date = Asdu.DecodePrimitive<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromDate(_date);
            case 1:
                var _dateRange = Asdu.DecodeConstructed<DateRangeCodec, global::Baclib.Bacnet.Types.Application.DateRange>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromDateRange(_dateRange);
            case 2:
                var _weeknday = Asdu.DecodePrimitive<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromWeeknday(_weeknday);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.CalendarEntry Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Date:
                Asdu.EncodePrimitive<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref writer, 0, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.DateRange:
                Asdu.EncodeConstructed<DateRangeCodec, global::Baclib.Bacnet.Types.Application.DateRange>(ref writer, 1, value.DateRange);
                return;
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Weeknday:
                Asdu.EncodePrimitive<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref writer, 2, value.Weeknday);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Date:
                return Asdu.GetPrimitiveLength<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(0, value.Date);
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.DateRange:
                return Asdu.GetConstructedLength<DateRangeCodec, global::Baclib.Bacnet.Types.Application.DateRange>(1, value.DateRange);
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Weeknday:
                return Asdu.GetPrimitiveLength<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(2, value.Weeknday);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CalendarEntry value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}