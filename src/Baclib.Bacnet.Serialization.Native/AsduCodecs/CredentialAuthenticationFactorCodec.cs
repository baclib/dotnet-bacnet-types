// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CredentialAuthenticationFactorCodec :
    IAsduElementCodec<T::CredentialAuthenticationFactor>,
    IAsduConstructedCodec<T::CredentialAuthenticationFactor>
{
    public static T::CredentialAuthenticationFactor Decode(ref AsduReader reader)
    {
        return new T::CredentialAuthenticationFactor
        {
            Disable = AsduElement.Decode<AccessAuthenticationFactorDisableCodec, T::AccessAuthenticationFactorDisable>(ref reader, 0),
            AuthenticationFactor = AsduElement.Decode<AuthenticationFactorCodec, T::AuthenticationFactor>(ref reader, 1)
        };
    }

    public static T::CredentialAuthenticationFactor Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CredentialAuthenticationFactorCodec, T::CredentialAuthenticationFactor>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CredentialAuthenticationFactor value)
    {
        AsduElement.Encode<AccessAuthenticationFactorDisableCodec, T::AccessAuthenticationFactorDisable>(ref writer, 0, value.Disable);
        AsduElement.Encode<AuthenticationFactorCodec, T::AuthenticationFactor>(ref writer, 1, value.AuthenticationFactor);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CredentialAuthenticationFactor value)
        => AsduConstructed.Encode<CredentialAuthenticationFactorCodec, T::CredentialAuthenticationFactor>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CredentialAuthenticationFactor value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AccessAuthenticationFactorDisableCodec, T::AccessAuthenticationFactorDisable>(0, value.Disable);
        length += AsduElement.GetEncodedLength<AuthenticationFactorCodec, T::AuthenticationFactor>(1, value.AuthenticationFactor);
        return length;
    }

    public static int GetEncodedLength(in T::CredentialAuthenticationFactor value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CredentialAuthenticationFactorCodec, T::CredentialAuthenticationFactor>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
