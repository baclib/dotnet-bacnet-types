// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedPrivateTransferAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _serviceNumber = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _resultBlock = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck
        {
            VendorId = _vendorId,
            ServiceNumber = _serviceNumber,
            ResultBlock = _resultBlock
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.ServiceNumber);
        if (value.ResultBlock.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 2, value.ResultBlock.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.VendorId) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.ServiceNumber) + (value.ResultBlock.HasValue ? Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(2, value.ResultBlock.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
