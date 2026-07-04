// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateTimeCodec :
    IAsduElementCodec<T::DateTime>,
    IAsduConstructedCodec<T::DateTime>
{
    public static T::DateTime Decode(ref AsduReader reader)
    {
        return new T::DateTime
        {
            Date = AsduElement.Decode<DateCodec, T::Date>(ref reader),
            Time = AsduElement.Decode<TimeCodec, T::Time>(ref reader)
        };
    }

    public static T::DateTime Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DateTimeCodec, T::DateTime>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DateTime value)
    {
        AsduElement.Encode<DateCodec, T::Date>(ref writer, value.Date);
        AsduElement.Encode<TimeCodec, T::Time>(ref writer, value.Time);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DateTime value)
        => AsduConstructed.Encode<DateTimeCodec, T::DateTime>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DateTime value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateCodec, T::Date>(value.Date);
        length += AsduElement.GetEncodedLength<TimeCodec, T::Time>(value.Time);
        return length;
    }

    public static int GetEncodedLength(in T::DateTime value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DateTimeCodec, T::DateTime>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DateCodec.Matches(ref reader);
    }
}
