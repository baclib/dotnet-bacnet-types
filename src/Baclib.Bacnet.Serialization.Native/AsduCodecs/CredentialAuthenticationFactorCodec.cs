// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CredentialAuthenticationFactorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor Decode(ref NativeReader reader)
    {
        var _disable = Asdu.DecodePrimitive<AccessAuthenticationFactorDisableCodec, global::Baclib.Bacnet.Types.Application.AccessAuthenticationFactorDisable>(ref reader, 0);
        var _authenticationFactor = Asdu.DecodeConstructed<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor
        {
            Disable = _disable,
            AuthenticationFactor = _authenticationFactor
        };
    }

    public static global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor value)
    {
        Asdu.EncodePrimitive<AccessAuthenticationFactorDisableCodec, global::Baclib.Bacnet.Types.Application.AccessAuthenticationFactorDisable>(ref writer, 0, value.Disable);
        Asdu.EncodeElement<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(ref writer, 1, value.AuthenticationFactor);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor value)
    {
        return Asdu.GetPrimitiveLength<AccessAuthenticationFactorDisableCodec, global::Baclib.Bacnet.Types.Application.AccessAuthenticationFactorDisable>(0, value.Disable) + Asdu.GetElementLength<AuthenticationFactorCodec, global::Baclib.Bacnet.Types.Application.AuthenticationFactor>(1, value.AuthenticationFactor);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.CredentialAuthenticationFactor value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
