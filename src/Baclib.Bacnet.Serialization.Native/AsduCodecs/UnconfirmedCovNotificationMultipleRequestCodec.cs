// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedCovNotificationMultipleRequestCodec :
    IAsduElementCodec<T::UnconfirmedCovNotificationMultipleRequest>,
    IAsduConstructedCodec<T::UnconfirmedCovNotificationMultipleRequest>
{
    public static T::UnconfirmedCovNotificationMultipleRequest Decode(ref AsduReader reader)
    {
        return new T::UnconfirmedCovNotificationMultipleRequest
        {
            SubscriberProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            InitiatingDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            TimeRemaining = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            Timestamp = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 3),
            ListOfCovNotifications = AsduElement.DecodeSequenceOf<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref reader, 4)
        };
    }

    public static T::UnconfirmedCovNotificationMultipleRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedCovNotificationMultipleRequestCodec, T::UnconfirmedCovNotificationMultipleRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::UnconfirmedCovNotificationMultipleRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.TimeRemaining);
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 3, value.Timestamp);
        AsduElement.EncodeSequenceOf<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref writer, 4, value.ListOfCovNotifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::UnconfirmedCovNotificationMultipleRequest value)
        => AsduConstructed.Encode<UnconfirmedCovNotificationMultipleRequestCodec, T::UnconfirmedCovNotificationMultipleRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::UnconfirmedCovNotificationMultipleRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.InitiatingDeviceIdentifier);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.TimeRemaining);
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(3, value.Timestamp);
        length += AsduElement.GetSequenceOfEncodedLength<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(4, value.ListOfCovNotifications);
        return length;
    }

    public static int GetEncodedLength(in T::UnconfirmedCovNotificationMultipleRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<UnconfirmedCovNotificationMultipleRequestCodec, T::UnconfirmedCovNotificationMultipleRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
