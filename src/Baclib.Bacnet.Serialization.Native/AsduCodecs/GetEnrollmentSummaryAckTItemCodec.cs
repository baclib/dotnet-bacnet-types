// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEnrollmentSummaryAckTItemCodec :
    IAsduElementCodec<T::GetEnrollmentSummaryAck.TItem>,
    IAsduConstructedCodec<T::GetEnrollmentSummaryAck.TItem>
{
    public static T::GetEnrollmentSummaryAck.TItem Decode(ref AsduReader reader)
    {
        return new T::GetEnrollmentSummaryAck.TItem
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            EventType = AsduElement.Decode<EventTypeCodec, T::EventType>(ref reader),
            EventState = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader),
            Priority = AsduElement.Decode<Unsigned8Codec, byte>(ref reader),
            NotificationClass = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader)
        };
    }

    public static T::GetEnrollmentSummaryAck.TItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEnrollmentSummaryAckTItemCodec, T::GetEnrollmentSummaryAck.TItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEnrollmentSummaryAck.TItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.ObjectIdentifier);
        AsduElement.Encode<EventTypeCodec, T::EventType>(ref writer, value.EventType);
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, value.EventState);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, value.Priority);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, value.NotificationClass);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEnrollmentSummaryAck.TItem value)
        => AsduConstructed.Encode<GetEnrollmentSummaryAckTItemCodec, T::GetEnrollmentSummaryAck.TItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEnrollmentSummaryAck.TItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<EventTypeCodec, T::EventType>(value.EventType);
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(value.EventState);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(value.Priority);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(value.NotificationClass);
        return length;
    }

    public static int GetEncodedLength(in T::GetEnrollmentSummaryAck.TItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEnrollmentSummaryAckTItemCodec, T::GetEnrollmentSummaryAck.TItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
