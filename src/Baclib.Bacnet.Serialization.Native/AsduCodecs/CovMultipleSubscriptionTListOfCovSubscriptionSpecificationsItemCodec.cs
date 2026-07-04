// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec :
    IAsduElementCodec<T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>,
    IAsduConstructedCodec<T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>
{
    public static T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem Decode(ref AsduReader reader)
    {
        return new T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem
        {
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfCovReferences = AsduElement.DecodeSequenceOf<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref reader, 1)
        };
    }

    public static T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        AsduElement.EncodeSequenceOf<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref writer, 1, value.ListOfCovReferences);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem value)
        => AsduConstructed.Encode<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.MonitoredObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(1, value.ListOfCovReferences);
        return length;
    }

    public static int GetEncodedLength(in T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CovMultipleSubscriptionTListOfCovSubscriptionSpecificationsItemCodec, T::CovMultipleSubscription.TListOfCovSubscriptionSpecificationsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
