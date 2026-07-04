// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogRecordTLogDatumCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 or
            3 or
            4 or
            5 or
            6 or
            7 or
            8 or
            9 or
            10 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @logStatus = LogStatusCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromLogStatus(@logStatus);
            case 1:
                var @booleanValue = BooleanCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromBooleanValue(@booleanValue);
            case 2:
                var @realValue = RealCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromRealValue(@realValue);
            case 3:
                var @enumeratedValue = EnumeratedCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromEnumeratedValue(@enumeratedValue);
            case 4:
                var @unsignedValue = UnsignedCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromUnsignedValue(@unsignedValue);
            case 5:
                var @integerValue = IntegerCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromIntegerValue(@integerValue);
            case 6:
                var @bitstringValue = BitStringCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromBitstringValue(@bitstringValue);
            case 7:
                var @nullValue = NullCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromNullValue(@nullValue);
            case 8:
                var @failure = ErrorCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromFailure(@failure);
            case 9:
                var @timeChange = RealCodec.Decode(ref reader, 9);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromTimeChange(@timeChange);
            case 10:
                var @anyValue = AnyCodec.Decode(ref reader, 10);
                return global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.FromAnyValue(@anyValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.LogStatus:
                LogStatusCodec.Encode(ref writer, 0, value.LogStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BooleanValue:
                BooleanCodec.Encode(ref writer, 1, value.BooleanValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.RealValue:
                RealCodec.Encode(ref writer, 2, value.RealValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.EnumeratedValue:
                EnumeratedCodec.Encode(ref writer, 3, value.EnumeratedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.UnsignedValue:
                UnsignedCodec.Encode(ref writer, 4, value.UnsignedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.IntegerValue:
                IntegerCodec.Encode(ref writer, 5, value.IntegerValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BitstringValue:
                BitStringCodec.Encode(ref writer, 6, value.BitstringValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.NullValue:
                NullCodec.Encode(ref writer, 7, value.NullValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.Failure:
                ErrorCodec.Encode(ref writer, 8, value.Failure);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.TimeChange:
                RealCodec.Encode(ref writer, 9, value.TimeChange);
                return;
            case global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.AnyValue:
                AnyCodec.Encode(ref writer, 10, value.AnyValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
        => AsduConstructed.Encode<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.LogStatus
                => LogStatusCodec.GetEncodedLength(value.LogStatus, 0),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BooleanValue
                => BooleanCodec.GetEncodedLength(value.BooleanValue, 1),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.RealValue
                => RealCodec.GetEncodedLength(value.RealValue, 2),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.EnumeratedValue
                => EnumeratedCodec.GetEncodedLength(value.EnumeratedValue, 3),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.UnsignedValue
                => UnsignedCodec.GetEncodedLength(value.UnsignedValue, 4),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.IntegerValue
                => IntegerCodec.GetEncodedLength(value.IntegerValue, 5),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.BitstringValue
                => BitStringCodec.GetEncodedLength(value.BitstringValue, 6),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.NullValue
                => NullCodec.GetEncodedLength(value.NullValue, 7),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.Failure
                => ErrorCodec.GetEncodedLength(value.Failure, 8),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.TimeChange
                => RealCodec.GetEncodedLength(value.TimeChange, 9),
            global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum.Option.AnyValue
                => AnyCodec.GetEncodedLength(value.AnyValue, 10),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum value, byte tagNumber)
        => AsduElement.GetEncodedLength<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(tagNumber, value);
}
