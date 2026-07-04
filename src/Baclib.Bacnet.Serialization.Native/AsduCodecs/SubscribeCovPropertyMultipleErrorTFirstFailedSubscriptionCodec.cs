// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec :
    IAsduElementCodec<T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription>,
    IAsduConstructedCodec<T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription>
{
    public static T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription Decode(ref AsduReader reader)
    {
        return new T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription
        {
            MonitoredObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            MonitoredPropertyReference = AsduElement.Decode<PropertyReferenceCodec, T::PropertyReference>(ref reader, 1),
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 2)
        };
    }

    public static T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        AsduElement.Encode<PropertyReferenceCodec, T::PropertyReference>(ref writer, 1, value.MonitoredPropertyReference);
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 2, value.ErrorType);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
        => AsduConstructed.Encode<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.MonitoredObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyReferenceCodec, T::PropertyReference>(1, value.MonitoredPropertyReference);
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(2, value.ErrorType);
        return length;
    }

    public static int GetEncodedLength(in T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, T::SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
