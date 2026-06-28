// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoIsRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoIsRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoIsRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return !reader.End;
    }

    public static global::Baclib.Bacnet.Types.Application.WhoIsRequest Decode(ref NativeReader reader)
    {
        var _deviceInstanceRangeLowLimit = Asdu.DecodeOptional<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref reader, 0);
        var _deviceInstanceRangeHighLimit = Asdu.DecodeOptional<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeHighLimit>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.WhoIsRequest
        {
            DeviceInstanceRangeLowLimit = _deviceInstanceRangeLowLimit,
            DeviceInstanceRangeHighLimit = _deviceInstanceRangeHighLimit
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WhoIsRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WhoIsRequest value)
    {
        if (value.DeviceInstanceRangeLowLimit.HasValue)
        {
            Asdu.EncodePrimitive<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref writer, 0, value.DeviceInstanceRangeLowLimit.Value);
        }
        if (value.DeviceInstanceRangeHighLimit.HasValue)
        {
            Asdu.EncodePrimitive<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeHighLimit>(ref writer, 1, value.DeviceInstanceRangeHighLimit.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoIsRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoIsRequest value)
    {
        return (value.DeviceInstanceRangeLowLimit.HasValue ? Asdu.GetPrimitiveLength<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeLowLimit>(0, value.DeviceInstanceRangeLowLimit.Value) : 0) + (value.DeviceInstanceRangeHighLimit.HasValue ? Asdu.GetPrimitiveLength<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, global::Baclib.Bacnet.Types.Application.WhoIsRequest.TDeviceInstanceRangeHighLimit>(1, value.DeviceInstanceRangeHighLimit.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoIsRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
