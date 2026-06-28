// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DestinationCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Destination>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Destination>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(DaysOfWeekCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.Destination Decode(ref NativeReader reader)
    {
        var _validDays = Asdu.DecodePrimitive<DaysOfWeekCodec, global::Baclib.Bacnet.Types.Application.DaysOfWeek>(ref reader);
        var _fromTime = Asdu.DecodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);
        var _toTime = Asdu.DecodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);
        var _recipient = Asdu.DecodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref reader);
        var _processIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader);
        var _issueConfirmedNotifications = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);
        var _transitions = Asdu.DecodePrimitive<EventTransitionBitsCodec, global::Baclib.Bacnet.Types.Application.EventTransitionBits>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.Destination
        {
            ValidDays = _validDays,
            FromTime = _fromTime,
            ToTime = _toTime,
            Recipient = _recipient,
            ProcessIdentifier = _processIdentifier,
            IssueConfirmedNotifications = _issueConfirmedNotifications,
            Transitions = _transitions
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Destination Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Destination value)
    {
        Asdu.EncodePrimitive<DaysOfWeekCodec, global::Baclib.Bacnet.Types.Application.DaysOfWeek>(ref writer, value.ValidDays);
        Asdu.EncodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.FromTime);
        Asdu.EncodePrimitive<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.ToTime);
        Asdu.EncodeElement<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(ref writer, value.Recipient);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, value.ProcessIdentifier);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.IssueConfirmedNotifications);
        Asdu.EncodePrimitive<EventTransitionBitsCodec, global::Baclib.Bacnet.Types.Application.EventTransitionBits>(ref writer, value.Transitions);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Destination value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Destination value)
    {
        return Asdu.GetEncodedLength<DaysOfWeekCodec, global::Baclib.Bacnet.Types.Application.DaysOfWeek>(value.ValidDays) + Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.FromTime) + Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.ToTime) + Asdu.GetElementLength<RecipientCodec, global::Baclib.Bacnet.Types.Application.Recipient>(value.Recipient) + Asdu.GetEncodedLength<Unsigned32Codec, uint>(value.ProcessIdentifier) + Asdu.GetEncodedLength<BooleanCodec, bool>(value.IssueConfirmedNotifications) + Asdu.GetEncodedLength<EventTransitionBitsCodec, global::Baclib.Bacnet.Types.Application.EventTransitionBits>(value.Transitions);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Destination value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
