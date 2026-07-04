// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovRequestCodec :
    IAsduElementCodec<T::SubscribeCovRequest>,
    IAsduConstructedCodec<T::SubscribeCovRequest>
{
    public static T::SubscribeCovRequest Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovRequest
        {
            SubscriberProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            IssueConfirmedNotifications = AsduElement.DecodeOptional<BooleanCodec, bool>(ref reader, 2),
            Lifetime = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3)
        };
    }

    public static T::SubscribeCovRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovRequestCodec, T::SubscribeCovRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.MonitoredObjectIdentifier);
        AsduElement.EncodeOptional<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.Lifetime);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovRequest value)
        => AsduConstructed.Encode<SubscribeCovRequestCodec, T::SubscribeCovRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.MonitoredObjectIdentifier);
        length += AsduElement.GetOptionalEncodedLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.Lifetime);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovRequestCodec, T::SubscribeCovRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
