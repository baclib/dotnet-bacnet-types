// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec :
    IAsduElementCodec<T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>,
    IAsduConstructedCodec<T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>
{
    public static T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem
        {
            MonitoredProperty = AsduElement.Decode<PropertyReferenceCodec, T::PropertyReference>(ref reader, 0),
            CovIncrement = AsduElement.DecodeOptional<RealCodec, float>(ref reader, 1),
            Timestamped = AsduElement.Decode<BooleanCodec, bool>(ref reader, 2)
        };
    }

    public static T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
    {
        AsduElement.Encode<PropertyReferenceCodec, T::PropertyReference>(ref writer, 0, value.MonitoredProperty);
        AsduElement.EncodeOptional<RealCodec, float>(ref writer, 1, value.CovIncrement);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 2, value.Timestamped);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
        => AsduConstructed.Encode<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyReferenceCodec, T::PropertyReference>(0, value.MonitoredProperty);
        length += AsduElement.GetOptionalEncodedLength<RealCodec, float>(1, value.CovIncrement);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(2, value.Timestamped);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
