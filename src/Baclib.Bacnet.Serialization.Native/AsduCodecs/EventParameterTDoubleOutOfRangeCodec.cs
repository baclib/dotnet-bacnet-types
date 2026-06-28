// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTDoubleOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _lowLimit = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 1);
        var _highLimit = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 2);
        var _deadband = Asdu.DecodePrimitive<DoubleCodec, double>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange
        {
            TimeDelay = _timeDelay,
            LowLimit = _lowLimit,
            HighLimit = _highLimit,
            Deadband = _deadband
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 1, value.LowLimit);
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 2, value.HighLimit);
        Asdu.EncodePrimitive<DoubleCodec, double>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetPrimitiveLength<DoubleCodec, double>(1, value.LowLimit) + Asdu.GetPrimitiveLength<DoubleCodec, double>(2, value.HighLimit) + Asdu.GetPrimitiveLength<DoubleCodec, double>(3, value.Deadband);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TDoubleOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
