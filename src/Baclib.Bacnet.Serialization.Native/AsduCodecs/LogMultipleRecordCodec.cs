// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogMultipleRecordCodec :
    IAsduElementCodec<T::LogMultipleRecord>,
    IAsduConstructedCodec<T::LogMultipleRecord>
{
    public static T::LogMultipleRecord Decode(ref AsduReader reader)
    {
        return new T::LogMultipleRecord
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            LogData = AsduElement.Decode<LogDataCodec, T::LogData>(ref reader, 1)
        };
    }

    public static T::LogMultipleRecord Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<LogMultipleRecordCodec, T::LogMultipleRecord>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::LogMultipleRecord value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<LogDataCodec, T::LogData>(ref writer, 1, value.LogData);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::LogMultipleRecord value)
        => AsduConstructed.Encode<LogMultipleRecordCodec, T::LogMultipleRecord>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::LogMultipleRecord value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<LogDataCodec, T::LogData>(1, value.LogData);
        return length;
    }

    public static int GetEncodedLength(in T::LogMultipleRecord value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<LogMultipleRecordCodec, T::LogMultipleRecord>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
