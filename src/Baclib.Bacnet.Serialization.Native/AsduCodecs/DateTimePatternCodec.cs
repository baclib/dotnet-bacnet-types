// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateTimePatternCodec :
    IAsduElementCodec<T::DateTimePattern>,
    IAsduConstructedCodec<T::DateTimePattern>
{
    public static T::DateTimePattern Decode(ref AsduReader reader)
    {
        return new T::DateTimePattern
        {
            Date = AsduElement.Decode<DatePatternCodec, T::DatePattern>(ref reader),
            Time = AsduElement.Decode<TimePatternCodec, T::TimePattern>(ref reader)
        };
    }

    public static T::DateTimePattern Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DateTimePatternCodec, T::DateTimePattern>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DateTimePattern value)
    {
        AsduElement.Encode<DatePatternCodec, T::DatePattern>(ref writer, value.Date);
        AsduElement.Encode<TimePatternCodec, T::TimePattern>(ref writer, value.Time);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DateTimePattern value)
        => AsduConstructed.Encode<DateTimePatternCodec, T::DateTimePattern>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DateTimePattern value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DatePatternCodec, T::DatePattern>(value.Date);
        length += AsduElement.GetEncodedLength<TimePatternCodec, T::TimePattern>(value.Time);
        return length;
    }

    public static int GetEncodedLength(in T::DateTimePattern value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DateTimePatternCodec, T::DateTimePattern>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DatePatternCodec.Matches(ref reader);
    }
}
