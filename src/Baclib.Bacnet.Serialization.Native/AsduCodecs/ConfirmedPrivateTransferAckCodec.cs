// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedPrivateTransferAckCodec :
    IAsduElementCodec<T::ConfirmedPrivateTransferAck>,
    IAsduConstructedCodec<T::ConfirmedPrivateTransferAck>
{
    public static T::ConfirmedPrivateTransferAck Decode(ref AsduReader reader)
    {
        return new T::ConfirmedPrivateTransferAck
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            ServiceNumber = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            ResultBlock = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader, 2)
        };
    }

    public static T::ConfirmedPrivateTransferAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ConfirmedPrivateTransferAckCodec, T::ConfirmedPrivateTransferAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ConfirmedPrivateTransferAck value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.ServiceNumber);
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, 2, value.ResultBlock);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ConfirmedPrivateTransferAck value)
        => AsduConstructed.Encode<ConfirmedPrivateTransferAckCodec, T::ConfirmedPrivateTransferAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ConfirmedPrivateTransferAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.VendorId);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.ServiceNumber);
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(2, value.ResultBlock);
        return length;
    }

    public static int GetEncodedLength(in T::ConfirmedPrivateTransferAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ConfirmedPrivateTransferAckCodec, T::ConfirmedPrivateTransferAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
