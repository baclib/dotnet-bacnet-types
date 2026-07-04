// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccumulatorRecordCodec :
    IAsduElementCodec<T::AccumulatorRecord>,
    IAsduConstructedCodec<T::AccumulatorRecord>
{
    public static T::AccumulatorRecord Decode(ref AsduReader reader)
    {
        return new T::AccumulatorRecord
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            PresentValue = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            AccumulatedValue = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            AccumulatorStatus = AsduElement.Decode<AccumulatorRecordTAccumulatorStatusCodec, T::AccumulatorRecord.TAccumulatorStatus>(ref reader, 3)
        };
    }

    public static T::AccumulatorRecord Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AccumulatorRecordCodec, T::AccumulatorRecord>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AccumulatorRecord value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.PresentValue);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.AccumulatedValue);
        AsduElement.Encode<AccumulatorRecordTAccumulatorStatusCodec, T::AccumulatorRecord.TAccumulatorStatus>(ref writer, 3, value.AccumulatorStatus);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AccumulatorRecord value)
        => AsduConstructed.Encode<AccumulatorRecordCodec, T::AccumulatorRecord>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AccumulatorRecord value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.PresentValue);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.AccumulatedValue);
        length += AsduElement.GetEncodedLength<AccumulatorRecordTAccumulatorStatusCodec, T::AccumulatorRecord.TAccumulatorStatus>(3, value.AccumulatorStatus);
        return length;
    }

    public static int GetEncodedLength(in T::AccumulatorRecord value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AccumulatorRecordCodec, T::AccumulatorRecord>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
