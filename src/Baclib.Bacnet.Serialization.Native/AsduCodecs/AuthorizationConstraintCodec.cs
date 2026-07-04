// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationConstraintCodec :
    IAsduElementCodec<T::AuthorizationConstraint>,
    IAsduConstructedCodec<T::AuthorizationConstraint>
{
    public static T::AuthorizationConstraint Decode(ref AsduReader reader)
    {
        return new T::AuthorizationConstraint
        {
            Origin = AsduElement.Decode<AuthorizationConstraintTOriginCodec, T::AuthorizationConstraint.TOrigin>(ref reader),
            Authentication = AsduElement.Decode<AuthorizationConstraintTAuthenticationCodec, T::AuthorizationConstraint.TAuthentication>(ref reader)
        };
    }

    public static T::AuthorizationConstraint Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationConstraint value)
    {
        AsduElement.Encode<AuthorizationConstraintTOriginCodec, T::AuthorizationConstraint.TOrigin>(ref writer, value.Origin);
        AsduElement.Encode<AuthorizationConstraintTAuthenticationCodec, T::AuthorizationConstraint.TAuthentication>(ref writer, value.Authentication);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationConstraint value)
        => AsduConstructed.Encode<AuthorizationConstraintCodec, T::AuthorizationConstraint>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationConstraint value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AuthorizationConstraintTOriginCodec, T::AuthorizationConstraint.TOrigin>(value.Origin);
        length += AsduElement.GetEncodedLength<AuthorizationConstraintTAuthenticationCodec, T::AuthorizationConstraint.TAuthentication>(value.Authentication);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationConstraint value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationConstraintCodec, T::AuthorizationConstraint>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return AuthorizationConstraintTOriginCodec.Matches(ref reader);
    }
}
