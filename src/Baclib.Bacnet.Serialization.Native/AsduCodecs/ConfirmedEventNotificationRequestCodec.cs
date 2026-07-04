// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedEventNotificationRequestCodec :
    IAsduElementCodec<T::ConfirmedEventNotificationRequest>,
    IAsduConstructedCodec<T::ConfirmedEventNotificationRequest>
{
    public static T::ConfirmedEventNotificationRequest Decode(ref AsduReader reader)
    {
        return new T::ConfirmedEventNotificationRequest
        {
            ProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            InitiatingDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            EventObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 2),
            Timestamp = AsduElement.Decode<TimeStampCodec, T::TimeStamp>(ref reader, 3),
            NotificationClass = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 4),
            Priority = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 5),
            EventType = AsduElement.Decode<EventTypeCodec, T::EventType>(ref reader, 6),
            MessageText = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 7),
            NotifyType = AsduElement.Decode<NotifyTypeCodec, T::NotifyType>(ref reader, 8),
            AckRequired = AsduElement.DecodeOptional<BooleanCodec, bool>(ref reader, 9),
            FromState = AsduElement.DecodeOptional<EventStateCodec, T::EventState>(ref reader, 10),
            ToState = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader, 11),
            EventValues = AsduElement.DecodeOptional<NotificationParametersCodec, T::NotificationParameters>(ref reader, 12)
        };
    }

    public static T::ConfirmedEventNotificationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedEventNotificationRequestCodec, T::ConfirmedEventNotificationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedEventNotificationRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.ProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 2, value.EventObjectIdentifier);
        AsduElement.Encode<TimeStampCodec, T::TimeStamp>(ref writer, 3, value.Timestamp);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 4, value.NotificationClass);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 5, value.Priority);
        AsduElement.Encode<EventTypeCodec, T::EventType>(ref writer, 6, value.EventType);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 7, value.MessageText);
        AsduElement.Encode<NotifyTypeCodec, T::NotifyType>(ref writer, 8, value.NotifyType);
        AsduElement.EncodeOptional<BooleanCodec, bool>(ref writer, 9, value.AckRequired);
        AsduElement.EncodeOptional<EventStateCodec, T::EventState>(ref writer, 10, value.FromState);
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, 11, value.ToState);
        AsduElement.EncodeOptional<NotificationParametersCodec, T::NotificationParameters>(ref writer, 12, value.EventValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedEventNotificationRequest value)
        => AsduConstructed.Encode<ConfirmedEventNotificationRequestCodec, T::ConfirmedEventNotificationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedEventNotificationRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.ProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.InitiatingDeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(2, value.EventObjectIdentifier);
        length += AsduElement.GetEncodedLength<TimeStampCodec, T::TimeStamp>(3, value.Timestamp);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(4, value.NotificationClass);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(5, value.Priority);
        length += AsduElement.GetEncodedLength<EventTypeCodec, T::EventType>(6, value.EventType);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(7, value.MessageText);
        length += AsduElement.GetEncodedLength<NotifyTypeCodec, T::NotifyType>(8, value.NotifyType);
        length += AsduElement.GetOptionalEncodedLength<BooleanCodec, bool>(9, value.AckRequired);
        length += AsduElement.GetOptionalEncodedLength<EventStateCodec, T::EventState>(10, value.FromState);
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(11, value.ToState);
        length += AsduElement.GetOptionalEncodedLength<NotificationParametersCodec, T::NotificationParameters>(12, value.EventValues);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedEventNotificationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedEventNotificationRequestCodec, T::ConfirmedEventNotificationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
