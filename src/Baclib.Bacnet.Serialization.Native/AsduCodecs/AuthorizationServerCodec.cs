// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationServerCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationServer>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationServer>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationServer Decode(ref NativeReader reader)
    {
        var _authServer = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _signingKey1 = Asdu.DecodeOptional<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 1);
        var _signingKey2 = Asdu.DecodeOptional<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.AuthorizationServer
        {
            AuthServer = _authServer,
            SigningKey1 = _signingKey1,
            SigningKey2 = _signingKey2
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationServer Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationServer value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.AuthServer);
        if (value.SigningKey1.HasValue)
        {
            Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 1, value.SigningKey1.Value);
        }
        if (value.SigningKey2.HasValue)
        {
            Asdu.EncodePrimitive<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, 2, value.SigningKey2.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationServer value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationServer value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.AuthServer) + (value.SigningKey1.HasValue ? Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(1, value.SigningKey1.Value) : 0) + (value.SigningKey2.HasValue ? Asdu.GetPrimitiveLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(2, value.SigningKey2.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationServer value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
