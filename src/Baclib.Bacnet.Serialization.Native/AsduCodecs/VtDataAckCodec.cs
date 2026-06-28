// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtDataAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtDataAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtDataAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.VtDataAck Decode(ref NativeReader reader)
    {
        var _allNewDataAccepted = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 0);
        var _acceptedOctetCount = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.VtDataAck
        {
            AllNewDataAccepted = _allNewDataAccepted,
            AcceptedOctetCount = _acceptedOctetCount
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtDataAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtDataAck value)
    {
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 0, value.AllNewDataAccepted);
        if (value.AcceptedOctetCount.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.AcceptedOctetCount.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtDataAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtDataAck value)
    {
        return Asdu.GetPrimitiveLength<BooleanCodec, bool>(0, value.AllNewDataAccepted) + (value.AcceptedOctetCount.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.AcceptedOctetCount.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtDataAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
