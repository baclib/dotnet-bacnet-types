// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationServerCodec :
    IAsduElementCodec<T::AuthorizationServer>,
    IAsduConstructedCodec<T::AuthorizationServer>
{
    public static T::AuthorizationServer Decode(ref AsduReader reader)
    {
        return new T::AuthorizationServer
        {
            AuthServer = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 0),
            SigningKey1 = AsduElement.DecodeOptional<OctetStringCodec, T::OctetString>(ref reader, 1),
            SigningKey2 = AsduElement.DecodeOptional<OctetStringCodec, T::OctetString>(ref reader, 2)
        };
    }

    public static T::AuthorizationServer Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationServerCodec, T::AuthorizationServer>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationServer value)
    {
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 0, value.AuthServer);
        AsduElement.EncodeOptional<OctetStringCodec, T::OctetString>(ref writer, 1, value.SigningKey1);
        AsduElement.EncodeOptional<OctetStringCodec, T::OctetString>(ref writer, 2, value.SigningKey2);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationServer value)
        => AsduConstructed.Encode<AuthorizationServerCodec, T::AuthorizationServer>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationServer value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(0, value.AuthServer);
        length += AsduElement.GetOptionalEncodedLength<OctetStringCodec, T::OctetString>(1, value.SigningKey1);
        length += AsduElement.GetOptionalEncodedLength<OctetStringCodec, T::OctetString>(2, value.SigningKey2);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationServer value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationServerCodec, T::AuthorizationServer>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
