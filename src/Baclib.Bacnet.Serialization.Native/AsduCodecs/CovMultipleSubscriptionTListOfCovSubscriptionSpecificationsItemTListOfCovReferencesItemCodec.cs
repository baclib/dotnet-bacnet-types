// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec :
    IAsduElementCodec<T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>,
    IAsduConstructedCodec<T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>
{
    public static T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem Decode(ref AsduReader reader)
    {
        return new T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem
        {
            MonitoredProperty = AsduElement.Decode<PropertyReferenceCodec, T::PropertyReference>(ref reader, 0),
            CovIncrement = AsduElement.DecodeOptional<RealCodec, float>(ref reader, 1),
            Timestamped = AsduElement.Decode<BooleanCodec, bool>(ref reader, 2)
        };
    }

    public static T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
    {
        AsduElement.Encode<PropertyReferenceCodec, T::PropertyReference>(ref writer, 0, value.MonitoredProperty);
        AsduElement.EncodeOptional<RealCodec, float>(ref writer, 1, value.CovIncrement);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 2, value.Timestamped);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
        => AsduConstructed.Encode<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyReferenceCodec, T::PropertyReference>(0, value.MonitoredProperty);
        length += AsduElement.GetOptionalEncodedLength<RealCodec, float>(1, value.CovIncrement);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(2, value.Timestamped);
        return length;
    }

    public static int GetEncodedLength(in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
