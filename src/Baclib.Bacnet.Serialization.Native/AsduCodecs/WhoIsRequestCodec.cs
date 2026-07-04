// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoIsRequestCodec :
    IAsduElementCodec<T::WhoIsRequest>,
    IAsduConstructedCodec<T::WhoIsRequest>
{
    public static T::WhoIsRequest Decode(ref AsduReader reader)
    {
        return new T::WhoIsRequest
        {
            DeviceInstanceRangeLowLimit = AsduElement.DecodeOptional<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref reader, 0),
            DeviceInstanceRangeHighLimit = AsduElement.DecodeOptional<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeHighLimit>(ref reader, 1)
        };
    }

    public static T::WhoIsRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WhoIsRequestCodec, T::WhoIsRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WhoIsRequest value)
    {
        AsduElement.EncodeOptional<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeLowLimit>(ref writer, 0, value.DeviceInstanceRangeLowLimit);
        AsduElement.EncodeOptional<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeHighLimit>(ref writer, 1, value.DeviceInstanceRangeHighLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WhoIsRequest value)
        => AsduConstructed.Encode<WhoIsRequestCodec, T::WhoIsRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WhoIsRequest value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<WhoIsRequestTDeviceInstanceRangeLowLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeLowLimit>(0, value.DeviceInstanceRangeLowLimit);
        length += AsduElement.GetOptionalEncodedLength<WhoIsRequestTDeviceInstanceRangeHighLimitCodec, T::WhoIsRequest.TDeviceInstanceRangeHighLimit>(1, value.DeviceInstanceRangeHighLimit);
        return length;
    }

    public static int GetEncodedLength(in T::WhoIsRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WhoIsRequestCodec, T::WhoIsRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        return reader.PeekContextTag(1);
    }
}
