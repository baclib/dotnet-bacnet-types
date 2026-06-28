// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedPrivateTransferErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError Decode(ref NativeReader reader)
    {
        var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 0);
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 1);
        var _serviceNumber = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 2);
        var _errorParameters = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError
        {
            ErrorType = _errorType,
            VendorId = _vendorId,
            ServiceNumber = _serviceNumber,
            ErrorParameters = _errorParameters
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError value)
    {
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 0, value.ErrorType);
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 1, value.VendorId);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.ServiceNumber);
        if (value.ErrorParameters.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 3, value.ErrorParameters.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError value)
    {
        return Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(0, value.ErrorType) + Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(1, value.VendorId) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.ServiceNumber) + (value.ErrorParameters.HasValue ? Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(3, value.ErrorParameters.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedPrivateTransferError value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
