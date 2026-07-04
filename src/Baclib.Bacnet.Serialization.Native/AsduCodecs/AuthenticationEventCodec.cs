// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationEventCodec :
    IAsduElementCodec<T::AuthenticationEvent>,
    IAsduConstructedCodec<T::AuthenticationEvent>
{
    public static T::AuthenticationEvent Decode(ref AsduReader reader)
    {
        return new T::AuthenticationEvent
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            Peer = AsduElement.Decode<AuthenticationPeerCodec, T::AuthenticationPeer>(ref reader, 1),
            Client = AsduElement.Decode<AuthenticationClientCodec, T::AuthenticationClient>(ref reader, 2),
            Decision = AsduElement.Decode<AuthenticationDecisionCodec, T::AuthenticationDecision>(ref reader, 3),
            DecisionDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 4)
        };
    }

    public static T::AuthenticationEvent Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthenticationEventCodec, T::AuthenticationEvent>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthenticationEvent value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<AuthenticationPeerCodec, T::AuthenticationPeer>(ref writer, 1, value.Peer);
        AsduElement.Encode<AuthenticationClientCodec, T::AuthenticationClient>(ref writer, 2, value.Client);
        AsduElement.Encode<AuthenticationDecisionCodec, T::AuthenticationDecision>(ref writer, 3, value.Decision);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 4, value.DecisionDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthenticationEvent value)
        => AsduConstructed.Encode<AuthenticationEventCodec, T::AuthenticationEvent>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthenticationEvent value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<AuthenticationPeerCodec, T::AuthenticationPeer>(1, value.Peer);
        length += AsduElement.GetEncodedLength<AuthenticationClientCodec, T::AuthenticationClient>(2, value.Client);
        length += AsduElement.GetEncodedLength<AuthenticationDecisionCodec, T::AuthenticationDecision>(3, value.Decision);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(4, value.DecisionDetails);
        return length;
    }

    public static int GetEncodedLength(in T::AuthenticationEvent value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthenticationEventCodec, T::AuthenticationEvent>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
