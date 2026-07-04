// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordTLogDatumCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>
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

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @logStatus = LogStatusCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromLogStatus(@logStatus);
            case 1:
                var @auditNotification = AuditNotificationCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromAuditNotification(@auditNotification);
            case 2:
                var @timeChange = RealCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromTimeChange(@timeChange);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.LogStatus:
                LogStatusCodec.Encode(ref writer, 0, value.LogStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.AuditNotification:
                AuditNotificationCodec.Encode(ref writer, 1, value.AuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.TimeChange:
                RealCodec.Encode(ref writer, 2, value.TimeChange);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
        => AsduConstructed.Encode<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.LogStatus
                => LogStatusCodec.GetEncodedLength(value.LogStatus, 0),
            global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.AuditNotification
                => AuditNotificationCodec.GetEncodedLength(value.AuditNotification, 1),
            global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.TimeChange
                => RealCodec.GetEncodedLength(value.TimeChange, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value, byte tagNumber)
        => AsduElement.GetEncodedLength<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(tagNumber, value);
}
