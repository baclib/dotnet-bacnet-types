// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned8Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority.
public sealed class WritePropertyRequestTPriorityCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>
{
    public static global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<WritePropertyRequestTPriorityCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<WritePropertyRequestTPriorityCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority)Unsigned8Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value)
        => AsduPrimitive.Encode<WritePropertyRequestTPriorityCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value)
        => AsduPrimitive.Encode<WritePropertyRequestTPriorityCodec, global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value)
        => Unsigned8Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value)
        => Unsigned8Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WritePropertyRequest.TPriority value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned8Codec.TagNumber;
}
