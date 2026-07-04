// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleRequestCodec :
    IAsduElementCodec<T::SubscribeCovPropertyMultipleRequest>,
    IAsduConstructedCodec<T::SubscribeCovPropertyMultipleRequest>
{
    public static T::SubscribeCovPropertyMultipleRequest Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovPropertyMultipleRequest
        {
            SubscriberProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            IssueConfirmedNotifications = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1),
            Lifetime = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            MaxNotificationDelay = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3),
            ListOfCovSubscriptionSpecifications = AsduElement.DecodeSequenceOf<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref reader, 4)
        };
    }

    public static T::SubscribeCovPropertyMultipleRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyMultipleRequestCodec, T::SubscribeCovPropertyMultipleRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovPropertyMultipleRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.IssueConfirmedNotifications);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.Lifetime);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.MaxNotificationDelay);
        AsduElement.EncodeSequenceOf<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref writer, 4, value.ListOfCovSubscriptionSpecifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovPropertyMultipleRequest value)
        => AsduConstructed.Encode<SubscribeCovPropertyMultipleRequestCodec, T::SubscribeCovPropertyMultipleRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.IssueConfirmedNotifications);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.Lifetime);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.MaxNotificationDelay);
        length += AsduElement.GetSequenceOfEncodedLength<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(4, value.ListOfCovSubscriptionSpecifications);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovPropertyMultipleRequestCodec, T::SubscribeCovPropertyMultipleRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
