// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTByTimeCodec :
    IAsduElementCodec<T::ReadRangeRequest.TRange.TByTime>,
    IAsduConstructedCodec<T::ReadRangeRequest.TRange.TByTime>
{
    public static T::ReadRangeRequest.TRange.TByTime Decode(ref AsduReader reader)
    {
        return new T::ReadRangeRequest.TRange.TByTime
        {
            ReferenceTime = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader),
            Count = AsduElement.Decode<Integer16Codec, short>(ref reader)
        };
    }

    public static T::ReadRangeRequest.TRange.TByTime Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeRequestTRangeTByTimeCodec, T::ReadRangeRequest.TRange.TByTime>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadRangeRequest.TRange.TByTime value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, value.ReferenceTime);
        AsduElement.Encode<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadRangeRequest.TRange.TByTime value)
        => AsduConstructed.Encode<ReadRangeRequestTRangeTByTimeCodec, T::ReadRangeRequest.TRange.TByTime>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TByTime value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(value.ReferenceTime);
        length += AsduElement.GetEncodedLength<Integer16Codec, short>(value.Count);
        return length;
    }

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TByTime value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadRangeRequestTRangeTByTimeCodec, T::ReadRangeRequest.TRange.TByTime>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DateTimeCodec.Matches(ref reader);
    }
}
