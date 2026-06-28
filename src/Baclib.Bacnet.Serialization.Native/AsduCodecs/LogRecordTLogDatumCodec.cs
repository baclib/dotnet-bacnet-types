// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogRecordTLogDatumCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _logStatus = Asdu.DecodePrimitive<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromLogStatus(_logStatus);
            case 1:
                var _booleanValue = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromBooleanValue(_booleanValue);
            case 2:
                var _realValue = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromRealValue(_realValue);
            case 3:
                var _enumeratedValue = Asdu.DecodePrimitive<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromEnumeratedValue(_enumeratedValue);
            case 4:
                var _unsignedValue = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromUnsignedValue(_unsignedValue);
            case 5:
                var _integerValue = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromIntegerValue(_integerValue);
            case 6:
                var _bitstringValue = Asdu.DecodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromBitstringValue(_bitstringValue);
            case 7:
                var _nullValue = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromNullValue(_nullValue);
            case 8:
                var _failure = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromFailure(_failure);
            case 9:
                var _timeChange = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromTimeChange(_timeChange);
            case 10:
                var _anyValue = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromAnyValue(_anyValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.LogStatus:
                Asdu.EncodePrimitive<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(ref writer, 0, value.LogStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BooleanValue:
                Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.BooleanValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.RealValue:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.RealValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.EnumeratedValue:
                Asdu.EncodePrimitive<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref writer, 3, value.EnumeratedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.UnsignedValue:
                Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 4, value.UnsignedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.IntegerValue:
                Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 5, value.IntegerValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BitstringValue:
                Asdu.EncodePrimitive<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, 6, value.BitstringValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.NullValue:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 7, value.NullValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.Failure:
                Asdu.EncodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 8, value.Failure);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.TimeChange:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 9, value.TimeChange);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.AnyValue:
                Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 10, value.AnyValue);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.LogStatus:
                return Asdu.GetPrimitiveLength<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(0, value.LogStatus);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BooleanValue:
                return Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.BooleanValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.RealValue:
                return Asdu.GetPrimitiveLength<RealCodec, float>(2, value.RealValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.EnumeratedValue:
                return Asdu.GetPrimitiveLength<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(3, value.EnumeratedValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.UnsignedValue:
                return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(4, value.UnsignedValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.IntegerValue:
                return Asdu.GetPrimitiveLength<IntegerCodec, int>(5, value.IntegerValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BitstringValue:
                return Asdu.GetPrimitiveLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(6, value.BitstringValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.NullValue:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(7, value.NullValue);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.Failure:
                return Asdu.GetConstructedLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(8, value.Failure);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.TimeChange:
                return Asdu.GetPrimitiveLength<RealCodec, float>(9, value.TimeChange);
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.AnyValue:
                return Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(10, value.AnyValue);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}