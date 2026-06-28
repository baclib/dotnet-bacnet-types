// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeSynchronizationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return DateTimeCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest Decode(ref NativeReader reader)
    {
        var _time = Asdu.DecodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest
        {
            Time = _time
        };
    }

    public static global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, value.Time);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(value.Time);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimeSynchronizationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
