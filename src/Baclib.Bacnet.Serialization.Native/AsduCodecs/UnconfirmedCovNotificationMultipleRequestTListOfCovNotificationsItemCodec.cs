// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec :
    IAsduElementCodec<T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>,
    IAsduConstructedCodec<T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>
{
    public static T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem Decode(ref AsduReader reader)
    {
        return new T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem
        {
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfValues = AsduElement.DecodeSequenceOf<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref reader, 1)
        };
    }

    public static T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        AsduElement.EncodeSequenceOf<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref writer, 1, value.ListOfValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
        => AsduConstructed.Encode<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.MonitoredObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(1, value.ListOfValues);
        return length;
    }

    public static int GetEncodedLength(in T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<UnconfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemCodec, T::UnconfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
