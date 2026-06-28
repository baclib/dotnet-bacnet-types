// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimeValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimeValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(TimeCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.TimeValue Decode(ref NativeReader reader)
    {
        var _time = Asdu.DecodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);
        var _value = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.TimeValue
        {
            Time = _time,
            Value = _value
        };
    }

    public static global::Baclib.Bacnet.Types.Application.TimeValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.TimeValue value)
    {
        Asdu.EncodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.Time);
        Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, value.Value);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimeValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeValue value)
    {
        return Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.Time) + Asdu.GetEncodedLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(value.Value);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
