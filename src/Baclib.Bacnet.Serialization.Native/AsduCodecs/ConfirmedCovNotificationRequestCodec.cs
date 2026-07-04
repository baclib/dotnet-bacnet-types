// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedCovNotificationRequestCodec :
    IAsduElementCodec<T::ConfirmedCovNotificationRequest>,
    IAsduConstructedCodec<T::ConfirmedCovNotificationRequest>
{
    public static T::ConfirmedCovNotificationRequest Decode(ref AsduReader reader)
    {
        return new T::ConfirmedCovNotificationRequest
        {
            SubscriberProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            InitiatingDeviceIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 2),
            TimeRemaining = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3),
            ListOfValues = AsduElement.DecodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref reader, 4)
        };
    }

    public static T::ConfirmedCovNotificationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedCovNotificationRequestCodec, T::ConfirmedCovNotificationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedCovNotificationRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 2, value.MonitoredObjectIdentifier);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
        AsduElement.EncodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref writer, 4, value.ListOfValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedCovNotificationRequest value)
        => AsduConstructed.Encode<ConfirmedCovNotificationRequestCodec, T::ConfirmedCovNotificationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedCovNotificationRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.InitiatingDeviceIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(2, value.MonitoredObjectIdentifier);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.TimeRemaining);
        length += AsduElement.GetSequenceOfEncodedLength<PropertyValueCodec, T::PropertyValue>(4, value.ListOfValues);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedCovNotificationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedCovNotificationRequestCodec, T::ConfirmedCovNotificationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
