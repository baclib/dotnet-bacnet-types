// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestRequestTTokenRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest Decode(ref NativeReader reader)
    {
        var _client = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _audience = Asdu.DecodeSequenceOf<Integer32Codec, int>(ref reader, 1);
        var _scope = Asdu.DecodeConstructed<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest
        {
            Client = _client,
            Audience = _audience,
            Scope = _scope
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.Client);
        writer.WriteOpeningTag(1);
        foreach (var item in value.Audience)
        {
            Asdu.EncodeElement<Integer32Codec, int>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
        Asdu.EncodeElement<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref writer, 2, value.Scope);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.Client) + (AsduLength.FromTagNumber((byte)1) + (value.Audience.Items.Sum(static item => Asdu.GetElementLength<Integer32Codec, int>(1, item))) + AsduLength.FromTagNumber((byte)1)) + Asdu.GetElementLength<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(2, value.Scope);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
