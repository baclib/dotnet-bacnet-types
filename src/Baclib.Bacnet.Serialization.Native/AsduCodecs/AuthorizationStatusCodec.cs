// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationStatusCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationStatus>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationStatus>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationStatus Decode(ref NativeReader reader)
    {
        var _posture = Asdu.DecodePrimitive<AuthorizationPostureCodec, global::Baclib.Bacnet.Types.Application.AuthorizationPosture>(ref reader, 0);
        var _error = Asdu.DecodeOptionalElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 1);
        var _errorSource = Asdu.DecodeOptionalElement<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref reader, 2);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 3);
        var _authenticationSuccess = reader.PeekOpeningTag(4) ? Asdu.DecodeSequenceOf<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(ref reader, 4) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.AuthenticationEvent>>.None;
        var _authenticationFailure = reader.PeekOpeningTag(5) ? Asdu.DecodeSequenceOf<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(ref reader, 5) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.AuthenticationEvent>>.None;
        var _authorizationSuccess = reader.PeekOpeningTag(6) ? Asdu.DecodeSequenceOf<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(ref reader, 6) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.AuthorizationEvent>>.None;
        var _authorizationFailure = reader.PeekOpeningTag(7) ? Asdu.DecodeSequenceOf<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(ref reader, 7) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.AuthorizationEvent>>.None;

        return new global::Baclib.Bacnet.Types.Application.AuthorizationStatus
        {
            Posture = _posture,
            Error = _error,
            ErrorSource = _errorSource,
            ErrorDetails = _errorDetails,
            AuthenticationSuccess = _authenticationSuccess,
            AuthenticationFailure = _authenticationFailure,
            AuthorizationSuccess = _authorizationSuccess,
            AuthorizationFailure = _authorizationFailure
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationStatus Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationStatus value)
    {
        Asdu.EncodePrimitive<AuthorizationPostureCodec, global::Baclib.Bacnet.Types.Application.AuthorizationPosture>(ref writer, 0, value.Posture);
        if (value.Error.HasValue)
        {
            Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 1, value.Error.Value);
        }
        if (value.ErrorSource.HasValue)
        {
            Asdu.EncodeElement<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(ref writer, 2, value.ErrorSource.Value);
        }
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 3, value.ErrorDetails.Value);
        }
        if (value.AuthenticationSuccess.HasValue)
        {
            writer.WriteOpeningTag(4);
            foreach (var item in value.AuthenticationSuccess.Value)
            {
                Asdu.EncodeElement<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(ref writer, 4, item);
            }
            writer.WriteClosingTag(4);
        }
        if (value.AuthenticationFailure.HasValue)
        {
            writer.WriteOpeningTag(5);
            foreach (var item in value.AuthenticationFailure.Value)
            {
                Asdu.EncodeElement<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(ref writer, 5, item);
            }
            writer.WriteClosingTag(5);
        }
        if (value.AuthorizationSuccess.HasValue)
        {
            writer.WriteOpeningTag(6);
            foreach (var item in value.AuthorizationSuccess.Value)
            {
                Asdu.EncodeElement<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(ref writer, 6, item);
            }
            writer.WriteClosingTag(6);
        }
        if (value.AuthorizationFailure.HasValue)
        {
            writer.WriteOpeningTag(7);
            foreach (var item in value.AuthorizationFailure.Value)
            {
                Asdu.EncodeElement<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(ref writer, 7, item);
            }
            writer.WriteClosingTag(7);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationStatus value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationStatus value)
    {
        return Asdu.GetPrimitiveLength<AuthorizationPostureCodec, global::Baclib.Bacnet.Types.Application.AuthorizationPosture>(0, value.Posture) + (value.Error.HasValue ? Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(1, value.Error.Value) : 0) + (value.ErrorSource.HasValue ? Asdu.GetElementLength<ObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.ObjectPropertyReference>(2, value.ErrorSource.Value) : 0) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(3, value.ErrorDetails.Value) : 0) + (value.AuthenticationSuccess.HasValue ? (AsduLength.FromTagNumber((byte)4) + (value.AuthenticationSuccess.Value.Items.Sum(static item => Asdu.GetElementLength<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(4, item))) + AsduLength.FromTagNumber((byte)4)) : 0) + (value.AuthenticationFailure.HasValue ? (AsduLength.FromTagNumber((byte)5) + (value.AuthenticationFailure.Value.Items.Sum(static item => Asdu.GetElementLength<AuthenticationEventCodec, global::Baclib.Bacnet.Types.Application.AuthenticationEvent>(5, item))) + AsduLength.FromTagNumber((byte)5)) : 0) + (value.AuthorizationSuccess.HasValue ? (AsduLength.FromTagNumber((byte)6) + (value.AuthorizationSuccess.Value.Items.Sum(static item => Asdu.GetElementLength<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(6, item))) + AsduLength.FromTagNumber((byte)6)) : 0) + (value.AuthorizationFailure.HasValue ? (AsduLength.FromTagNumber((byte)7) + (value.AuthorizationFailure.Value.Items.Sum(static item => Asdu.GetElementLength<AuthorizationEventCodec, global::Baclib.Bacnet.Types.Application.AuthorizationEvent>(7, item))) + AsduLength.FromTagNumber((byte)7)) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationStatus value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
