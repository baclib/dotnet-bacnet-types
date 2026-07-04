// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ErrorCodec :
    IAsduElementCodec<T::Error>,
    IAsduConstructedCodec<T::Error>
{
    public static T::Error Decode(ref AsduReader reader)
    {
        return new T::Error
        {
            ErrorClass = AsduElement.Decode<ErrorTErrorClassCodec, T::Error.TErrorClass>(ref reader),
            ErrorCode = AsduElement.Decode<ErrorTErrorCodeCodec, T::Error.TErrorCode>(ref reader)
        };
    }

    public static T::Error Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ErrorCodec, T::Error>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::Error value)
    {
        AsduElement.Encode<ErrorTErrorClassCodec, T::Error.TErrorClass>(ref writer, value.ErrorClass);
        AsduElement.Encode<ErrorTErrorCodeCodec, T::Error.TErrorCode>(ref writer, value.ErrorCode);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::Error value)
        => AsduConstructed.Encode<ErrorCodec, T::Error>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::Error value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorTErrorClassCodec, T::Error.TErrorClass>(value.ErrorClass);
        length += AsduElement.GetEncodedLength<ErrorTErrorCodeCodec, T::Error.TErrorCode>(value.ErrorCode);
        return length;
    }

    public static int GetEncodedLength(in T::Error value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ErrorCodec, T::Error>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ErrorTErrorClassCodec.Matches(ref reader);
    }
}
