// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationPolicyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationPolicy>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationPolicy>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(2);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationPolicy Decode(ref NativeReader reader)
    {
        var _notBefore = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _notAfter = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 1);
        var _clients = Asdu.DecodeSequenceOf<Unsigned32Codec, uint>(ref reader, 2);
        var _constraint = Asdu.DecodeConstructed<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(ref reader, 3);
        var _scope = Asdu.DecodeConstructed<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.AuthorizationPolicy
        {
            NotBefore = _notBefore,
            NotAfter = _notAfter,
            Clients = _clients,
            Constraint = _constraint,
            Scope = _scope
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationPolicy Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationPolicy value)
    {
        if (value.NotBefore.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.NotBefore.Value);
        }
        if (value.NotAfter.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 1, value.NotAfter.Value);
        }
        writer.WriteOpeningTag(2);
        foreach (var item in value.Clients)
        {
            Asdu.EncodeElement<Unsigned32Codec, uint>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
        Asdu.EncodeElement<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(ref writer, 3, value.Constraint);
        Asdu.EncodeElement<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(ref writer, 4, value.Scope);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationPolicy value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationPolicy value)
    {
        return (value.NotBefore.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.NotBefore.Value) : 0) + (value.NotAfter.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(1, value.NotAfter.Value) : 0) + (AsduLength.FromTagNumber((byte)2) + (value.Clients.Items.Sum(static item => Asdu.GetElementLength<Unsigned32Codec, uint>(2, item))) + AsduLength.FromTagNumber((byte)2)) + Asdu.GetElementLength<AuthorizationConstraintCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>(3, value.Constraint) + Asdu.GetElementLength<AuthorizationScopeCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope>(4, value.Scope);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationPolicy value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
