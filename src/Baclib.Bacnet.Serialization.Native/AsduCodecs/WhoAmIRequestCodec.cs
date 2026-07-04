// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WhoAmIRequestCodec :
    IAsduElementCodec<T::WhoAmIRequest>,
    IAsduConstructedCodec<T::WhoAmIRequest>
{
    public static T::WhoAmIRequest Decode(ref AsduReader reader)
    {
        return new T::WhoAmIRequest
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader),
            ModelName = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader),
            SerialNumber = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader)
        };
    }

    public static T::WhoAmIRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WhoAmIRequestCodec, T::WhoAmIRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WhoAmIRequest value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, value.VendorId);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.ModelName);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.SerialNumber);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WhoAmIRequest value)
        => AsduConstructed.Encode<WhoAmIRequestCodec, T::WhoAmIRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WhoAmIRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(value.VendorId);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.ModelName);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.SerialNumber);
        return length;
    }

    public static int GetEncodedLength(in T::WhoAmIRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WhoAmIRequestCodec, T::WhoAmIRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return Unsigned16Codec.Matches(ref reader);
    }
}
