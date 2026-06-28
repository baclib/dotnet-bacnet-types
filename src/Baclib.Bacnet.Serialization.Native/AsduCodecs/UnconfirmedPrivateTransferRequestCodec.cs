// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UnconfirmedPrivateTransferRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _serviceNumber = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _serviceParameters = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest
        {
            VendorId = _vendorId,
            ServiceNumber = _serviceNumber,
            ServiceParameters = _serviceParameters
        };
    }

    public static global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.ServiceNumber);
        if (value.ServiceParameters.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 2, value.ServiceParameters.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.VendorId) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.ServiceNumber) + (value.ServiceParameters.HasValue ? Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(2, value.ServiceParameters.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.UnconfirmedPrivateTransferRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
