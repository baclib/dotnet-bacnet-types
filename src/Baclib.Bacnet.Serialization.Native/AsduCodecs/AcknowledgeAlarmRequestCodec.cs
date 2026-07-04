// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AcknowledgeAlarmRequestCodec :
    IAsduElementCodec<T::AcknowledgeAlarmRequest>,
    IAsduConstructedCodec<T::AcknowledgeAlarmRequest>
{
    public static T::AcknowledgeAlarmRequest Decode(ref AsduReader reader)
    {
        return new T::AcknowledgeAlarmRequest
        {
            AcknowledgingProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            EventObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            EventStateAcknowledged = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader, 2),
            Timestamp = AsduElement.Decode<TimeStampCodec, T::TimeStamp>(ref reader, 3),
            AcknowledgmentSource = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 4),
            TimeOfAcknowledgment = AsduElement.Decode<TimeStampCodec, T::TimeStamp>(ref reader, 5)
        };
    }

    public static T::AcknowledgeAlarmRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AcknowledgeAlarmRequestCodec, T::AcknowledgeAlarmRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AcknowledgeAlarmRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.AcknowledgingProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.EventObjectIdentifier);
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, 2, value.EventStateAcknowledged);
        AsduElement.Encode<TimeStampCodec, T::TimeStamp>(ref writer, 3, value.Timestamp);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 4, value.AcknowledgmentSource);
        AsduElement.Encode<TimeStampCodec, T::TimeStamp>(ref writer, 5, value.TimeOfAcknowledgment);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AcknowledgeAlarmRequest value)
        => AsduConstructed.Encode<AcknowledgeAlarmRequestCodec, T::AcknowledgeAlarmRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AcknowledgeAlarmRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.AcknowledgingProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.EventObjectIdentifier);
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(2, value.EventStateAcknowledged);
        length += AsduElement.GetEncodedLength<TimeStampCodec, T::TimeStamp>(3, value.Timestamp);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(4, value.AcknowledgmentSource);
        length += AsduElement.GetEncodedLength<TimeStampCodec, T::TimeStamp>(5, value.TimeOfAcknowledgment);
        return length;
    }

    public static int GetEncodedLength(in T::AcknowledgeAlarmRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AcknowledgeAlarmRequestCodec, T::AcknowledgeAlarmRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
