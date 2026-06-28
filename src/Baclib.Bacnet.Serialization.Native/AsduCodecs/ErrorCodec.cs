// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Error>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Error>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(ErrorTErrorClassCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.Error Decode(ref NativeReader reader)
    {
        var _errorClass = Asdu.DecodePrimitive<ErrorTErrorClassCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorClass>(ref reader);
        var _errorCode = Asdu.DecodePrimitive<ErrorTErrorCodeCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorCode>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.Error
        {
            ErrorClass = _errorClass,
            ErrorCode = _errorCode
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Error Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Error value)
    {
        Asdu.EncodePrimitive<ErrorTErrorClassCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorClass>(ref writer, value.ErrorClass);
        Asdu.EncodePrimitive<ErrorTErrorCodeCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorCode>(ref writer, value.ErrorCode);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Error value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Error value)
    {
        return Asdu.GetEncodedLength<ErrorTErrorClassCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorClass>(value.ErrorClass) + Asdu.GetEncodedLength<ErrorTErrorCodeCodec, global::Baclib.Bacnet.Types.Application.Error.TErrorCode>(value.ErrorCode);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Error value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
