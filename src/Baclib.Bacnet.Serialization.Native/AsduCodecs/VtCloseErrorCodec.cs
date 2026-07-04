// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class VtCloseErrorCodec :
    IAsduElementCodec<T::VtCloseError>,
    IAsduConstructedCodec<T::VtCloseError>
{
    public static T::VtCloseError Decode(ref AsduReader reader)
    {
        return new T::VtCloseError
        {
            ErrorType = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 0),
            ListOfVtSessionIdentifiers = AsduElement.DecodeOptionalSequenceOf<Unsigned8Codec, byte>(ref reader, 1)
        };
    }

    public static T::VtCloseError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<VtCloseErrorCodec, T::VtCloseError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::VtCloseError value)
    {
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 0, value.ErrorType);
        AsduElement.EncodeOptionalSequenceOf<Unsigned8Codec, byte>(ref writer, 1, value.ListOfVtSessionIdentifiers);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::VtCloseError value)
        => AsduConstructed.Encode<VtCloseErrorCodec, T::VtCloseError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::VtCloseError value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(0, value.ErrorType);
        length += AsduElement.GetOptionalSequenceOfEncodedLength<Unsigned8Codec, byte>(1, value.ListOfVtSessionIdentifiers);
        return length;
    }

    public static int GetEncodedLength(in T::VtCloseError value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<VtCloseErrorCodec, T::VtCloseError>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
