// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec :
    IAsduElementCodec<T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>,
    IAsduConstructedCodec<T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>
{
    public static T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem
        {
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfCovReferences = AsduElement.DecodeSequenceOf<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref reader, 1)
        };
    }

    public static T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        AsduElement.EncodeSequenceOf<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(ref writer, 1, value.ListOfCovReferences);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem value)
        => AsduConstructed.Encode<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.MonitoredObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemTListOfCovReferencesItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem.TListOfCovReferencesItem>(1, value.ListOfCovReferences);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovPropertyMultipleRequestTListOfCovSubscriptionSpecificationsItemCodec, T::SubscribeCovPropertyMultipleRequest.TListOfCovSubscriptionSpecificationsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
