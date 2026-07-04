// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationFactorCodec :
    IAsduElementCodec<T::AuthenticationFactor>,
    IAsduConstructedCodec<T::AuthenticationFactor>
{
    public static T::AuthenticationFactor Decode(ref AsduReader reader)
    {
        return new T::AuthenticationFactor
        {
            FormatType = AsduElement.Decode<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(ref reader, 0),
            FormatClass = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            Value = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 2)
        };
    }

    public static T::AuthenticationFactor Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationFactorCodec, T::AuthenticationFactor>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationFactor value)
    {
        AsduElement.Encode<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(ref writer, 0, value.FormatType);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.FormatClass);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 2, value.Value);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationFactor value)
        => AsduConstructed.Encode<AuthenticationFactorCodec, T::AuthenticationFactor>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationFactor value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AuthenticationFactorTypeCodec, T::AuthenticationFactorType>(0, value.FormatType);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.FormatClass);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(2, value.Value);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationFactor value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationFactorCodec, T::AuthenticationFactor>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
