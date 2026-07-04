// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoHasRequestTLimitsCodec :
    IAsduElementCodec<T::WhoHasRequest.TLimits>,
    IAsduConstructedCodec<T::WhoHasRequest.TLimits>
{
    public static T::WhoHasRequest.TLimits Decode(ref AsduReader reader)
    {
        return new T::WhoHasRequest.TLimits
        {
            DeviceInstanceRangeLowLimit = AsduElement.Decode<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(ref reader, 0),
            DeviceInstanceRangeHighLimit = AsduElement.Decode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref reader, 1)
        };
    }

    public static T::WhoHasRequest.TLimits Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WhoHasRequest.TLimits value)
    {
        AsduElement.Encode<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(ref writer, 0, value.DeviceInstanceRangeLowLimit);
        AsduElement.Encode<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(ref writer, 1, value.DeviceInstanceRangeHighLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WhoHasRequest.TLimits value)
        => AsduConstructed.Encode<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WhoHasRequest.TLimits value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<WhoHasRequestTLimitsTDeviceInstanceRangeLowLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeLowLimit>(0, value.DeviceInstanceRangeLowLimit);
        length += AsduElement.GetEncodedLength<WhoHasRequestTLimitsTDeviceInstanceRangeHighLimitCodec, T::WhoHasRequest.TLimits.TDeviceInstanceRangeHighLimit>(1, value.DeviceInstanceRangeHighLimit);
        return length;
    }

    public static int GetEncodedLength(in T::WhoHasRequest.TLimits value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WhoHasRequestTLimitsCodec, T::WhoHasRequest.TLimits>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
