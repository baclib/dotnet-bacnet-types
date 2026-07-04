// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationFactorFormatCodec :
    IAsduElementCodec<T::AuthenticationFactorFormat>,
    IAsduConstructedCodec<T::AuthenticationFactorFormat>
{
    public static T::AuthenticationFactorFormat Decode(ref AsduReader reader)
    {
        return new T::AuthenticationFactorFormat
        {
            FormatType = AsduElement.Decode<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(ref reader, 0),
            VendorId = AsduElement.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 1),
            VendorFormat = AsduElement.DecodeOptional<Unsigned16Codec, ushort>(ref reader, 2)
        };
    }

    public static T::AuthenticationFactorFormat Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationFactorFormatCodec, T::AuthenticationFactorFormat>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationFactorFormat value)
    {
        AsduElement.Encode<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(ref writer, 0, value.FormatType);
        AsduElement.EncodeOptional<Unsigned16Codec, ushort>(ref writer, 1, value.VendorId);
        AsduElement.EncodeOptional<Unsigned16Codec, ushort>(ref writer, 2, value.VendorFormat);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationFactorFormat value)
        => AsduConstructed.Encode<AuthenticationFactorFormatCodec, T::AuthenticationFactorFormat>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationFactorFormat value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(0, value.FormatType);
        length += AsduElement.GetOptionalEncodedLength<Unsigned16Codec, ushort>(1, value.VendorId);
        length += AsduElement.GetOptionalEncodedLength<Unsigned16Codec, ushort>(2, value.VendorFormat);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationFactorFormat value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationFactorFormatCodec, T::AuthenticationFactorFormat>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
