// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReinitializeDeviceRequestCodec :
    IAsduElementCodec<T::ReinitializeDeviceRequest>,
    IAsduConstructedCodec<T::ReinitializeDeviceRequest>
{
    public static T::ReinitializeDeviceRequest Decode(ref AsduReader reader)
    {
        return new T::ReinitializeDeviceRequest
        {
            ReinitializedStateOfDevice = AsduElement.Decode<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, T::ReinitializeDeviceRequest.TReinitializedStateOfDevice>(ref reader, 0),
            Password = AsduElement.DecodeOptional<ReinitializeDeviceRequestTPasswordCodec, T::ReinitializeDeviceRequest.TPassword>(ref reader, 1)
        };
    }

    public static T::ReinitializeDeviceRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReinitializeDeviceRequestCodec, T::ReinitializeDeviceRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReinitializeDeviceRequest value)
    {
        AsduElement.Encode<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, T::ReinitializeDeviceRequest.TReinitializedStateOfDevice>(ref writer, 0, value.ReinitializedStateOfDevice);
        AsduElement.EncodeOptional<ReinitializeDeviceRequestTPasswordCodec, T::ReinitializeDeviceRequest.TPassword>(ref writer, 1, value.Password);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReinitializeDeviceRequest value)
        => AsduConstructed.Encode<ReinitializeDeviceRequestCodec, T::ReinitializeDeviceRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReinitializeDeviceRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, T::ReinitializeDeviceRequest.TReinitializedStateOfDevice>(0, value.ReinitializedStateOfDevice);
        length += AsduElement.GetOptionalEncodedLength<ReinitializeDeviceRequestTPasswordCodec, T::ReinitializeDeviceRequest.TPassword>(1, value.Password);
        return length;
    }

    public static int GetEncodedLength(in T::ReinitializeDeviceRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReinitializeDeviceRequestCodec, T::ReinitializeDeviceRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
