// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccumulatorRecordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AccumulatorRecord>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AccumulatorRecord>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AccumulatorRecord Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _presentValue = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _accumulatedValue = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _accumulatorStatus = Asdu.DecodePrimitive<AccumulatorRecordTAccumulatorStatusCodec, global::Baclib.Bacnet.Types.Application.AccumulatorRecord.TAccumulatorStatus>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.AccumulatorRecord
        {
            Timestamp = _timestamp,
            PresentValue = _presentValue,
            AccumulatedValue = _accumulatedValue,
            AccumulatorStatus = _accumulatorStatus
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AccumulatorRecord Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AccumulatorRecord value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.PresentValue);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.AccumulatedValue);
        Asdu.EncodePrimitive<AccumulatorRecordTAccumulatorStatusCodec, global::Baclib.Bacnet.Types.Application.AccumulatorRecord.TAccumulatorStatus>(ref writer, 3, value.AccumulatorStatus);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AccumulatorRecord value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccumulatorRecord value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.PresentValue) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.AccumulatedValue) + Asdu.GetPrimitiveLength<AccumulatorRecordTAccumulatorStatusCodec, global::Baclib.Bacnet.Types.Application.AccumulatorRecord.TAccumulatorStatus>(3, value.AccumulatorStatus);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccumulatorRecord value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
