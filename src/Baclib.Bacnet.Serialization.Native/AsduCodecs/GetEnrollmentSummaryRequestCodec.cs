// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEnrollmentSummaryRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest Decode(ref NativeReader reader)
    {
        var _acknowledgmentFilter = Asdu.DecodePrimitive<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(ref reader, 0);
        var _enrollmentFilter = Asdu.DecodeOptionalElement<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref reader, 1);
        var _eventStateFilter = Asdu.DecodeOptional<GetEnrollmentSummaryRequestTEventStateFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TEventStateFilter>(ref reader, 2);
        var _eventTypeFilter = Asdu.DecodeOptional<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref reader, 3);
        var _priorityFilter = Asdu.DecodeOptionalElement<GetEnrollmentSummaryRequestTPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter>(ref reader, 4);
        var _notificationClassFilter = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest
        {
            AcknowledgmentFilter = _acknowledgmentFilter,
            EnrollmentFilter = _enrollmentFilter,
            EventStateFilter = _eventStateFilter,
            EventTypeFilter = _eventTypeFilter,
            PriorityFilter = _priorityFilter,
            NotificationClassFilter = _notificationClassFilter
        };
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest value)
    {
        Asdu.EncodePrimitive<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(ref writer, 0, value.AcknowledgmentFilter);
        if (value.EnrollmentFilter.HasValue)
        {
            Asdu.EncodeElement<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(ref writer, 1, value.EnrollmentFilter.Value);
        }
        if (value.EventStateFilter.HasValue)
        {
            Asdu.EncodePrimitive<GetEnrollmentSummaryRequestTEventStateFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TEventStateFilter>(ref writer, 2, value.EventStateFilter.Value);
        }
        if (value.EventTypeFilter.HasValue)
        {
            Asdu.EncodePrimitive<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(ref writer, 3, value.EventTypeFilter.Value);
        }
        if (value.PriorityFilter.HasValue)
        {
            Asdu.EncodeElement<GetEnrollmentSummaryRequestTPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter>(ref writer, 4, value.PriorityFilter.Value);
        }
        if (value.NotificationClassFilter.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 5, value.NotificationClassFilter.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest value)
    {
        return Asdu.GetPrimitiveLength<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(0, value.AcknowledgmentFilter) + (value.EnrollmentFilter.HasValue ? Asdu.GetElementLength<RecipientProcessCodec, global::Baclib.Bacnet.Types.Application.RecipientProcess>(1, value.EnrollmentFilter.Value) : 0) + (value.EventStateFilter.HasValue ? Asdu.GetPrimitiveLength<GetEnrollmentSummaryRequestTEventStateFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TEventStateFilter>(2, value.EventStateFilter.Value) : 0) + (value.EventTypeFilter.HasValue ? Asdu.GetPrimitiveLength<EventTypeCodec, global::Baclib.Bacnet.Types.Application.EventType>(3, value.EventTypeFilter.Value) : 0) + (value.PriorityFilter.HasValue ? Asdu.GetElementLength<GetEnrollmentSummaryRequestTPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter>(4, value.PriorityFilter.Value) : 0) + (value.NotificationClassFilter.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(5, value.NotificationClassFilter.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
