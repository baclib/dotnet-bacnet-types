// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestTLimitsCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits Decode(ref NativeReader reader)
    {
        var _deviceInstanceRangeLowLimit = Asdu.DecodePrimitive<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(ref reader, 0);
        var _deviceInstanceRangeHighLimit = Asdu.DecodePrimitive<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits
        {
            DeviceInstanceRangeLowLimit = _deviceInstanceRangeLowLimit,
            DeviceInstanceRangeHighLimit = _deviceInstanceRangeHighLimit
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits value)
    {
        Asdu.EncodePrimitive<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(ref writer, 0, value.DeviceInstanceRangeLowLimit);
        Asdu.EncodePrimitive<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref writer, 1, value.DeviceInstanceRangeHighLimit);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits value)
    {
        return Asdu.GetPrimitiveLength<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(0, value.DeviceInstanceRangeLowLimit) + Asdu.GetPrimitiveLength<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(1, value.DeviceInstanceRangeHighLimit);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoHasRequest.TLimits value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
