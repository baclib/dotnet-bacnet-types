// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEnrollmentSummaryRequestTPriorityFilterCodec :
    IAsduElementCodec<T::GetEnrollmentSummaryRequest.TPriorityFilter>,
    IAsduConstructedCodec<T::GetEnrollmentSummaryRequest.TPriorityFilter>
{
    public static T::GetEnrollmentSummaryRequest.TPriorityFilter Decode(ref AsduReader reader)
    {
        return new T::GetEnrollmentSummaryRequest.TPriorityFilter
        {
            MinPriority = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 0),
            MaxPriority = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 1)
        };
    }

    public static T::GetEnrollmentSummaryRequest.TPriorityFilter Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEnrollmentSummaryRequest.TPriorityFilter value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 0, value.MinPriority);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 1, value.MaxPriority);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEnrollmentSummaryRequest.TPriorityFilter value)
        => AsduConstructed.Encode<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEnrollmentSummaryRequest.TPriorityFilter value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(0, value.MinPriority);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(1, value.MaxPriority);
        return length;
    }

    public static int GetEncodedLength(in T::GetEnrollmentSummaryRequest.TPriorityFilter value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEnrollmentSummaryRequestTPriorityFilterCodec, T::GetEnrollmentSummaryRequest.TPriorityFilter>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
