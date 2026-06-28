// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SpecialEventTPeriodCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _calendarEntry = Asdu.DecodeConstructed<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.FromCalendarEntry(_calendarEntry);
            case 1:
                var _calendarReference = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.FromCalendarReference(_calendarReference);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarEntry:
                Asdu.EncodeConstructed<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(ref writer, 0, value.CalendarEntry);
                return;
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarReference:
                Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.CalendarReference);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarEntry:
                return Asdu.GetConstructedLength<CalendarEntryCodec, global::Baclib.Bacnet.Types.Application.CalendarEntry>(0, value.CalendarEntry);
            case global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod.Option.CalendarReference:
                return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.CalendarReference);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}