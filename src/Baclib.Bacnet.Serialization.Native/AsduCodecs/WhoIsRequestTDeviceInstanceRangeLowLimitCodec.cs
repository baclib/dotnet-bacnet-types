// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

// Restriction wrapper codec. Delegates wire handling to Unsigned32Codec and projects the
// underlying value to and from global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit.
public sealed class WhoIsRequestTDeviceInstanceRangeLowLimitCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>
{
    public static global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref reader);

    public static global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref reader, tagNumber);

    public static global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit DecodeValue(ReadOnlySpan<byte> source)
        => (global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit)Unsigned32Codec.DecodeValue(source);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value)
        => AsduPrimitive.Encode<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref writer, value);

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value)
        => AsduPrimitive.Encode<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref writer, tagNumber, value);

    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value)
        => Unsigned32Codec.EncodeValue(destination, value.Value);

    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value)
        => Unsigned32Codec.GetEncodedValueLength(value.Value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    public static ApplicationTagNumber TagNumber
        => Unsigned32Codec.TagNumber;
}
