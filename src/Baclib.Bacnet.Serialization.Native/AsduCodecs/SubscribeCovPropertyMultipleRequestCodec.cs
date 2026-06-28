// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest Decode(ref NativeReader reader)
    {
        var _subscriberProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _issueConfirmedNotifications = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);
        var _lifetime = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 2);
        var _maxNotificationDelay = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 3);
        var _listOfCovSubscriptionSpecifications = Asdu.DecodeSequenceOf<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest
        {
            SubscriberProcessIdentifier = _subscriberProcessIdentifier,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            Lifetime = _lifetime,
            MaxNotificationDelay = _maxNotificationDelay,
            ListOfCovSubscriptionSpecifications = _listOfCovSubscriptionSpecifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.IssueConfirmedNotifications);
        if (value.Lifetime.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.Lifetime.Value);
        }
        if (value.MaxNotificationDelay.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.MaxNotificationDelay.Value);
        }
        writer.WriteOpeningTag(4);
        foreach (var item in value.ListOfCovSubscriptionSpecifications)
        {
            Asdu.EncodeElement<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref writer, 4, item);
        }
        writer.WriteClosingTag(4);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.IssueConfirmedNotifications) + (value.Lifetime.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.Lifetime.Value) : 0) + (value.MaxNotificationDelay.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.MaxNotificationDelay.Value) : 0) + (AsduLength.FromTagNumber((byte)4) + (value.ListOfCovSubscriptionSpecifications.Items.Sum(static item => Asdu.GetElementLength<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(4, item))) + AsduLength.FromTagNumber((byte)4));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
