// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEventInformationAckTListOfEventSummariesItemCodec :
    IAsduElementCodec<T::GetEventInformationAck.TListOfEventSummariesItem>,
    IAsduConstructedCodec<T::GetEventInformationAck.TListOfEventSummariesItem>
{
    public static T::GetEventInformationAck.TListOfEventSummariesItem Decode(ref AsduReader reader)
    {
        return new T::GetEventInformationAck.TListOfEventSummariesItem
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            EventState = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader, 1),
            AcknowledgedTransitions = AsduElement.Decode<EventTransitionBitsCodec, T::EventTransitionBits>(ref reader, 2),
            EventTimestamps = AsduElement.DecodeSequenceOf<TimeStampCodec, T::TimeStamp>(ref reader, 3),
            NotifyType = AsduElement.Decode<NotifyTypeCodec, T::NotifyType>(ref reader, 4),
            EventEnable = AsduElement.Decode<EventTransitionBitsCodec, T::EventTransitionBits>(ref reader, 5),
            EventPriorities = AsduElement.DecodeSequenceOf<UnsignedCodec, uint>(ref reader, 6)
        };
    }

    public static T::GetEventInformationAck.TListOfEventSummariesItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEventInformationAck.TListOfEventSummariesItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, 1, value.EventState);
        AsduElement.Encode<EventTransitionBitsCodec, T::EventTransitionBits>(ref writer, 2, value.AcknowledgedTransitions);
        AsduElement.EncodeSequenceOf<TimeStampCodec, T::TimeStamp>(ref writer, 3, value.EventTimestamps);
        AsduElement.Encode<NotifyTypeCodec, T::NotifyType>(ref writer, 4, value.NotifyType);
        AsduElement.Encode<EventTransitionBitsCodec, T::EventTransitionBits>(ref writer, 5, value.EventEnable);
        AsduElement.EncodeSequenceOf<UnsignedCodec, uint>(ref writer, 6, value.EventPriorities);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEventInformationAck.TListOfEventSummariesItem value)
        => AsduConstructed.Encode<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEventInformationAck.TListOfEventSummariesItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(1, value.EventState);
        length += AsduElement.GetEncodedLength<EventTransitionBitsCodec, T::EventTransitionBits>(2, value.AcknowledgedTransitions);
        length += AsduElement.GetSequenceOfEncodedLength<TimeStampCodec, T::TimeStamp>(3, value.EventTimestamps);
        length += AsduElement.GetEncodedLength<NotifyTypeCodec, T::NotifyType>(4, value.NotifyType);
        length += AsduElement.GetEncodedLength<EventTransitionBitsCodec, T::EventTransitionBits>(5, value.EventEnable);
        length += AsduElement.GetSequenceOfEncodedLength<UnsignedCodec, uint>(6, value.EventPriorities);
        return length;
    }

    public static int GetEncodedLength(in T::GetEventInformationAck.TListOfEventSummariesItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
