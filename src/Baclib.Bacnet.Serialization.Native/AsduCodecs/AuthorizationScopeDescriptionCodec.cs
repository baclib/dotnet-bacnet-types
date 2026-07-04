// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationScopeDescriptionCodec :
    IAsduElementCodec<T::AuthorizationScopeDescription>,
    IAsduConstructedCodec<T::AuthorizationScopeDescription>
{
    public static T::AuthorizationScopeDescription Decode(ref AsduReader reader)
    {
        return new T::AuthorizationScopeDescription
        {
            Name = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader),
            Description = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader)
        };
    }

    public static T::AuthorizationScopeDescription Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationScopeDescriptionCodec, T::AuthorizationScopeDescription>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationScopeDescription value)
    {
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.Name);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, value.Description);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationScopeDescription value)
        => AsduConstructed.Encode<AuthorizationScopeDescriptionCodec, T::AuthorizationScopeDescription>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationScopeDescription value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.Name);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(value.Description);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationScopeDescription value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationScopeDescriptionCodec, T::AuthorizationScopeDescription>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return CharacterStringCodec.Matches(ref reader);
    }
}
