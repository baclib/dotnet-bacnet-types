// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestAck>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestAck Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @tokenResponse = AccessTokenCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuthRequestAck.FromTokenResponse(@tokenResponse);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestAck.Option.TokenResponse:
                AccessTokenCodec.Encode(ref writer, 0, value.TokenResponse);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
        => AsduConstructed.Encode<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuthRequestAck value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AuthRequestAck.Option.TokenResponse
                => AccessTokenCodec.GetEncodedLength(value.TokenResponse, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuthRequestAck value, byte tagNumber)
        => AsduElement.GetEncodedLength<AuthRequestAckCodec, global::Baclib.Bacnet.Types.Application.AuthRequestAck>(tagNumber, value);
}
