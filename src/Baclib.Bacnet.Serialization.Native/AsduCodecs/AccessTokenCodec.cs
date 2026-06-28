// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccessTokenCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AccessToken>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AccessToken>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AccessToken Decode(ref NativeReader reader)
    {
        var _issuer = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _issued = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 1);
        var _audience = Asdu.DecodeSequenceOf<Integer32Codec, int>(ref reader, 2);
        var _notBefore = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 3);
        var _notAfter = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 4);
        var _client = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 5);
        var _constraint = Asdu.DecodeConstructed<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(ref reader, 6);
        var _scope = Asdu.DecodeConstructed<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref reader, 7);
        var _keyId = Asdu.DecodePrimitive<Unsigned8Codec, byte>(ref reader, 8);
        var _signature = Asdu.DecodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 9);

        return new global::Baclib.Bacnet.Types.Application.AccessToken
        {
            Issuer = _issuer,
            Issued = _issued,
            Audience = _audience,
            NotBefore = _notBefore,
            NotAfter = _notAfter,
            Client = _client,
            Constraint = _constraint,
            Scope = _scope,
            KeyId = _keyId,
            Signature = _signature
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AccessToken Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AccessToken value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.Issuer);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 1, value.Issued);
        writer.WriteOpeningTag(2);
        foreach (var item in value.Audience)
        {
            Asdu.EncodeElement<Integer32Codec, int>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
        if (value.NotBefore.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 3, value.NotBefore.Value);
        }
        if (value.NotAfter.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 4, value.NotAfter.Value);
        }
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 5, value.Client);
        Asdu.EncodeElement<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(ref writer, 6, value.Constraint);
        Asdu.EncodeElement<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref writer, 7, value.Scope);
        Asdu.EncodePrimitive<Unsigned8Codec, byte>(ref writer, 8, value.KeyId);
        Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 9, value.Signature);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AccessToken value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccessToken value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.Issuer) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(1, value.Issued) + (AsduLength.FromTagNumber((byte)2) + (value.Audience.Items.Sum(static item => Asdu.GetElementLength<Integer32Codec, int>(2, item))) + AsduLength.FromTagNumber((byte)2)) + (value.NotBefore.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(3, value.NotBefore.Value) : 0) + (value.NotAfter.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(4, value.NotAfter.Value) : 0) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(5, value.Client) + Asdu.GetElementLength<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(6, value.Constraint) + Asdu.GetElementLength<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(7, value.Scope) + Asdu.GetPrimitiveLength<Unsigned8Codec, byte>(8, value.KeyId) + Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(9, value.Signature);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AccessToken value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
