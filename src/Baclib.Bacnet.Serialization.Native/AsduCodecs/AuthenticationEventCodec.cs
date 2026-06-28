// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthenticationEventCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthenticationEvent>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthenticationEvent>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationEvent Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _peer = Asdu.DecodeConstructed<AuthenticationPeerCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPeer>(ref reader, 1);
        var _client = Asdu.DecodeConstructed<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(ref reader, 2);
        var _decision = Asdu.DecodePrimitive<AuthenticationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthenticationDecision>(ref reader, 3);
        var _decisionDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.AuthenticationEvent
        {
            Timestamp = _timestamp,
            Peer = _peer,
            Client = _client,
            Decision = _decision,
            DecisionDetails = _decisionDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthenticationEvent Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthenticationEvent value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<AuthenticationPeerCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPeer>(ref writer, 1, value.Peer);
        Asdu.EncodeElement<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(ref writer, 2, value.Client);
        Asdu.EncodePrimitive<AuthenticationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthenticationDecision>(ref writer, 3, value.Decision);
        if (value.DecisionDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 4, value.DecisionDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthenticationEvent value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationEvent value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<AuthenticationPeerCodec, global::Baclib.Bacnet.Types.Application.AuthenticationPeer>(1, value.Peer) + Asdu.GetElementLength<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(2, value.Client) + Asdu.GetPrimitiveLength<AuthenticationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthenticationDecision>(3, value.Decision) + (value.DecisionDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(4, value.DecisionDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthenticationEvent value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
