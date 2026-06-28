// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AcknowledgeAlarmInfoCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo Decode(ref NativeReader reader)
    {
        var _eventStateAcknowledged = Asdu.DecodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref reader, 0);
        var _timestamp = Asdu.DecodeConstructed<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo
        {
            EventStateAcknowledged = _eventStateAcknowledged,
            Timestamp = _timestamp
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo value)
    {
        Asdu.EncodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref writer, 0, value.EventStateAcknowledged);
        Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 1, value.Timestamp);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo value)
    {
        return Asdu.GetPrimitiveLength<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(0, value.EventStateAcknowledged) + Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(1, value.Timestamp);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmInfo value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
