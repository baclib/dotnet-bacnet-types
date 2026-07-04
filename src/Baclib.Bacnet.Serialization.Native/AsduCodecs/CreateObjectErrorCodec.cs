// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class CreateObjectErrorCodec :
    IAsduElementCodec<T::CreateObjectError>,
    IAsduConstructedCodec<T::CreateObjectError>
{
    public static T::CreateObjectError Decode(ref AsduReader reader)
    {
        return new T::CreateObjectError
        {
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 0),
            FirstFailedElementNumber = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1)
        };
    }

    public static T::CreateObjectError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<CreateObjectErrorCodec, T::CreateObjectError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::CreateObjectError value)
    {
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 0, value.ErrorType);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.FirstFailedElementNumber);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::CreateObjectError value)
        => AsduConstructed.Encode<CreateObjectErrorCodec, T::CreateObjectError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::CreateObjectError value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(0, value.ErrorType);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.FirstFailedElementNumber);
        return length;
    }

    public static int GetEncodedLength(in T::CreateObjectError value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<CreateObjectErrorCodec, T::CreateObjectError>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
