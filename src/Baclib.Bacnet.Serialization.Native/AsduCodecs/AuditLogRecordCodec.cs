// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecord>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _logDatum = Asdu.DecodeConstructed<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.AuditLogRecord
        {
            Timestamp = _timestamp,
            LogDatum = _logDatum
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecord Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogRecord value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogRecord value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<AuditLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord.TLogDatum>(1, value.LogDatum);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecord value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
