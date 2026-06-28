// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class DeviceCommunicationControlRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)1);
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest Decode(ref NativeReader reader)
    {
        var _timeDuration = Asdu.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 0);
        var _enableDisable = Asdu.DecodePrimitive<DeviceCommunicationControlRequestTEnableDisableCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TEnableDisable>(ref reader, 1);
        var _password = Asdu.DecodeOptional<DeviceCommunicationControlRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TPassword>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest
        {
            TimeDuration = _timeDuration,
            EnableDisable = _enableDisable,
            Password = _password
        };
    }

    public static global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest value)
    {
        if (value.TimeDuration.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.TimeDuration.Value);
        }
        Asdu.EncodePrimitive<DeviceCommunicationControlRequestTEnableDisableCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TEnableDisable>(ref writer, 1, value.EnableDisable);
        if (value.Password.HasValue)
        {
            Asdu.EncodePrimitive<DeviceCommunicationControlRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TPassword>(ref writer, 2, value.Password.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest value)
    {
        return (value.TimeDuration.HasValue ? Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.TimeDuration.Value) : 0) + Asdu.GetPrimitiveLength<DeviceCommunicationControlRequestTEnableDisableCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TEnableDisable>(1, value.EnableDisable) + (value.Password.HasValue ? Asdu.GetPrimitiveLength<DeviceCommunicationControlRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest.TPassword>(2, value.Password.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.DeviceCommunicationControlRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
