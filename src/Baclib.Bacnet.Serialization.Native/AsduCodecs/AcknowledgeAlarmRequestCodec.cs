// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AcknowledgeAlarmRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest Decode(ref NativeReader reader)
    {
        var _acknowledgingProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _eventObjectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _eventStateAcknowledged = Asdu.DecodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref reader, 2);
        var _timestamp = Asdu.DecodeConstructed<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 3);
        var _acknowledgmentSource = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 4);
        var _timeOfAcknowledgment = Asdu.DecodeConstructed<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest
        {
            AcknowledgingProcessIdentifier = _acknowledgingProcessIdentifier,
            EventObjectIdentifier = _eventObjectIdentifier,
            EventStateAcknowledged = _eventStateAcknowledged,
            Timestamp = _timestamp,
            AcknowledgmentSource = _acknowledgmentSource,
            TimeOfAcknowledgment = _timeOfAcknowledgment
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.AcknowledgingProcessIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.EventObjectIdentifier);
        Asdu.EncodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref writer, 2, value.EventStateAcknowledged);
        Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 3, value.Timestamp);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 4, value.AcknowledgmentSource);
        Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 5, value.TimeOfAcknowledgment);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.AcknowledgingProcessIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.EventObjectIdentifier) + Asdu.GetPrimitiveLength<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(2, value.EventStateAcknowledged) + Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(3, value.Timestamp) + Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(4, value.AcknowledgmentSource) + Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(5, value.TimeOfAcknowledgment);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AcknowledgeAlarmRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
