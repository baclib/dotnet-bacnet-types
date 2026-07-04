// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestRequestTTokenRequestCodec :
    IAsduElementCodec<T::AuthRequestRequest.TTokenRequest>,
    IAsduConstructedCodec<T::AuthRequestRequest.TTokenRequest>
{
    public static T::AuthRequestRequest.TTokenRequest Decode(ref AsduReader reader)
    {
        return new T::AuthRequestRequest.TTokenRequest
        {
            Client = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            Audience = AsduElement.DecodeSequenceOf<Integer32Codec, int>(ref reader, 1),
            Scope = AsduElement.Decode<AuthorizationScopeCodec, T::AuthorizationScope>(ref reader, 2)
        };
    }

    public static T::AuthRequestRequest.TTokenRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthRequestRequestTTokenRequestCodec, T::AuthRequestRequest.TTokenRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthRequestRequest.TTokenRequest value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.Client);
        AsduElement.EncodeSequenceOf<Integer32Codec, int>(ref writer, 1, value.Audience);
        AsduElement.Encode<AuthorizationScopeCodec, T::AuthorizationScope>(ref writer, 2, value.Scope);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthRequestRequest.TTokenRequest value)
        => AsduConstructed.Encode<AuthRequestRequestTTokenRequestCodec, T::AuthRequestRequest.TTokenRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthRequestRequest.TTokenRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.Client);
        length += AsduElement.GetSequenceOfEncodedLength<Integer32Codec, int>(1, value.Audience);
        length += AsduElement.GetEncodedLength<AuthorizationScopeCodec, T::AuthorizationScope>(2, value.Scope);
        return length;
    }

    public static int GetEncodedLength(in T::AuthRequestRequest.TTokenRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthRequestRequestTTokenRequestCodec, T::AuthRequestRequest.TTokenRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
