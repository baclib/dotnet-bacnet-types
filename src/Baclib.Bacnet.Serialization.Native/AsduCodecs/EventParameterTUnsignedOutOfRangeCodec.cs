// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTUnsignedOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _lowLimit = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _highLimit = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _deadband = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange
        {
            TimeDelay = _timeDelay,
            LowLimit = _lowLimit,
            HighLimit = _highLimit,
            Deadband = _deadband
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.LowLimit);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.HighLimit);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.LowLimit) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.HighLimit) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.Deadband);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TUnsignedOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
