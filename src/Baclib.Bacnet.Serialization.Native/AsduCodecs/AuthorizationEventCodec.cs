// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationEventCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationEvent>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationEvent>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationEvent Decode(ref NativeReader reader)
    {
        var _timestamp = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
        var _address = Asdu.DecodeConstructed<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref reader, 1);
        var _client = Asdu.DecodeOptionalElement<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(ref reader, 2);
        var _token = Asdu.DecodeOptionalElement<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(ref reader, 3);
        var _decision = Asdu.DecodePrimitive<AuthorizationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthorizationDecision>(ref reader, 4);
        var _decisionDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.AuthorizationEvent
        {
            Timestamp = _timestamp,
            Address = _address,
            Client = _client,
            Token = _token,
            Decision = _decision,
            DecisionDetails = _decisionDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationEvent Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationEvent value)
    {
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Timestamp);
        Asdu.EncodeElement<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(ref writer, 1, value.Address);
        if (value.Client.HasValue)
        {
            Asdu.EncodeElement<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(ref writer, 2, value.Client.Value);
        }
        if (value.Token.HasValue)
        {
            Asdu.EncodeElement<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(ref writer, 3, value.Token.Value);
        }
        Asdu.EncodePrimitive<AuthorizationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthorizationDecision>(ref writer, 4, value.Decision);
        if (value.DecisionDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 5, value.DecisionDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationEvent value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationEvent value)
    {
        return Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Timestamp) + Asdu.GetElementLength<AddressCodec, global::Baclib.Bacnet.Types.Application.Address>(1, value.Address) + (value.Client.HasValue ? Asdu.GetElementLength<AuthenticationClientCodec, global::Baclib.Bacnet.Types.Application.AuthenticationClient>(2, value.Client.Value) : 0) + (value.Token.HasValue ? Asdu.GetElementLength<AccessTokenCodec, global::Baclib.Bacnet.Types.Application.AccessToken>(3, value.Token.Value) : 0) + Asdu.GetPrimitiveLength<AuthorizationDecisionCodec, global::Baclib.Bacnet.Types.Application.AuthorizationDecision>(4, value.Decision) + (value.DecisionDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(5, value.DecisionDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationEvent value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
