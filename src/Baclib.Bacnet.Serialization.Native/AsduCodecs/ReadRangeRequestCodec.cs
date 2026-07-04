// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestCodec :
    IAsduElementCodec<T::ReadRangeRequest>,
    IAsduConstructedCodec<T::ReadRangeRequest>
{
    public static T::ReadRangeRequest Decode(ref AsduReader reader)
    {
        return new T::ReadRangeRequest
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            Range = AsduElement.DecodeOptional<ReadRangeRequestTRangeCodec, T::ReadRangeRequest.TRange>(ref reader)
        };
    }

    public static T::ReadRangeRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeRequestCodec, T::ReadRangeRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadRangeRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
        AsduElement.EncodeOptional<ReadRangeRequestTRangeCodec, T::ReadRangeRequest.TRange>(ref writer, value.Range);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadRangeRequest value)
        => AsduConstructed.Encode<ReadRangeRequestCodec, T::ReadRangeRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadRangeRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        length += AsduElement.GetOptionalEncodedLength<ReadRangeRequestTRangeCodec, T::ReadRangeRequest.TRange>(value.Range);
        return length;
    }

    public static int GetEncodedLength(in T::ReadRangeRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadRangeRequestCodec, T::ReadRangeRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
