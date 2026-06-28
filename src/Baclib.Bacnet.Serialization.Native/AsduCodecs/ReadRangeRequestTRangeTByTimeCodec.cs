// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTByTimeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime>
{
    public static bool Matches(ref NativeReader reader)
    {
        return DateTimeCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime Decode(ref NativeReader reader)
    {
        var _referenceTime = Asdu.DecodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader);
        var _count = Asdu.DecodePrimitive<Integer16Codec, short>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime
        {
            ReferenceTime = _referenceTime,
            Count = _count
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, value.ReferenceTime);
        Asdu.EncodePrimitive<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(value.ReferenceTime) + Asdu.GetEncodedLength<Integer16Codec, short>(value.Count);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange.TByTime value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
