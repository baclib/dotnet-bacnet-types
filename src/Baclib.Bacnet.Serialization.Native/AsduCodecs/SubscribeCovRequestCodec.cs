// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovRequest Decode(ref NativeReader reader)
    {
        var _subscriberProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _monitoredObjectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _issueConfirmedNotifications = Asdu.DecodeOptional<BooleanCodec, bool>(ref reader, 2);
        var _lifetime = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.SubscribeCovRequest
        {
            SubscriberProcessIdentifier = _subscriberProcessIdentifier,
            MonitoredObjectIdentifier = _monitoredObjectIdentifier,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            Lifetime = _lifetime
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SubscribeCovRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.MonitoredObjectIdentifier);
        if (value.IssueConfirmedNotifications.HasValue)
        {
            Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications.Value);
        }
        if (value.Lifetime.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.Lifetime.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SubscribeCovRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.MonitoredObjectIdentifier) + (value.IssueConfirmedNotifications.HasValue ? Asdu.GetPrimitiveLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications.Value) : 0) + (value.Lifetime.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.Lifetime.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
