// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordTLogDatumCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _logStatus = Asdu.DecodePrimitive<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromLogStatus(_logStatus);
            case 1:
                var _auditNotification = Asdu.DecodeConstructed<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromAuditNotification(_auditNotification);
            case 2:
                var _timeChange = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.FromTimeChange(_timeChange);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.LogStatus:
                Asdu.EncodePrimitive<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(ref writer, 0, value.LogStatus);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.AuditNotification:
                Asdu.EncodeConstructed<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(ref writer, 1, value.AuditNotification);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.TimeChange:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.TimeChange);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.LogStatus:
                return Asdu.GetPrimitiveLength<LogStatusCodec, global::Baclib.Bacnet.Types.Application.LogStatus>(0, value.LogStatus);
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.AuditNotification:
                return Asdu.GetConstructedLength<AuditNotificationCodec, global::Baclib.Bacnet.Types.Application.AuditNotification>(1, value.AuditNotification);
            case global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum.Option.TimeChange:
                return Asdu.GetPrimitiveLength<RealCodec, float>(2, value.TimeChange);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}