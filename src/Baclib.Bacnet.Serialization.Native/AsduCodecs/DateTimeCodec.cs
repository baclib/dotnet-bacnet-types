// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateTimeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DateTime>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DateTime>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(DateCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.DateTime Decode(ref NativeReader reader)
    {
        var _date = Asdu.DecodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref reader);
        var _time = Asdu.DecodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.DateTime
        {
            Date = _date,
            Time = _time
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DateTime Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DateTime value)
    {
        Asdu.EncodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref writer, value.Date);
        Asdu.EncodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.Time);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DateTime value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateTime value)
    {
        return Asdu.GetEncodedLength<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(value.Date) + Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.Time);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateTime value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
