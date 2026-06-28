// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestAck>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.AuthRequestAck Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _tokenResponse = Asdu.DecodeConstructed<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuthRequestAck.FromTokenResponse(_tokenResponse);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestAck.Option.TokenResponse:
                Asdu.EncodeConstructed<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(ref writer, 0, value.TokenResponse);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestAck.Option.TokenResponse:
                return Asdu.GetConstructedLength<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(0, value.TokenResponse);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}