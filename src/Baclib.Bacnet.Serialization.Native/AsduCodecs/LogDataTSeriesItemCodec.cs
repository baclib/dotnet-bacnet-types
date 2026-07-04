// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogDataTSeriesItemCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem>
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
            8 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @booleanValue = BooleanCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromBooleanValue(@booleanValue);
            case 1:
                var @realValue = RealCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromRealValue(@realValue);
            case 2:
                var @enumeratedValue = EnumeratedCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromEnumeratedValue(@enumeratedValue);
            case 3:
                var @unsignedValue = UnsignedCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromUnsignedValue(@unsignedValue);
            case 4:
                var @integerValue = IntegerCodec.Decode(ref reader, 4);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromIntegerValue(@integerValue);
            case 5:
                var @bitstringValue = BitStringCodec.Decode(ref reader, 5);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromBitstringValue(@bitstringValue);
            case 6:
                var @nullValue = NullCodec.Decode(ref reader, 6);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromNullValue(@nullValue);
            case 7:
                var @failure = ErrorCodec.Decode(ref reader, 7);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromFailure(@failure);
            case 8:
                var @anyValue = AnyCodec.Decode(ref reader, 8);
                return global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.FromAnyValue(@anyValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LogDataTSeriesItemCodec, global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.BooleanValue:
                BooleanCodec.Encode(ref writer, 0, value.BooleanValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.RealValue:
                RealCodec.Encode(ref writer, 1, value.RealValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.EnumeratedValue:
                EnumeratedCodec.Encode(ref writer, 2, value.EnumeratedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.UnsignedValue:
                UnsignedCodec.Encode(ref writer, 3, value.UnsignedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.IntegerValue:
                IntegerCodec.Encode(ref writer, 4, value.IntegerValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.BitstringValue:
                BitStringCodec.Encode(ref writer, 5, value.BitstringValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.NullValue:
                NullCodec.Encode(ref writer, 6, value.NullValue);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.Failure:
                ErrorCodec.Encode(ref writer, 7, value.Failure);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.AnyValue:
                AnyCodec.Encode(ref writer, 8, value.AnyValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem value)
        => AsduConstructed.Encode<LogDataTSeriesItemCodec, global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.BooleanValue
                => BooleanCodec.GetEncodedLength(value.BooleanValue, 0),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.RealValue
                => RealCodec.GetEncodedLength(value.RealValue, 1),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.EnumeratedValue
                => EnumeratedCodec.GetEncodedLength(value.EnumeratedValue, 2),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.UnsignedValue
                => UnsignedCodec.GetEncodedLength(value.UnsignedValue, 3),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.IntegerValue
                => IntegerCodec.GetEncodedLength(value.IntegerValue, 4),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.BitstringValue
                => BitStringCodec.GetEncodedLength(value.BitstringValue, 5),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.NullValue
                => NullCodec.GetEncodedLength(value.NullValue, 6),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.Failure
                => ErrorCodec.GetEncodedLength(value.Failure, 7),
            global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem.Option.AnyValue
                => AnyCodec.GetEncodedLength(value.AnyValue, 8),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem value, byte tagNumber)
        => AsduElement.GetEncodedLength<LogDataTSeriesItemCodec, global::Baclib.Bacnet.Types.Application.LogData.TSeriesItem>(tagNumber, value);
}
