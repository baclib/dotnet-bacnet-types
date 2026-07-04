// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordCodec :
    IAsduElementCodec<T::AuditLogRecord>,
    IAsduConstructedCodec<T::AuditLogRecord>
{
    public static T::AuditLogRecord Decode(ref AsduReader reader)
    {
        return new T::AuditLogRecord
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            LogDatum = AsduElement.Decode<AuditLogRecordTLogDatumCodec, T::AuditLogRecord.TLogDatum>(ref reader, 1)
        };
    }

    public static T::AuditLogRecord Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogRecordCodec, T::AuditLogRecord>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogRecord value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<AuditLogRecordTLogDatumCodec, T::AuditLogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogRecord value)
        => AsduConstructed.Encode<AuditLogRecordCodec, T::AuditLogRecord>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogRecord value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<AuditLogRecordTLogDatumCodec, T::AuditLogRecord.TLogDatum>(1, value.LogDatum);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogRecord value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogRecordCodec, T::AuditLogRecord>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
