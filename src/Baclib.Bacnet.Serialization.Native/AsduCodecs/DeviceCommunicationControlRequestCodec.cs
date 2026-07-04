// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceCommunicationControlRequestCodec :
    IAsduElementCodec<T::DeviceCommunicationControlRequest>,
    IAsduConstructedCodec<T::DeviceCommunicationControlRequest>
{
    public static T::DeviceCommunicationControlRequest Decode(ref AsduReader reader)
    {
        return new T::DeviceCommunicationControlRequest
        {
            TimeDuration = AsduElement.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 0),
            EnableDisable = AsduElement.Decode<DeviceCommunicationControlRequestTEnableDisableCodec, T::DeviceCommunicationControlRequest.TEnableDisable>(ref reader, 1),
            Password = AsduElement.DecodeOptional<DeviceCommunicationControlRequestTPasswordCodec, T::DeviceCommunicationControlRequest.TPassword>(ref reader, 2)
        };
    }

    public static T::DeviceCommunicationControlRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<DeviceCommunicationControlRequestCodec, T::DeviceCommunicationControlRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::DeviceCommunicationControlRequest value)
    {
        AsduElement.EncodeOptional<Unsigned16Codec, ushort>(ref writer, 0, value.TimeDuration);
        AsduElement.Encode<DeviceCommunicationControlRequestTEnableDisableCodec, T::DeviceCommunicationControlRequest.TEnableDisable>(ref writer, 1, value.EnableDisable);
        AsduElement.EncodeOptional<DeviceCommunicationControlRequestTPasswordCodec, T::DeviceCommunicationControlRequest.TPassword>(ref writer, 2, value.Password);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::DeviceCommunicationControlRequest value)
        => AsduConstructed.Encode<DeviceCommunicationControlRequestCodec, T::DeviceCommunicationControlRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::DeviceCommunicationControlRequest value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<Unsigned16Codec, ushort>(0, value.TimeDuration);
        length += AsduElement.GetEncodedLength<DeviceCommunicationControlRequestTEnableDisableCodec, T::DeviceCommunicationControlRequest.TEnableDisable>(1, value.EnableDisable);
        length += AsduElement.GetOptionalEncodedLength<DeviceCommunicationControlRequestTPasswordCodec, T::DeviceCommunicationControlRequest.TPassword>(2, value.Password);
        return length;
    }

    public static int GetEncodedLength(in T::DeviceCommunicationControlRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<DeviceCommunicationControlRequestCodec, T::DeviceCommunicationControlRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        return reader.PeekContextTag(1);
    }
}
