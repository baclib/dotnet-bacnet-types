// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthRequestErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthRequestError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthRequestError>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestError Decode(ref NativeReader reader)
    {
        var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 0);
        var _errorDetails = Asdu.DecodeOptional<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.AuthRequestError
        {
            ErrorType = _errorType,
            ErrorDetails = _errorDetails
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthRequestError Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthRequestError value)
    {
        Asdu.EncodeElement<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 0, value.ErrorType);
        if (value.ErrorDetails.HasValue)
        {
            Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 1, value.ErrorDetails.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthRequestError value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestError value)
    {
        return Asdu.GetElementLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(0, value.ErrorType) + (value.ErrorDetails.HasValue ? Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(1, value.ErrorDetails.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthRequestError value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
