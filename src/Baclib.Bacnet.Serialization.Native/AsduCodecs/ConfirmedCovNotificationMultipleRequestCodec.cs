// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedCovNotificationMultipleRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest Decode(ref NativeReader reader)
    {
        var _subscriberProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _initiatingDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _timeRemaining = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _timestamp = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 3);
        var _listOfCovNotifications = Asdu.DecodeSequenceOf<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest
        {
            SubscriberProcessIdentifier = _subscriberProcessIdentifier,
            InitiatingDeviceIdentifier = _initiatingDeviceIdentifier,
            TimeRemaining = _timeRemaining,
            Timestamp = _timestamp,
            ListOfCovNotifications = _listOfCovNotifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.TimeRemaining);
        if (value.Timestamp.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 3, value.Timestamp.Value);
        }
        writer.WriteOpeningTag(4);
        foreach (var item in value.ListOfCovNotifications)
        {
            Asdu.EncodeElement<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref writer, 4, item);
        }
        writer.WriteClosingTag(4);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.InitiatingDeviceIdentifier) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.TimeRemaining) + (value.Timestamp.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(3, value.Timestamp.Value) : 0) + (AsduLength.FromTagNumber((byte)4) + (value.ListOfCovNotifications.Items.Sum(static item => Asdu.GetElementLength<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(4, item))) + AsduLength.FromTagNumber((byte)4));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationMultipleRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
