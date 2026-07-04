// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadPropertyMultipleRequestCodec :
    IAsduElementCodec<T::ReadPropertyMultipleRequest>,
    IAsduConstructedCodec<T::ReadPropertyMultipleRequest>
{
    public static T::ReadPropertyMultipleRequest Decode(ref AsduReader reader)
    {
        return new T::ReadPropertyMultipleRequest
        {
            ListOfReadAccessSpecifications = AsduElement.DecodeSequenceOf<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(ref reader)
        };
    }

    public static T::ReadPropertyMultipleRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadPropertyMultipleRequestCodec, T::ReadPropertyMultipleRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadPropertyMultipleRequest value)
    {
        AsduElement.EncodeSequenceOf<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(ref writer, value.ListOfReadAccessSpecifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadPropertyMultipleRequest value)
        => AsduConstructed.Encode<ReadPropertyMultipleRequestCodec, T::ReadPropertyMultipleRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadPropertyMultipleRequest value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(value.ListOfReadAccessSpecifications);
        return length;
    }

    public static int GetEncodedLength(in T::ReadPropertyMultipleRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadPropertyMultipleRequestCodec, T::ReadPropertyMultipleRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ReadAccessSpecificationCodec.Matches(ref reader);
    }
}
