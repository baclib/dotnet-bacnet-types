// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec :
    IAsduElementCodec<T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>,
    IAsduConstructedCodec<T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>
{
    public static T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem Decode(ref AsduReader reader)
    {
        return new T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem
        {
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfValues = AsduElement.DecodeSequenceOf<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref reader, 1)
        };
    }

    public static T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        AsduElement.EncodeSequenceOf<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref writer, 1, value.ListOfValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
        => AsduConstructed.Encode<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.MonitoredObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(1, value.ListOfValues);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
