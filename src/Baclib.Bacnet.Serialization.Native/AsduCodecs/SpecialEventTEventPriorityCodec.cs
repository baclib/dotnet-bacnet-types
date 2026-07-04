// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned8Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority.
public sealed class SpecialEventTEventPriorityCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>
{
    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority)Unsigned8Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value)
        => AsduPrimitive.Encode<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value)
        => AsduPrimitive.Encode<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value)
        => Unsigned8Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value)
        => Unsigned8Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned8Codec.TagNumber;
}
