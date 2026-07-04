// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogDataCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogData>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogData>
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
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LogData Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @status = LogStatusCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.LogData.FromStatus(@status);
            case 1:
                var @series = LogDataTSeriesItemCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.LogData.FromSeries(@series);
            case 2:
                var @timeChange = RealCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.LogData.FromTimeChange(@timeChange);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.LogData Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.LogData value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.LogData.Option.Status:
                LogStatusCodec.Encode(ref writer, 0, value.Status);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.Option.Series:
                LogDataTSeriesItemCodec.Encode(ref writer, 1, value.Series);
                return;
            case global::Baclib.Bacnet.Types.Application.LogData.Option.TimeChange:
                RealCodec.Encode(ref writer, 2, value.TimeChange);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogData value)
        => AsduConstructed.Encode<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogData value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.LogData.Option.Status
                => LogStatusCodec.GetEncodedLength(value.Status, 0),
            global::Baclib.Bacnet.Types.Application.LogData.Option.Series
                => LogDataTSeriesItemCodec.GetEncodedLength(value.Series, 1),
            global::Baclib.Bacnet.Types.Application.LogData.Option.TimeChange
                => RealCodec.GetEncodedLength(value.TimeChange, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.LogData value, byte tagNumber)
        => AsduElement.GetEncodedLength<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(tagNumber, value);
}
