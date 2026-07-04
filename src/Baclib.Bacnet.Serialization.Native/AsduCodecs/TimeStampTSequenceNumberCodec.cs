// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned16Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber.
public sealed class TimeStampTSequenceNumberCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>
{
    public static global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber)Unsigned16Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value)
        => AsduPrimitive.Encode<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value)
        => AsduPrimitive.Encode<TimeStampTSequenceNumberCodec, global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value)
        => Unsigned16Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value)
        => Unsigned16Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimeStamp.TSequenceNumber value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned16Codec.TagNumber;
}
