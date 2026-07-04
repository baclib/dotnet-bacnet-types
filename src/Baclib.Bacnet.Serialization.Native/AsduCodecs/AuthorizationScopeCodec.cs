// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationScopeCodec :
    IAsduElementCodec<T::AuthorizationScope>,
    IAsduConstructedCodec<T::AuthorizationScope>
{
    public static T::AuthorizationScope Decode(ref AsduReader reader)
    {
        return new T::AuthorizationScope
        {
            Standard = AsduElement.Decode<AuthorizationScopeTStandardCodec, T::AuthorizationScope.TStandard>(ref reader),
            Extended = AsduElement.DecodeOptionalSequenceOf<CharacterStringCodec, T::CharacterString>(ref reader, 0)
        };
    }

    public static T::AuthorizationScope Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationScopeCodec, T::AuthorizationScope>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationScope value)
    {
        AsduElement.Encode<AuthorizationScopeTStandardCodec, T::AuthorizationScope.TStandard>(ref writer, value.Standard);
        AsduElement.EncodeOptionalSequenceOf<CharacterStringCodec, T::CharacterString>(ref writer, 0, value.Extended);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationScope value)
        => AsduConstructed.Encode<AuthorizationScopeCodec, T::AuthorizationScope>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationScope value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AuthorizationScopeTStandardCodec, T::AuthorizationScope.TStandard>(value.Standard);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<CharacterStringCodec, T::CharacterString>(0, value.Extended);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationScope value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationScopeCodec, T::AuthorizationScope>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return AuthorizationScopeTStandardCodec.Matches(ref reader);
    }
}
