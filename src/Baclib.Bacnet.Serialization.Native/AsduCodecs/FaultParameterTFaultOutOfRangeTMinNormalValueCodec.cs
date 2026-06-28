// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultOutOfRangeTMinNormalValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Real:
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Double:
            case ApplicationTagNumber.Signed:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(RealCodec.TagNumber))
        {
            //var _real = Asdu.Decode<RealCodec, float>(ref reader);
            var _real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromReal(_real);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromUnsigned(_unsigned);
        }
        // info
        if (reader.PeekTag(DoubleCodec.TagNumber))
        {
            //var _double = Asdu.Decode<DoubleCodec, double>(ref reader);
            var _double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromDouble(_double);
        }
        // info
        if (reader.PeekTag(IntegerCodec.TagNumber))
        {
            //var _integer = Asdu.Decode<IntegerCodec, int>(ref reader);
            var _integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromInteger(_integer);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Real:
                //Asdu.Encode<RealCodec, float>(ref writer, value.Real);
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Double:
                //Asdu.Encode<DoubleCodec, double>(ref writer, value.Double);
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Integer:
                //Asdu.Encode<IntegerCodec, int>(ref writer, value.Integer);
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Real:
                return Asdu.GetEncodedLength<RealCodec, float>(value.Real);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Double:
                return Asdu.GetEncodedLength<DoubleCodec, double>(value.Double);
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Integer:
                return Asdu.GetEncodedLength<IntegerCodec, int>(value.Integer);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}