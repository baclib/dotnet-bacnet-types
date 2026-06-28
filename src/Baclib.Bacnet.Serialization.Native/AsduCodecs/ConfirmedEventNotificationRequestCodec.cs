// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedEventNotificationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest Decode(ref NativeReader reader)
    {
        var _processIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _initiatingDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _eventObjectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 2);
        var _timestamp = Asdu.DecodeConstructed<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref reader, 3);
        var _notificationClass = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 4);
        var _priority = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 5);
        var _eventType = Asdu.DecodePrimitive<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref reader, 6);
        var _messageText = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 7);
        var _notifyType = Asdu.DecodePrimitive<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(ref reader, 8);
        var _ackRequired = Asdu.DecodeOptional<BooleanCodec, bool>(ref reader, 9);
        var _fromState = Asdu.DecodeOptional<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref reader, 10);
        var _toState = Asdu.DecodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref reader, 11);
        var _eventValues = Asdu.DecodeOptionalElement<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(ref reader, 12);

        return new global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest
        {
            ProcessIdentifier = _processIdentifier,
            InitiatingDeviceIdentifier = _initiatingDeviceIdentifier,
            EventObjectIdentifier = _eventObjectIdentifier,
            Timestamp = _timestamp,
            NotificationClass = _notificationClass,
            Priority = _priority,
            EventType = _eventType,
            MessageText = _messageText,
            NotifyType = _notifyType,
            AckRequired = _ackRequired,
            FromState = _fromState,
            ToState = _toState,
            EventValues = _eventValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.ProcessIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 2, value.EventObjectIdentifier);
        Asdu.EncodeElement<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(ref writer, 3, value.Timestamp);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 4, value.NotificationClass);
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 5, value.Priority);
        Asdu.EncodePrimitive<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref writer, 6, value.EventType);
        if (value.MessageText.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 7, value.MessageText.Value);
        }
        Asdu.EncodePrimitive<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(ref writer, 8, value.NotifyType);
        if (value.AckRequired.HasValue)
        {
            Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 9, value.AckRequired.Value);
        }
        if (value.FromState.HasValue)
        {
            Asdu.EncodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref writer, 10, value.FromState.Value);
        }
        Asdu.EncodePrimitive<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(ref writer, 11, value.ToState);
        if (value.EventValues.HasValue)
        {
            Asdu.EncodeElement<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(ref writer, 12, value.EventValues.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.ProcessIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.InitiatingDeviceIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(2, value.EventObjectIdentifier) + Asdu.GetElementLength<TimeStampCodec, global::Baclib.Bacnet.Types.Application.TimeStamp>(3, value.Timestamp) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(4, value.NotificationClass) + Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(5, value.Priority) + Asdu.GetPrimitiveLength<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(6, value.EventType) + (value.MessageText.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(7, value.MessageText.Value) : 0) + Asdu.GetPrimitiveLength<NotifyTypeCodec, global::Baclib.Bacnet.Types.Application.NotifyType>(8, value.NotifyType) + (value.AckRequired.HasValue ? Asdu.GetPrimitiveLength<BooleanCodec, bool>(9, value.AckRequired.Value) : 0) + (value.FromState.HasValue ? Asdu.GetPrimitiveLength<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(10, value.FromState.Value) : 0) + Asdu.GetPrimitiveLength<EventStateCodec, global::Baclib.Bacnet.Types.Application.EventState>(11, value.ToState) + (value.EventValues.HasValue ? Asdu.GetElementLength<NotificationParametersCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters>(12, value.EventValues.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedEventNotificationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
