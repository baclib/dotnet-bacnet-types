// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestTRangeTBySequenceNumberCodec :
    IAsduElementCodec<T::ReadRangeRequest.TRange.TBySequenceNumber>,
    IAsduConstructedCodec<T::ReadRangeRequest.TRange.TBySequenceNumber>
{
    public static T::ReadRangeRequest.TRange.TBySequenceNumber Decode(ref AsduReader reader)
    {
        return new T::ReadRangeRequest.TRange.TBySequenceNumber
        {
            ReferenceSequenceNumber = AsduElement.Decode<UnsignedCodec, uint>(ref reader),
            Count = AsduElement.Decode<Integer16Codec, short>(ref reader)
        };
    }

    public static T::ReadRangeRequest.TRange.TBySequenceNumber Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeRequestTRangeTBySequenceNumberCodec, T::ReadRangeRequest.TRange.TBySequenceNumber>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadRangeRequest.TRange.TBySequenceNumber value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, value.ReferenceSequenceNumber);
        AsduElement.Encode<Integer16Codec, short>(ref writer, value.Count);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadRangeRequest.TRange.TBySequenceNumber value)
        => AsduConstructed.Encode<ReadRangeRequestTRangeTBySequenceNumberCodec, T::ReadRangeRequest.TRange.TBySequenceNumber>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TBySequenceNumber value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(value.ReferenceSequenceNumber);
        length += AsduElement.GetEncodedLength<Integer16Codec, short>(value.Count);
        return length;
    }

    public static int GetEncodedLength(in T::ReadRangeRequest.TRange.TBySequenceNumber value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadRangeRequestTRangeTBySequenceNumberCodec, T::ReadRangeRequest.TRange.TBySequenceNumber>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return UnsignedCodec.Matches(ref reader);
    }
}
