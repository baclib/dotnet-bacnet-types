// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovMultipleSubscriptionCodec :
    IAsduElementCodec<T::CovMultipleSubscription>,
    IAsduConstructedCodec<T::CovMultipleSubscription>
{
    public static T::CovMultipleSubscription Decode(ref AsduReader reader)
    {
        return new T::CovMultipleSubscription
        {
            Recipient = AsduElement.Decode<RecipientProcessCodec, T::RecipientProcess>(ref reader, 0),
            IssueConfirmedNotifications = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1),
            TimeRemaining = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            MaxNotificationDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3),
            ListOfCovSubscriptionSpecifications = AsduElement.DecodeSequenceOf<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref reader, 4)
        };
    }

    public static T::CovMultipleSubscription Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CovMultipleSubscriptionCodec, T::CovMultipleSubscription>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CovMultipleSubscription value)
    {
        AsduElement.Encode<RecipientProcessCodec, T::RecipientProcess>(ref writer, 0, value.Recipient);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.IssueConfirmedNotifications);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.TimeRemaining);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.MaxNotificationDelay);
        AsduElement.EncodeSequenceOf<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref writer, 4, value.ListOfCovSubscriptionSpecifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CovMultipleSubscription value)
        => AsduConstructed.Encode<CovMultipleSubscriptionCodec, T::CovMultipleSubscription>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CovMultipleSubscription value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RecipientProcessCodec, T::RecipientProcess>(0, value.Recipient);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.IssueConfirmedNotifications);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.TimeRemaining);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.MaxNotificationDelay);
        length += AsduElement.GetSequenceOfEncodedLength<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(4, value.ListOfCovSubscriptionSpecifications);
        return length;
    }

    public static int GetEncodedLength(in T::CovMultipleSubscription value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CovMultipleSubscriptionCodec, T::CovMultipleSubscription>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
