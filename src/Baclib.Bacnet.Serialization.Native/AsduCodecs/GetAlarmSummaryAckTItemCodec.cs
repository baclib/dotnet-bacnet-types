// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetAlarmSummaryAckTItemCodec :
    IAsduElementCodec<T::GetAlarmSummaryAck.TItem>,
    IAsduConstructedCodec<T::GetAlarmSummaryAck.TItem>
{
    public static T::GetAlarmSummaryAck.TItem Decode(ref AsduReader reader)
    {
        return new T::GetAlarmSummaryAck.TItem
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader),
            AlarmState = AsduElement.Decode<EventStateCodec, T::EventState>(ref reader),
            AcknowledgedTransitions = AsduElement.Decode<EventTransitionBitsCodec, T::EventTransitionBits>(ref reader)
        };
    }

    public static T::GetAlarmSummaryAck.TItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetAlarmSummaryAckTItemCodec, T::GetAlarmSummaryAck.TItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetAlarmSummaryAck.TItem value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, value.ObjectIdentifier);
        AsduElement.Encode<EventStateCodec, T::EventState>(ref writer, value.AlarmState);
        AsduElement.Encode<EventTransitionBitsCodec, T::EventTransitionBits>(ref writer, value.AcknowledgedTransitions);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetAlarmSummaryAck.TItem value)
        => AsduConstructed.Encode<GetAlarmSummaryAckTItemCodec, T::GetAlarmSummaryAck.TItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetAlarmSummaryAck.TItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<EventStateCodec, T::EventState>(value.AlarmState);
        length += AsduElement.GetEncodedLength<EventTransitionBitsCodec, T::EventTransitionBits>(value.AcknowledgedTransitions);
        return length;
    }

    public static int GetEncodedLength(in T::GetAlarmSummaryAck.TItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetAlarmSummaryAckTItemCodec, T::GetAlarmSummaryAck.TItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ObjectIdentifierCodec.Matches(ref reader);
    }
}
