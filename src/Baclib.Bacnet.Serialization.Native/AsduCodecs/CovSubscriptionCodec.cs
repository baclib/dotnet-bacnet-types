// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CovSubscriptionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CovSubscription>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CovSubscription>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.CovSubscription Decode(ref NativeReader reader)
    {
        var _recipient = Asdu.DecodeConstructed<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref reader, 0);
        var _monitoredPropertyReference = Asdu.DecodeConstructed<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref reader, 1);
        var _issueConfirmedNotifications = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 2);
        var _timeRemaining = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 3);
        var _covIncrement = Asdu.DecodeOptional<RealCodec, float>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.CovSubscription
        {
            Recipient = _recipient,
            MonitoredPropertyReference = _monitoredPropertyReference,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            TimeRemaining = _timeRemaining,
            CovIncrement = _covIncrement
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CovSubscription Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CovSubscription value)
    {
        Asdu.EncodeElement<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref writer, 0, value.Recipient);
        Asdu.EncodeElement<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref writer, 1, value.MonitoredPropertyReference);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
        if (value.CovIncrement.HasValue)
        {
            Asdu.EncodePrimitive<RealCodec, float>(ref writer, 4, value.CovIncrement.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CovSubscription value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CovSubscription value)
    {
        return Asdu.GetElementLength<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(0, value.Recipient) + Asdu.GetElementLength<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(1, value.MonitoredPropertyReference) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.TimeRemaining) + (value.CovIncrement.HasValue ? Asdu.GetPrimitiveLength<RealCodec, float>(4, value.CovIncrement.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CovSubscription value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
