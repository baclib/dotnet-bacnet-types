// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventNotificationSubscriptionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventNotificationSubscription>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventNotificationSubscription>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventNotificationSubscription Decode(ref NativeReader reader)
    {
        var _recipient = Asdu.DecodeConstructed<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader, 0);
        var _processIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 1);
        var _issueConfirmedNotifications = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 2);
        var _timeRemaining = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.EventNotificationSubscription
        {
            Recipient = _recipient,
            ProcessIdentifier = _processIdentifier,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            TimeRemaining = _timeRemaining
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventNotificationSubscription Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventNotificationSubscription value)
    {
        Asdu.EncodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, 0, value.Recipient);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 1, value.ProcessIdentifier);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 2, value.IssueConfirmedNotifications);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventNotificationSubscription value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventNotificationSubscription value)
    {
        return Asdu.GetElementLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(0, value.Recipient) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(1, value.ProcessIdentifier) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(2, value.IssueConfirmedNotifications) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.TimeRemaining);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventNotificationSubscription value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
