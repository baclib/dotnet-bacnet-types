// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestRequest>
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

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @tokenRequest = AuthRequestRequestTTokenRequestCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuthRequestRequest.FromTokenRequest(@tokenRequest);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuthRequestRequest.Option.TokenRequest:
                AuthRequestRequestTTokenRequestCodec.Encode(ref writer, 0, value.TokenRequest);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
        => AsduConstructed.Encode<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AuthRequestRequest.Option.TokenRequest
                => AuthRequestRequestTTokenRequestCodec.GetEncodedLength(value.TokenRequest, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuthRequestRequest value, byte tagNumber)
        => AsduElement.GetEncodedLength<AuthRequestRequestCodec, global::Baclib.Bacnet.Types.Application.AuthRequestRequest>(tagNumber, value);
}
