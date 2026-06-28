// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogRecordResultCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecordResult>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogRecordResult>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecordResult Decode(ref NativeReader reader)
    {
        var _sequenceNumber = Asdu.DecodePrimitive<Unsigned64Codec, ulong>(ref reader, 0);
        var _logRecord = Asdu.DecodeConstructed<AuditLogRecordCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.AuditLogRecordResult
        {
            SequenceNumber = _sequenceNumber,
            LogRecord = _logRecord
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogRecordResult Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogRecordResult value)
    {
        Asdu.EncodePrimitive<Unsigned64Codec, ulong>(ref writer, 0, value.SequenceNumber);
        Asdu.EncodeElement<AuditLogRecordCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord>(ref writer, 1, value.LogRecord);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogRecordResult value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecordResult value)
    {
        return Asdu.GetPrimitiveLength<Unsigned64Codec, ulong>(0, value.SequenceNumber) + Asdu.GetElementLength<AuditLogRecordCodec, global::Baclib.Bacnet.Types.Application.AuditLogRecord>(1, value.LogRecord);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogRecordResult value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
