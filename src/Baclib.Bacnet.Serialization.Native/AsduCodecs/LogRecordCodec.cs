// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogRecordCodec :
    IAsduElementCodec<T::LogRecord>,
    IAsduConstructedCodec<T::LogRecord>
{
    public static T::LogRecord Decode(ref AsduReader reader)
    {
        return new T::LogRecord
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            LogDatum = AsduElement.Decode<LogRecordTLogDatumCodec, T::LogRecord.TLogDatum>(ref reader, 1),
            StatusFlags = AsduElement.DecodeOptional<StatusFlagsCodec, T::StatusFlags>(ref reader, 2)
        };
    }

    public static T::LogRecord Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LogRecordCodec, T::LogRecord>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LogRecord value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<LogRecordTLogDatumCodec, T::LogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
        AsduElement.EncodeOptional<StatusFlagsCodec, T::StatusFlags>(ref writer, 2, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LogRecord value)
        => AsduConstructed.Encode<LogRecordCodec, T::LogRecord>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LogRecord value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<LogRecordTLogDatumCodec, T::LogRecord.TLogDatum>(1, value.LogDatum);
        length += AsduElement.GetOptionalEncodedLength<StatusFlagsCodec, T::StatusFlags>(2, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::LogRecord value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LogRecordCodec, T::LogRecord>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
