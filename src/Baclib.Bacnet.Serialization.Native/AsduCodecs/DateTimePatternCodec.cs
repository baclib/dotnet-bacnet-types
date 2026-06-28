// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateTimePatternCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DateTimePattern>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DateTimePattern>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(DatePatternCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.DateTimePattern Decode(ref NativeReader reader)
    {
        var _date = Asdu.DecodePrimitive<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref reader);
        var _time = Asdu.DecodePrimitive<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.DateTimePattern
        {
            Date = _date,
            Time = _time
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DateTimePattern Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DateTimePattern value)
    {
        Asdu.EncodePrimitive<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref writer, value.Date);
        Asdu.EncodePrimitive<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref writer, value.Time);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DateTimePattern value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateTimePattern value)
    {
        return Asdu.GetEncodedLength<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(value.Date) + Asdu.GetEncodedLength<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(value.Time);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateTimePattern value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
