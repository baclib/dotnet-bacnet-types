// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventLogRecordCodec :
    IAsduElementCodec<T::EventLogRecord>,
    IAsduConstructedCodec<T::EventLogRecord>
{
    public static T::EventLogRecord Decode(ref AsduReader reader)
    {
        return new T::EventLogRecord
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            LogDatum = AsduElement.Decode<EventLogRecordTLogDatumCodec, T::EventLogRecord.TLogDatum>(ref reader, 1)
        };
    }

    public static T::EventLogRecord Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventLogRecordCodec, T::EventLogRecord>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventLogRecord value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<EventLogRecordTLogDatumCodec, T::EventLogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventLogRecord value)
        => AsduConstructed.Encode<EventLogRecordCodec, T::EventLogRecord>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventLogRecord value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<EventLogRecordTLogDatumCodec, T::EventLogRecord.TLogDatum>(1, value.LogDatum);
        return length;
    }

    public static int GetEncodedLength(in T::EventLogRecord value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventLogRecordCodec, T::EventLogRecord>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
