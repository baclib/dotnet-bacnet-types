// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DestinationCodec :
    IAsduElementCodec<T::Destination>,
    IAsduConstructedCodec<T::Destination>
{
    public static T::Destination Decode(ref AsduReader reader)
    {
        return new T::Destination
        {
            ValidDays = AsduElement.Decode<DaysOfWeekCodec, T::DaysOfWeek>(ref reader),
            FromTime = AsduElement.Decode<TimeCodec, T::Time>(ref reader),
            ToTime = AsduElement.Decode<TimeCodec, T::Time>(ref reader),
            Recipient = AsduElement.Decode<RecipientCodec, T::Recipient>(ref reader),
            ProcessIdentifier = AsduElement.Decode<Unsigned32Codec, uint>(ref reader),
            IssueConfirmedNotifications = AsduElement.Decode<BooleanCodec, bool>(ref reader),
            Transitions = AsduElement.Decode<EventTransitionBitsCodec, T::EventTransitionBits>(ref reader)
        };
    }

    public static T::Destination Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DestinationCodec, T::Destination>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::Destination value)
    {
        AsduElement.Encode<DaysOfWeekCodec, T::DaysOfWeek>(ref writer, value.ValidDays);
        AsduElement.Encode<TimeCodec, T::Time>(ref writer, value.FromTime);
        AsduElement.Encode<TimeCodec, T::Time>(ref writer, value.ToTime);
        AsduElement.Encode<RecipientCodec, T::Recipient>(ref writer, value.Recipient);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, value.ProcessIdentifier);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, value.IssueConfirmedNotifications);
        AsduElement.Encode<EventTransitionBitsCodec, T::EventTransitionBits>(ref writer, value.Transitions);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::Destination value)
        => AsduConstructed.Encode<DestinationCodec, T::Destination>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::Destination value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DaysOfWeekCodec, T::DaysOfWeek>(value.ValidDays);
        length += AsduElement.GetEncodedLength<TimeCodec, T::Time>(value.FromTime);
        length += AsduElement.GetEncodedLength<TimeCodec, T::Time>(value.ToTime);
        length += AsduElement.GetEncodedLength<RecipientCodec, T::Recipient>(value.Recipient);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(value.ProcessIdentifier);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(value.IssueConfirmedNotifications);
        length += AsduElement.GetEncodedLength<EventTransitionBitsCodec, T::EventTransitionBits>(value.Transitions);
        return length;
    }

    public static int GetEncodedLength(in T::Destination value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DestinationCodec, T::Destination>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DaysOfWeekCodec.Matches(ref reader);
    }
}
