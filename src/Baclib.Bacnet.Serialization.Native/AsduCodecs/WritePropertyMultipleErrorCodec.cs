// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WritePropertyMultipleErrorCodec :
    IAsduElementCodec<T::WritePropertyMultipleError>,
    IAsduConstructedCodec<T::WritePropertyMultipleError>
{
    public static T::WritePropertyMultipleError Decode(ref AsduReader reader)
    {
        return new T::WritePropertyMultipleError
        {
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 0),
            FirstFailedWriteAttempt = AsduElement.Decode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref reader, 1)
        };
    }

    public static T::WritePropertyMultipleError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WritePropertyMultipleErrorCodec, T::WritePropertyMultipleError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WritePropertyMultipleError value)
    {
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 0, value.ErrorType);
        AsduElement.Encode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref writer, 1, value.FirstFailedWriteAttempt);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WritePropertyMultipleError value)
        => AsduConstructed.Encode<WritePropertyMultipleErrorCodec, T::WritePropertyMultipleError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WritePropertyMultipleError value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(0, value.ErrorType);
        length += AsduElement.GetEncodedLength<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(1, value.FirstFailedWriteAttempt);
        return length;
    }

    public static int GetEncodedLength(in T::WritePropertyMultipleError value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WritePropertyMultipleErrorCodec, T::WritePropertyMultipleError>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
