// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateRangeCodec :
    IAsduElementCodec<T::DateRange>,
    IAsduConstructedCodec<T::DateRange>
{
    public static T::DateRange Decode(ref AsduReader reader)
    {
        return new T::DateRange
        {
            StartDate = AsduElement.Decode<DateCodec, T::Date>(ref reader),
            EndDate = AsduElement.Decode<DateCodec, T::Date>(ref reader)
        };
    }

    public static T::DateRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DateRangeCodec, T::DateRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DateRange value)
    {
        AsduElement.Encode<DateCodec, T::Date>(ref writer, value.StartDate);
        AsduElement.Encode<DateCodec, T::Date>(ref writer, value.EndDate);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DateRange value)
        => AsduConstructed.Encode<DateRangeCodec, T::DateRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DateRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateCodec, T::Date>(value.StartDate);
        length += AsduElement.GetEncodedLength<DateCodec, T::Date>(value.EndDate);
        return length;
    }

    public static int GetEncodedLength(in T::DateRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DateRangeCodec, T::DateRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DateCodec.Matches(ref reader);
    }
}
