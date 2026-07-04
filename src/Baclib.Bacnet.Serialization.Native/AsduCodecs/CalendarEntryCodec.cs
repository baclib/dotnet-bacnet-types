// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CalendarEntryCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CalendarEntry>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CalendarEntry>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CalendarEntry Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @date = DatePatternCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromDate(@date);
            case 1:
                var @dateRange = DateRangeCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromDateRange(@dateRange);
            case 2:
                var @weeknday = WeekNDayCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.CalendarEntry.FromWeeknday(@weeknday);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.CalendarEntry Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Date:
                DatePatternCodec.Encode(ref writer, 0, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.DateRange:
                DateRangeCodec.Encode(ref writer, 1, value.DateRange);
                return;
            case global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Weeknday:
                WeekNDayCodec.Encode(ref writer, 2, value.Weeknday);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
        => AsduConstructed.Encode<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.CalendarEntry value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Date
                => DatePatternCodec.GetEncodedLength(value.Date, 0),
            global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.DateRange
                => DateRangeCodec.GetEncodedLength(value.DateRange, 1),
            global::Baclib.Bacnet.Types.Application.CalendarEntry.Option.Weeknday
                => WeekNDayCodec.GetEncodedLength(value.Weeknday, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.CalendarEntry value, byte tagNumber)
        => AsduElement.GetEncodedLength<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(tagNumber, value);
}
