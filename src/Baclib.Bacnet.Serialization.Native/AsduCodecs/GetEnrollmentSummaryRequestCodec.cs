// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEnrollmentSummaryRequestCodec :
    IAsduElementCodec<T::GetEnrollmentSummaryRequest>,
    IAsduConstructedCodec<T::GetEnrollmentSummaryRequest>
{
    public static T::GetEnrollmentSummaryRequest Decode(ref AsduReader reader)
    {
        return new T::GetEnrollmentSummaryRequest
        {
            AcknowledgmentFilter = AsduElement.Decode<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, T::GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(ref reader, 0),
            EnrollmentFilter = AsduElement.DecodeOptional<RecipientProcessCodec, T::RecipientProcess>(ref reader, 1),
            EventStateFilter = AsduElement.DecodeOptional<GetEnrollmentSummaryRequestTEventStateFilterCodec, T::GetEnrollmentSummaryRequest.TEventStateFilter>(ref reader, 2),
            EventTypeFilter = AsduElement.DecodeOptional<EventTypeCodec, T::EventType>(ref reader, 3),
            PriorityFilter = AsduElement.DecodeOptional<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(ref reader, 4),
            NotificationClassFilter = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 5)
        };
    }

    public static T::GetEnrollmentSummaryRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEnrollmentSummaryRequestCodec, T::GetEnrollmentSummaryRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEnrollmentSummaryRequest value)
    {
        AsduElement.Encode<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, T::GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(ref writer, 0, value.AcknowledgmentFilter);
        AsduElement.EncodeOptional<RecipientProcessCodec, T::RecipientProcess>(ref writer, 1, value.EnrollmentFilter);
        AsduElement.EncodeOptional<GetEnrollmentSummaryRequestTEventStateFilterCodec, T::GetEnrollmentSummaryRequest.TEventStateFilter>(ref writer, 2, value.EventStateFilter);
        AsduElement.EncodeOptional<EventTypeCodec, T::EventType>(ref writer, 3, value.EventTypeFilter);
        AsduElement.EncodeOptional<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(ref writer, 4, value.PriorityFilter);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 5, value.NotificationClassFilter);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEnrollmentSummaryRequest value)
        => AsduConstructed.Encode<GetEnrollmentSummaryRequestCodec, T::GetEnrollmentSummaryRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEnrollmentSummaryRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<GetEnrollmentSummaryRequestTAcknowledgmentFilterCodec, T::GetEnrollmentSummaryRequest.TAcknowledgmentFilter>(0, value.AcknowledgmentFilter);
        length += AsduElement.GetOptionalEncodedLength<RecipientProcessCodec, T::RecipientProcess>(1, value.EnrollmentFilter);
        length += AsduElement.GetOptionalEncodedLength<GetEnrollmentSummaryRequestTEventStateFilterCodec, T::GetEnrollmentSummaryRequest.TEventStateFilter>(2, value.EventStateFilter);
        length += AsduElement.GetOptionalEncodedLength<EventTypeCodec, T::EventType>(3, value.EventTypeFilter);
        length += AsduElement.GetOptionalEncodedLength<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(4, value.PriorityFilter);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(5, value.NotificationClassFilter);
        return length;
    }

    public static int GetEncodedLength(in T::GetEnrollmentSummaryRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEnrollmentSummaryRequestCodec, T::GetEnrollmentSummaryRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
