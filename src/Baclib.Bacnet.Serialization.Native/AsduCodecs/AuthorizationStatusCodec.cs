// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationStatusCodec :
    IAsduElementCodec<T::AuthorizationStatus>,
    IAsduConstructedCodec<T::AuthorizationStatus>
{
    public static T::AuthorizationStatus Decode(ref AsduReader reader)
    {
        return new T::AuthorizationStatus
        {
            Posture = AsduElement.Decode<AuthorizationPostureCodec, T::AuthorizationPosture>(ref reader, 0),
            Error = AsduElement.DecodeOptional<ErrorCodec, T::Error>(ref reader, 1),
            ErrorSource = AsduElement.DecodeOptional<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref reader, 2),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 3),
            AuthenticationSuccess = AsduElement.DecodeOptionalSequenceOf<AuthenticationEventCodec, T::AuthenticationEvent>(ref reader, 4),
            AuthenticationFailure = AsduElement.DecodeOptionalSequenceOf<AuthenticationEventCodec, T::AuthenticationEvent>(ref reader, 5),
            AuthorizationSuccess = AsduElement.DecodeOptionalSequenceOf<AuthorizationEventCodec, T::AuthorizationEvent>(ref reader, 6),
            AuthorizationFailure = AsduElement.DecodeOptionalSequenceOf<AuthorizationEventCodec, T::AuthorizationEvent>(ref reader, 7)
        };
    }

    public static T::AuthorizationStatus Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthorizationStatusCodec, T::AuthorizationStatus>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthorizationStatus value)
    {
        AsduElement.Encode<AuthorizationPostureCodec, T::AuthorizationPosture>(ref writer, 0, value.Posture);
        AsduElement.EncodeOptional<ErrorCodec, T::Error>(ref writer, 1, value.Error);
        AsduElement.EncodeOptional<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref writer, 2, value.ErrorSource);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 3, value.ErrorDetails);
        AsduElement.EncodeOptionalSequenceOf<AuthenticationEventCodec, T::AuthenticationEvent>(ref writer, 4, value.AuthenticationSuccess);
        AsduElement.EncodeOptionalSequenceOf<AuthenticationEventCodec, T::AuthenticationEvent>(ref writer, 5, value.AuthenticationFailure);
        AsduElement.EncodeOptionalSequenceOf<AuthorizationEventCodec, T::AuthorizationEvent>(ref writer, 6, value.AuthorizationSuccess);
        AsduElement.EncodeOptionalSequenceOf<AuthorizationEventCodec, T::AuthorizationEvent>(ref writer, 7, value.AuthorizationFailure);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthorizationStatus value)
        => AsduConstructed.Encode<AuthorizationStatusCodec, T::AuthorizationStatus>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthorizationStatus value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AuthorizationPostureCodec, T::AuthorizationPosture>(0, value.Posture);
        length += AsduElement.GetOptionalEncodedLength<ErrorCodec, T::Error>(1, value.Error);
        length += AsduElement.GetOptionalEncodedLength<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(2, value.ErrorSource);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(3, value.ErrorDetails);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<AuthenticationEventCodec, T::AuthenticationEvent>(4, value.AuthenticationSuccess);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<AuthenticationEventCodec, T::AuthenticationEvent>(5, value.AuthenticationFailure);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<AuthorizationEventCodec, T::AuthorizationEvent>(6, value.AuthorizationSuccess);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<AuthorizationEventCodec, T::AuthorizationEvent>(7, value.AuthorizationFailure);
        return length;
    }

    public static int GetEncodedLength(in T::AuthorizationStatus value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthorizationStatusCodec, T::AuthorizationStatus>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
