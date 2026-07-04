// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AddressCodec :
    IAsduElementCodec<T::Address>,
    IAsduConstructedCodec<T::Address>
{
    public static T::Address Decode(ref AsduReader reader)
    {
        return new T::Address
        {
            NetworkNumber = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader),
            MacAddress = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader)
        };
    }

    public static T::Address Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AddressCodec, T::Address>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::Address value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, value.NetworkNumber);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, value.MacAddress);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::Address value)
        => AsduConstructed.Encode<AddressCodec, T::Address>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::Address value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(value.NetworkNumber);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(value.MacAddress);
        return length;
    }

    public static int GetEncodedLength(in T::Address value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AddressCodec, T::Address>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned16Codec.Matches(ref reader);
    }
}
