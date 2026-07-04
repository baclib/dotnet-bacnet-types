// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovSubscriptionCodec :
    IAsduElementCodec<T::CovSubscription>,
    IAsduConstructedCodec<T::CovSubscription>
{
    public static T::CovSubscription Decode(ref AsduReader reader)
    {
        return new T::CovSubscription
        {
            Recipient = AsduElement.Decode<RecipientProcessCodec, T::RecipientProcess>(ref reader, 0),
            MonitoredPropertyReference = AsduElement.Decode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref reader, 1),
            IssueConfirmedNotifications = AsduElement.Decode<BooleanCodec, bool>(ref reader, 2),
            TimeRemaining = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3),
            CovIncrement = AsduElement.DecodeOptional<RealCodec, float>(ref reader, 4)
        };
    }

    public static T::CovSubscription Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CovSubscriptionCodec, T::CovSubscription>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CovSubscription value)
    {
        AsduElement.Encode<RecipientProcessCodec, T::RecipientProcess>(ref writer, 0, value.Recipient);
        AsduElement.Encode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref writer, 1, value.MonitoredPropertyReference);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
        AsduElement.EncodeOptional<RealCodec, float>(ref writer, 4, value.CovIncrement);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CovSubscription value)
        => AsduConstructed.Encode<CovSubscriptionCodec, T::CovSubscription>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CovSubscription value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RecipientProcessCodec, T::RecipientProcess>(0, value.Recipient);
        length += AsduElement.GetEncodedLength<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(1, value.MonitoredPropertyReference);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.TimeRemaining);
        length += AsduElement.GetOptionalEncodedLength<RealCodec, float>(4, value.CovIncrement);
        return length;
    }

    public static int GetEncodedLength(in T::CovSubscription value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CovSubscriptionCodec, T::CovSubscription>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
