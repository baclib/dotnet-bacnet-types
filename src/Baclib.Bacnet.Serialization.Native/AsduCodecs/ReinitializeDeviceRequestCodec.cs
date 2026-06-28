// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReinitializeDeviceRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest Decode(ref NativeReader reader)
    {
        var _reinitializedStateOfDevice = Asdu.DecodePrimitive<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TReinitializedStateOfDevice>(ref reader, 0);
        var _password = Asdu.DecodeOptional<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest
        {
            ReinitializedStateOfDevice = _reinitializedStateOfDevice,
            Password = _password
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest value)
    {
        Asdu.EncodePrimitive<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TReinitializedStateOfDevice>(ref writer, 0, value.ReinitializedStateOfDevice);
        if (value.Password.HasValue)
        {
            Asdu.EncodePrimitive<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(ref writer, 1, value.Password.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest value)
    {
        return Asdu.GetPrimitiveLength<ReinitializeDeviceRequestTReinitializedStateOfDeviceCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TReinitializedStateOfDevice>(0, value.ReinitializedStateOfDevice) + (value.Password.HasValue ? Asdu.GetPrimitiveLength<ReinitializeDeviceRequestTPasswordCodec, global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest.TPassword>(1, value.Password.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReinitializeDeviceRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
