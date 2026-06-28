// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _lowLimit = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 1);
        var _highLimit = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
        var _deadband = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange
        {
            TimeDelay = _timeDelay,
            LowLimit = _lowLimit,
            HighLimit = _highLimit,
            Deadband = _deadband
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 1, value.LowLimit);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.HighLimit);
        Asdu.EncodePrimitive<RealCodec, float>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetPrimitiveLength<RealCodec, float>(1, value.LowLimit) + Asdu.GetPrimitiveLength<RealCodec, float>(2, value.HighLimit) + Asdu.GetPrimitiveLength<RealCodec, float>(3, value.Deadband);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
