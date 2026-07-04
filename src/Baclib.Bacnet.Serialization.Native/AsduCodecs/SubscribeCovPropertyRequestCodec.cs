// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyRequestCodec :
    IAsduElementCodec<T::SubscribeCovPropertyRequest>,
    IAsduConstructedCodec<T::SubscribeCovPropertyRequest>
{
    public static T::SubscribeCovPropertyRequest Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovPropertyRequest
        {
            SubscriberProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 1),
            IssueConfirmedNotifications = AsduElement.DecodeOptional<BooleanCodec, bool>(ref reader, 2),
            Lifetime = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3),
            MonitoredPropertyIdentifier = AsduElement.Decode<PropertyReferenceCodec, T::PropertyReference>(ref reader, 4),
            CovIncrement = AsduElement.DecodeOptional<RealCodec, float>(ref reader, 5)
        };
    }

    public static T::SubscribeCovPropertyRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyRequestCodec, T::SubscribeCovPropertyRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovPropertyRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 1, value.MonitoredObjectIdentifier);
        AsduElement.EncodeOptional<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.Lifetime);
        AsduElement.Encode<PropertyReferenceCodec, T::PropertyReference>(ref writer, 4, value.MonitoredPropertyIdentifier);
        AsduElement.EncodeOptional<RealCodec, float>(ref writer, 5, value.CovIncrement);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovPropertyRequest value)
        => AsduConstructed.Encode<SubscribeCovPropertyRequestCodec, T::SubscribeCovPropertyRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovPropertyRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier);
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(1, value.MonitoredObjectIdentifier);
        length += AsduElement.GetOptionalEncodedLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.Lifetime);
        length += AsduElement.GetEncodedLength<PropertyReferenceCodec, T::PropertyReference>(4, value.MonitoredPropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<RealCodec, float>(5, value.CovIncrement);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovPropertyRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovPropertyRequestCodec, T::SubscribeCovPropertyRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
