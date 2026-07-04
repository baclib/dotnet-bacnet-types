// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordResultCodec :
    IAsduElementCodec<T::AuditLogRecordResult>,
    IAsduConstructedCodec<T::AuditLogRecordResult>
{
    public static T::AuditLogRecordResult Decode(ref AsduReader reader)
    {
        return new T::AuditLogRecordResult
        {
            SequenceNumber = AsduElement.Decode<Unsigned64Codec, ulong>(ref reader, 0),
            LogRecord = AsduElement.Decode<AuditLogRecordCodec, T::AuditLogRecord>(ref reader, 1)
        };
    }

    public static T::AuditLogRecordResult Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogRecordResultCodec, T::AuditLogRecordResult>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuditLogRecordResult value)
    {
        AsduElement.Encode<Unsigned64Codec, ulong>(ref writer, 0, value.SequenceNumber);
        AsduElement.Encode<AuditLogRecordCodec, T::AuditLogRecord>(ref writer, 1, value.LogRecord);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuditLogRecordResult value)
        => AsduConstructed.Encode<AuditLogRecordResultCodec, T::AuditLogRecordResult>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuditLogRecordResult value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned64Codec, ulong>(0, value.SequenceNumber);
        length += AsduElement.GetEncodedLength<AuditLogRecordCodec, T::AuditLogRecord>(1, value.LogRecord);
        return length;
    }

    public static int GetEncodedLength(in T::AuditLogRecordResult value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuditLogRecordResultCodec, T::AuditLogRecordResult>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
