// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventLogRecordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventLogRecord>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventLogRecord>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventLogRecord Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _logDatum = Asdu.DecodeConstructed<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventLogRecord
        {
            Timestamp = _timestamp,
            LogDatum = _logDatum
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventLogRecord Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventLogRecord value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventLogRecord value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventLogRecord value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<EventLogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.EventLogRecord.TLogDatum>(1, value.LogDatum);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventLogRecord value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
