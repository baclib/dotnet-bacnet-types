// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventLogRecordTLogDatumCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>
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

    public static global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @logStatus = LogStatusCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.FromLogStatus(@logStatus);
            case 1:
                var @notification = ConfirmedEventNotificationRequestCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.FromNotification(@notification);
            case 2:
                var @timeChange = RealCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.FromTimeChange(@timeChange);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.LogStatus:
                LogStatusCodec.Encode(ref writer, 0, value.LogStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.Notification:
                ConfirmedEventNotificationRequestCodec.Encode(ref writer, 1, value.Notification);
                return;
            case global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.TimeChange:
                RealCodec.Encode(ref writer, 2, value.TimeChange);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum value)
        => AsduConstructed.Encode<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.LogStatus
                => LogStatusCodec.GetEncodedLength(value.LogStatus, 0),
            global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.Notification
                => ConfirmedEventNotificationRequestCodec.GetEncodedLength(value.Notification, 1),
            global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum.Option.TimeChange
                => RealCodec.GetEncodedLength(value.TimeChange, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum value, byte tagNumber)
        => AsduElement.GetEncodedLength<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(tagNumber, value);
}
