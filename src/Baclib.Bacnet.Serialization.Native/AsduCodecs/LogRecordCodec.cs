// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class LogRecordCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.LogRecord>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.LogRecord>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.LogRecord Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _logDatum = Asdu.DecodeConstructed<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(ref reader, 1);
        var _statusFlags = Asdu.DecodeOptional<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.LogRecord
        {
            Timestamp = _timestamp,
            LogDatum = _logDatum,
            StatusFlags = _statusFlags
        };
    }

    public static global::Baclib.Bacnet.Types.Application.LogRecord Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.LogRecord value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(ref writer, 1, value.LogDatum);
        if (value.StatusFlags.HasValue)
        {
            Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 2, value.StatusFlags.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.LogRecord value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogRecord value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<LogRecordTLogDatumCodec, global::Baclib.Bacnet.Types.Application.LogRecord.TLogDatum>(1, value.LogDatum) + (value.StatusFlags.HasValue ? Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(2, value.StatusFlags.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.LogRecord value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
