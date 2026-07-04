// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventNotificationSubscriptionCodec :
    IAsduElementCodec<T::EventNotificationSubscription>,
    IAsduConstructedCodec<T::EventNotificationSubscription>
{
    public static T::EventNotificationSubscription Decode(ref AsduReader reader)
    {
        return new T::EventNotificationSubscription
        {
            Recipient = AsduElement.Decode<RecipientCodec, T::Recipient>(ref reader, 0),
            ProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 1),
            IssueConfirmedNotifications = AsduElement.Decode<BooleanCodec, bool>(ref reader, 2),
            TimeRemaining = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3)
        };
    }

    public static T::EventNotificationSubscription Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventNotificationSubscriptionCodec, T::EventNotificationSubscription>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventNotificationSubscription value)
    {
        AsduElement.Encode<RecipientCodec, T::Recipient>(ref writer, 0, value.Recipient);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 1, value.ProcessIdentifier);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventNotificationSubscription value)
        => AsduConstructed.Encode<EventNotificationSubscriptionCodec, T::EventNotificationSubscription>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventNotificationSubscription value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RecipientCodec, T::Recipient>(0, value.Recipient);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(1, value.ProcessIdentifier);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.TimeRemaining);
        return length;
    }

    public static int GetEncodedLength(in T::EventNotificationSubscription value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventNotificationSubscriptionCodec, T::EventNotificationSubscription>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
