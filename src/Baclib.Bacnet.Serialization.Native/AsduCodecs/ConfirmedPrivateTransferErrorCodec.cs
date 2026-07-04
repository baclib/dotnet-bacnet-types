// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedPrivateTransferErrorCodec :
    IAsduElementCodec<T::ConfirmedPrivateTransferError>,
    IAsduConstructedCodec<T::ConfirmedPrivateTransferError>
{
    public static T::ConfirmedPrivateTransferError Decode(ref AsduReader reader)
    {
        return new T::ConfirmedPrivateTransferError
        {
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 0),
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 1),
            ServiceNumber = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            ErrorParameters = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader, 3)
        };
    }

    public static T::ConfirmedPrivateTransferError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedPrivateTransferErrorCodec, T::ConfirmedPrivateTransferError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedPrivateTransferError value)
    {
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 0, value.ErrorType);
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 1, value.VendorId);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.ServiceNumber);
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, 3, value.ErrorParameters);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedPrivateTransferError value)
        => AsduConstructed.Encode<ConfirmedPrivateTransferErrorCodec, T::ConfirmedPrivateTransferError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedPrivateTransferError value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(0, value.ErrorType);
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(1, value.VendorId);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.ServiceNumber);
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(3, value.ErrorParameters);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedPrivateTransferError value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedPrivateTransferErrorCodec, T::ConfirmedPrivateTransferError>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
