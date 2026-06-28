// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtDataRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.VtDataRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.VtDataRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned8Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.VtDataRequest Decode(ref NativeReader reader)
    {
        var _vtSessionIdentifier = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader);
        var _vtNewData = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
        var _vtDataFlag = Asdu.DecodePrimitive<VtDataRequestTVtDataFlagCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest.TVtDataFlag>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.VtDataRequest
        {
            VtSessionIdentifier = _vtSessionIdentifier,
            VtNewData = _vtNewData,
            VtDataFlag = _vtDataFlag
        };
    }

    public static global::Baclib.Bacnet.Types.Application.VtDataRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.VtDataRequest value)
    {
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, value.VtSessionIdentifier);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.VtNewData);
        Asdu.EncodePrimitive<VtDataRequestTVtDataFlagCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest.TVtDataFlag>(ref writer, value.VtDataFlag);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.VtDataRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtDataRequest value)
    {
        return Asdu.GetEncodedLength<Unsigned8Codec, byte>(value.VtSessionIdentifier) + Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.VtNewData) + Asdu.GetEncodedLength<VtDataRequestTVtDataFlagCodec, global::Baclib.Bacnet.Types.Application.VtDataRequest.TVtDataFlag>(value.VtDataFlag);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.VtDataRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
