// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned32Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit.
public sealed class WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>
{
    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit)Unsigned32Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value)
        => AsduPrimitive.Encode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value)
        => AsduPrimitive.Encode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value)
        => Unsigned32Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value)
        => Unsigned32Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned32Codec.TagNumber;
}
