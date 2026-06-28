// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest>
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

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _tokenRequest = Asdu.DecodeConstructed<AuthRequestRequestTTokenRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuthRequestRequest.FromTokenRequest(_tokenRequest);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestRequest.Option.TokenRequest:
                Asdu.EncodeConstructed<AuthRequestRequestTTokenRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest>(ref writer, 0, value.TokenRequest);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestRequest.Option.TokenRequest:
                return Asdu.GetConstructedLength<AuthRequestRequestTTokenRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest.TTokenRequest>(0, value.TokenRequest);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}