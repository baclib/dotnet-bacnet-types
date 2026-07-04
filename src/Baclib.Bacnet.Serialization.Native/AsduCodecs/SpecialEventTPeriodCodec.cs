// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SpecialEventTPeriodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @calendarEntry = CalendarEntryCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.FromCalendarEntry(@calendarEntry);
            case 1:
                var @calendarReference = ObjectIdentifierCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.FromCalendarReference(@calendarReference);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarEntry:
                CalendarEntryCodec.Encode(ref writer, 0, value.CalendarEntry);
                return;
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarReference:
                ObjectIdentifierCodec.Encode(ref writer, 1, value.CalendarReference);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
        => AsduConstructed.Encode<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarEntry
                => CalendarEntryCodec.GetEncodedLength(value.CalendarEntry, 0),
            global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarReference
                => ObjectIdentifierCodec.GetEncodedLength(value.CalendarReference, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value, byte tagNumber)
        => AsduElement.GetEncodedLength<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(tagNumber, value);
}
