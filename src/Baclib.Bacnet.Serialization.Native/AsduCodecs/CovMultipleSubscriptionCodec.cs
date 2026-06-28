// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovMultipleSubscriptionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CovMultipleSubscription>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CovMultipleSubscription>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.CovMultipleSubscription Decode(ref NativeReader reader)
    {
        var _recipient = Asdu.DecodeConstructed<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref reader, 0);
        var _issueConfirmedNotifications = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);
        var _timeRemaining = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _maxNotificationDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 3);
        var _listOfCovSubscriptionSpecifications = Asdu.DecodeSequenceOf<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.CovMultipleSubscription
        {
            Recipient = _recipient,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            TimeRemaining = _timeRemaining,
            MaxNotificationDelay = _maxNotificationDelay,
            ListOfCovSubscriptionSpecifications = _listOfCovSubscriptionSpecifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CovMultipleSubscription Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CovMultipleSubscription value)
    {
        Asdu.EncodeElement<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref writer, 0, value.Recipient);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.IssueConfirmedNotifications);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.TimeRemaining);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.MaxNotificationDelay);
        writer.WriteOpeningTag(4);
        foreach (var item in value.ListOfCovSubscriptionSpecifications)
        {
            Asdu.EncodeElement<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref writer, 4, item);
        }
        writer.WriteClosingTag(4);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CovMultipleSubscription value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CovMultipleSubscription value)
    {
        return Asdu.GetElementLength<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(0, value.Recipient) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.IssueConfirmedNotifications) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.TimeRemaining) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.MaxNotificationDelay) + (AsduLength.FromTagNumber((byte)4) + (value.ListOfCovSubscriptionSpecifications.Items.Sum(static item => Asdu.GetElementLength<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, global::Baclib.Bacnet.Types.Application.CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(4, item))) + AsduLength.FromTagNumber((byte)4));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CovMultipleSubscription value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
