// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AddressCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Address>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Address>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(Unsigned16Codec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.Address Decode(ref NativeReader reader)
    {
        var _networkNumber = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader);
        var _macAddress = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.Address
        {
            NetworkNumber = _networkNumber,
            MacAddress = _macAddress
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Address Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Address value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, value.NetworkNumber);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.MacAddress);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Address value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Address value)
    {
        return Asdu.GetEncodedLength<Unsigned16Codec, ushort>(value.NetworkNumber) + Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.MacAddress);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Address value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
