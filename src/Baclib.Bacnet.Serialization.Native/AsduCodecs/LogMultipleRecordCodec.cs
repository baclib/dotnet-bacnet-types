// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogMultipleRecordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogMultipleRecord>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogMultipleRecord>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LogMultipleRecord Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _logData = Asdu.DecodeConstructed<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.LogMultipleRecord
        {
            Timestamp = _timestamp,
            LogData = _logData
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LogMultipleRecord Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LogMultipleRecord value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(ref writer, 1, value.LogData);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogMultipleRecord value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogMultipleRecord value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<LogDataCodec, global::Baclib.Bacnet.Types.Application.LogData>(1, value.LogData);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogMultipleRecord value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
