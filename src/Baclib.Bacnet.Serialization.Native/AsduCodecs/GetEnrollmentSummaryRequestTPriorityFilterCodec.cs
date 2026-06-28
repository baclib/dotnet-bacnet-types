// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEnrollmentSummaryRequestTPriorityFilterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter Decode(ref NativeReader reader)
    {
        var _minPriority = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 0);
        var _maxPriority = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter
        {
            MinPriority = _minPriority,
            MaxPriority = _maxPriority
        };
    }

    public static global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 0, value.MinPriority);
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 1, value.MaxPriority);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter value)
    {
        return Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(0, value.MinPriority) + Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(1, value.MaxPriority);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEnrollmentSummaryRequest.TPriorityFilter value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
