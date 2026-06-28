// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationClientCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationClient>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationClient>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(BooleanCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationClient Decode(ref NativeReader reader)
    {
        var _authenticated = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader);
        var _device = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationClient
        {
            Authenticated = _authenticated,
            Device = _device
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationClient Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationClient value)
    {
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, value.Authenticated);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, value.Device);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationClient value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationClient value)
    {
        return Asdu.GetEncodedLength<BooleanCodec, bool>(value.Authenticated) + Asdu.GetEncodedLength<Unsigned32Codec, uint>(value.Device);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationClient value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
