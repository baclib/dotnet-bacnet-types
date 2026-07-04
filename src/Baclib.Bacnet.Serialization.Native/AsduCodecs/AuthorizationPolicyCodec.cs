// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationPolicyCodec :
    IAsduElementCodec<T::AuthorizationPolicy>,
    IAsduConstructedCodec<T::AuthorizationPolicy>
{
    public static T::AuthorizationPolicy Decode(ref AsduReader reader)
    {
        return new T::AuthorizationPolicy
        {
            NotBefore = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 0),
            NotAfter = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 1),
            Clients = AsduElement.DecodeSequenceOf<Unsigned32Codec, uint>(ref reader, 2),
            Constraint = AsduElement.Decode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref reader, 3),
            Scope = AsduElement.Decode<AuthorizationScopeCodec, T::AuthorizationScope>(ref reader, 4)
        };
    }

    public static T::AuthorizationPolicy Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationPolicyCodec, T::AuthorizationPolicy>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationPolicy value)
    {
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 0, value.NotBefore);
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 1, value.NotAfter);
        AsduElement.EncodeSequenceOf<Unsigned32Codec, uint>(ref writer, 2, value.Clients);
        AsduElement.Encode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref writer, 3, value.Constraint);
        AsduElement.Encode<AuthorizationScopeCodec, T::AuthorizationScope>(ref writer, 4, value.Scope);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationPolicy value)
        => AsduConstructed.Encode<AuthorizationPolicyCodec, T::AuthorizationPolicy>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationPolicy value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(0, value.NotBefore);
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(1, value.NotAfter);
        length += AsduElement.GetSequenceOfEncodedLength<Unsigned32Codec, uint>(2, value.Clients);
        length += AsduElement.GetEncodedLength<AuthorizationConstraintCodec, T::AuthorizationConstraint>(3, value.Constraint);
        length += AsduElement.GetEncodedLength<AuthorizationScopeCodec, T::AuthorizationScope>(4, value.Scope);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationPolicy value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationPolicyCodec, T::AuthorizationPolicy>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        if (reader.PeekContextTag(1))
        {
            return true;
        }
        return reader.PeekContextTag(2);
    }
}
