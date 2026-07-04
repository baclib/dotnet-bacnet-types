// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccessTokenCodec :
    IAsduElementCodec<T::AccessToken>,
    IAsduConstructedCodec<T::AccessToken>
{
    public static T::AccessToken Decode(ref AsduReader reader)
    {
        return new T::AccessToken
        {
            Issuer = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            Issued = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 1),
            Audience = AsduElement.DecodeSequenceOf<Integer32Codec, int>(ref reader, 2),
            NotBefore = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 3),
            NotAfter = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 4),
            Client = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 5),
            Constraint = AsduElement.Decode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref reader, 6),
            Scope = AsduElement.Decode<AuthorizationScopeCodec, T::AuthorizationScope>(ref reader, 7),
            KeyId = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 8),
            Signature = AsduElement.Decode<OctetStringCodec, T::OctetString>(ref reader, 9)
        };
    }

    public static T::AccessToken Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AccessTokenCodec, T::AccessToken>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AccessToken value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.Issuer);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 1, value.Issued);
        AsduElement.EncodeSequenceOf<Integer32Codec, int>(ref writer, 2, value.Audience);
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 3, value.NotBefore);
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 4, value.NotAfter);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 5, value.Client);
        AsduElement.Encode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref writer, 6, value.Constraint);
        AsduElement.Encode<AuthorizationScopeCodec, T::AuthorizationScope>(ref writer, 7, value.Scope);
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 8, value.KeyId);
        AsduElement.Encode<OctetStringCodec, T::OctetString>(ref writer, 9, value.Signature);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AccessToken value)
        => AsduConstructed.Encode<AccessTokenCodec, T::AccessToken>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AccessToken value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.Issuer);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(1, value.Issued);
        length += AsduElement.GetSequenceOfEncodedLength<Integer32Codec, int>(2, value.Audience);
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(3, value.NotBefore);
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(4, value.NotAfter);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(5, value.Client);
        length += AsduElement.GetEncodedLength<AuthorizationConstraintCodec, T::AuthorizationConstraint>(6, value.Constraint);
        length += AsduElement.GetEncodedLength<AuthorizationScopeCodec, T::AuthorizationScope>(7, value.Scope);
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(8, value.KeyId);
        length += AsduElement.GetEncodedLength<OctetStringCodec, T::OctetString>(9, value.Signature);
        return length;
    }

    public static int GetEncodedLength(in T::AccessToken value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AccessTokenCodec, T::AccessToken>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
