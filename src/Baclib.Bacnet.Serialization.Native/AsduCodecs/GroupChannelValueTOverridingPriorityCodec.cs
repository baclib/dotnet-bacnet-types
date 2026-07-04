// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned8Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority.
public sealed class GroupChannelValueTOverridingPriorityCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>
{
    public static global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority)Unsigned8Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value)
        => AsduPrimitive.Encode<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value)
        => AsduPrimitive.Encode<GroupChannelValueTOverridingPriorityCodec, global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value)
        => Unsigned8Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value)
        => Unsigned8Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.GroupChannelValue.TOverridingPriority value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned8Codec.TagNumber;
}
