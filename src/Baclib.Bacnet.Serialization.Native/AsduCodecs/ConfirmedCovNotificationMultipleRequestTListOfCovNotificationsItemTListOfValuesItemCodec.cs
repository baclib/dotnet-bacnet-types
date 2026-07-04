// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec :
    IAsduElementCodec<T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>,
    IAsduConstructedCodec<T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>
{
    public static T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem Decode(ref AsduReader reader)
    {
        return new T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem
        {
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 0),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 1),
            PropertyValue = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 2),
            TimeOfChange = AsduElement.DecodeOptional<TimeCodec, T::Time>(ref reader, 3)
        };
    }

    public static T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem value)
    {
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 0, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 1, value.PropertyArrayIndex);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 2, value.PropertyValue);
        AsduElement.EncodeOptional<TimeCodec, T::Time>(ref writer, 3, value.TimeOfChange);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem value)
        => AsduConstructed.Encode<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(0, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(1, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(2, value.PropertyValue);
        length += AsduElement.GetOptionalEncodedLength<TimeCodec, T::Time>(3, value.TimeOfChange);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedCovNotificationMultipleRequestTListOfCovNotificationsItemTListOfValuesItemCodec, T::ConfirmedCovNotificationMultipleRequest.TListOfCovNotificationsItem.TListOfValuesItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
