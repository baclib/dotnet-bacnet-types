// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription Decode(ref NativeReader reader)
    {
        var _monitoredObjectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _monitoredPropertyReference = Asdu.DecodeConstructed<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(ref reader, 1);
        var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription
        {
            MonitoredObjectIdentifier = _monitoredObjectIdentifier,
            MonitoredPropertyReference = _monitoredPropertyReference,
            ErrorType = _errorType
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.MonitoredObjectIdentifier);
        Asdu.EncodeElement<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(ref writer, 1, value.MonitoredPropertyReference);
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 2, value.ErrorType);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.MonitoredObjectIdentifier) + Asdu.GetElementLength<PropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.PropertyReference>(1, value.MonitoredPropertyReference) + Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(2, value.ErrorType);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
