// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoAmIRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WhoAmIRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WhoAmIRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned16Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.WhoAmIRequest Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader);
        var _modelName = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
        var _serialNumber = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.WhoAmIRequest
        {
            VendorId = _vendorId,
            ModelName = _modelName,
            SerialNumber = _serialNumber
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WhoAmIRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WhoAmIRequest value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, value.VendorId);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.ModelName);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.SerialNumber);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WhoAmIRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoAmIRequest value)
    {
        return Asdu.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.ModelName) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.SerialNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WhoAmIRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
