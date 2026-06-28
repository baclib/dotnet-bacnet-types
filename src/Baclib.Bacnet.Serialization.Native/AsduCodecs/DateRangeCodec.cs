// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DateRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DateRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DateRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(DateCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.DateRange Decode(ref NativeReader reader)
    {
        var _startDate = Asdu.DecodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref reader);
        var _endDate = Asdu.DecodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.DateRange
        {
            StartDate = _startDate,
            EndDate = _endDate
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DateRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DateRange value)
    {
        Asdu.EncodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref writer, value.StartDate);
        Asdu.EncodePrimitive<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref writer, value.EndDate);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DateRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateRange value)
    {
        return Asdu.GetEncodedLength<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(value.StartDate) + Asdu.GetEncodedLength<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(value.EndDate);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DateRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
