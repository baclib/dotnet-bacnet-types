// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTByPositionCodec :
    IAsduElementCodec<T::ReadRangeRequest.TRange.TByPosition>,
    IAsduConstructedCodec<T::ReadRangeRequest.TRange.TByPosition>
{
    public static T::ReadRangeRequest.TRange.TByPosition Decode(ref AsduReader reader)
    {
        return new T::ReadRangeRequest.TRange.TByPosition
        {
            ReferenceIndex = AsduElement.Decode<UnsignedCodec, uint>(ref reader),
            Count = AsduElement.Decode<Integer16Codec, short>(ref reader)
        };
    }

    public static T::ReadRangeRequest.TRange.TByPosition Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeRequestTRangeTByPositionCodec, T::ReadRangeRequest.TRange.TByPosition>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadRangeRequest.TRange.TByPosition value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.ReferenceIndex);
        AsduElement.Encode<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadRangeRequest.TRange.TByPosition value)
        => AsduConstructed.Encode<ReadRangeRequestTRangeTByPositionCodec, T::ReadRangeRequest.TRange.TByPosition>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TByPosition value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.ReferenceIndex);
        length += AsduElement.GetEncodedLength<Integer16Codec, short>(value.Count);
        return length;
    }

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TByPosition value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadRangeRequestTRangeTByPositionCodec, T::ReadRangeRequest.TRange.TByPosition>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return UnsignedCodec.Matches(ref reader);
    }
}
