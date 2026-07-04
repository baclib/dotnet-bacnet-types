// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WritePropertyMultipleRequestCodec :
    IAsduElementCodec<T::WritePropertyMultipleRequest>,
    IAsduConstructedCodec<T::WritePropertyMultipleRequest>
{
    public static T::WritePropertyMultipleRequest Decode(ref AsduReader reader)
    {
        return new T::WritePropertyMultipleRequest
        {
            ListOfWriteAccessSpecifications = AsduElement.DecodeSequenceOf<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(ref reader)
        };
    }

    public static T::WritePropertyMultipleRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WritePropertyMultipleRequestCodec, T::WritePropertyMultipleRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WritePropertyMultipleRequest value)
    {
        AsduElement.EncodeSequenceOf<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(ref writer, value.ListOfWriteAccessSpecifications);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WritePropertyMultipleRequest value)
        => AsduConstructed.Encode<WritePropertyMultipleRequestCodec, T::WritePropertyMultipleRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WritePropertyMultipleRequest value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(value.ListOfWriteAccessSpecifications);
        return length;
    }

    public static int GetEncodedLength(in T::WritePropertyMultipleRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WritePropertyMultipleRequestCodec, T::WritePropertyMultipleRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return WriteAccessSpecificationCodec.Matches(ref reader);
    }
}
