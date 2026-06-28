// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationConstraintCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationConstraint>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(AuthorizationConstraintTOriginCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationConstraint Decode(ref NativeReader reader)
    {
        var _origin = Asdu.DecodePrimitive<AuthorizationConstraintTOriginCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TOrigin>(ref reader);
        var _authentication = Asdu.DecodePrimitive<AuthorizationConstraintTAuthenticationCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TAuthentication>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AuthorizationConstraint
        {
            Origin = _origin,
            Authentication = _authentication
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationConstraint Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationConstraint value)
    {
        Asdu.EncodePrimitive<AuthorizationConstraintTOriginCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TOrigin>(ref writer, value.Origin);
        Asdu.EncodePrimitive<AuthorizationConstraintTAuthenticationCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TAuthentication>(ref writer, value.Authentication);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationConstraint value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationConstraint value)
    {
        return Asdu.GetEncodedLength<AuthorizationConstraintTOriginCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TOrigin>(value.Origin) + Asdu.GetEncodedLength<AuthorizationConstraintTAuthenticationCodec, global::Baclib.Bacnet.Types.Application.AuthorizationConstraint.TAuthentication>(value.Authentication);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationConstraint value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
