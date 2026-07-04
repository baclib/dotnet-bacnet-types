// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtDataAckCodec :
    IAsduElementCodec<T::VtDataAck>,
    IAsduConstructedCodec<T::VtDataAck>
{
    public static T::VtDataAck Decode(ref AsduReader reader)
    {
        return new T::VtDataAck
        {
            AllNewDataAccepted = AsduElement.Decode<BooleanCodec, bool>(ref reader, 0),
            AcceptedOctetCount = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 1)
        };
    }

    public static T::VtDataAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtDataAckCodec, T::VtDataAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtDataAck value)
    {
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 0, value.AllNewDataAccepted);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 1, value.AcceptedOctetCount);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtDataAck value)
        => AsduConstructed.Encode<VtDataAckCodec, T::VtDataAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtDataAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(0, value.AllNewDataAccepted);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(1, value.AcceptedOctetCount);
        return length;
    }

    public static int GetEncodedLength(in T::VtDataAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtDataAckCodec, T::VtDataAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
