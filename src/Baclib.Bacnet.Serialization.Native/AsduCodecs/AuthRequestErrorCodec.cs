// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestErrorCodec :
    IAsduElementCodec<T::AuthRequestError>,
    IAsduConstructedCodec<T::AuthRequestError>
{
    public static T::AuthRequestError Decode(ref AsduReader reader)
    {
        return new T::AuthRequestError
        {
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 0),
            ErrorDetails = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 1)
        };
    }

    public static T::AuthRequestError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuthRequestErrorCodec, T::AuthRequestError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AuthRequestError value)
    {
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 0, value.ErrorType);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 1, value.ErrorDetails);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AuthRequestError value)
        => AsduConstructed.Encode<AuthRequestErrorCodec, T::AuthRequestError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AuthRequestError value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(0, value.ErrorType);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(1, value.ErrorDetails);
        return length;
    }

    public static int GetEncodedLength(in T::AuthRequestError value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AuthRequestErrorCodec, T::AuthRequestError>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
