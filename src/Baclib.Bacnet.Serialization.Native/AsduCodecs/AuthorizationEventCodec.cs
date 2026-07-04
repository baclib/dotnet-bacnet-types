// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationEventCodec :
    IAsduElementCodec<T::AuthorizationEvent>,
    IAsduConstructedCodec<T::AuthorizationEvent>
{
    public static T::AuthorizationEvent Decode(ref AsduReader reader)
    {
        return new T::AuthorizationEvent
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            Address = AsduElement.Decode<AddressCodec, T::Address>(ref reader, 1),
            Client = AsduElement.DecodeOptional<AuthenticationClientCodec, T::AuthenticationClient>(ref reader, 2),
            Token = AsduElement.DecodeOptional<AccessTokenCodec, T::AccessToken>(ref reader, 3),
            Decision = AsduElement.Decode<AuthorizationDecisionCodec, T::AuthorizationDecision>(ref reader, 4),
            DecisionDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 5)
        };
    }

    public static T::AuthorizationEvent Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationEventCodec, T::AuthorizationEvent>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationEvent value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<AddressCodec, T::Address>(ref writer, 1, value.Address);
        AsduElement.EncodeOptional<AuthenticationClientCodec, T::AuthenticationClient>(ref writer, 2, value.Client);
        AsduElement.EncodeOptional<AccessTokenCodec, T::AccessToken>(ref writer, 3, value.Token);
        AsduElement.Encode<AuthorizationDecisionCodec, T::AuthorizationDecision>(ref writer, 4, value.Decision);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 5, value.DecisionDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationEvent value)
        => AsduConstructed.Encode<AuthorizationEventCodec, T::AuthorizationEvent>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationEvent value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<AddressCodec, T::Address>(1, value.Address);
        length += AsduElement.GetOptionalEncodedLength<AuthenticationClientCodec, T::AuthenticationClient>(2, value.Client);
        length += AsduElement.GetOptionalEncodedLength<AccessTokenCodec, T::AccessToken>(3, value.Token);
        length += AsduElement.GetEncodedLength<AuthorizationDecisionCodec, T::AuthorizationDecision>(4, value.Decision);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(5, value.DecisionDetails);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationEvent value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationEventCodec, T::AuthorizationEvent>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
