// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WriteAccessSpecificationCodec :
    IAsduElementCodec<T::WriteAccessSpecification>,
    IAsduConstructedCodec<T::WriteAccessSpecification>
{
    public static T::WriteAccessSpecification Decode(ref AsduReader reader)
    {
        return new T::WriteAccessSpecification
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfProperties = AsduElement.DecodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref reader, 1)
        };
    }

    public static T::WriteAccessSpecification Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::WriteAccessSpecification value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.EncodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref writer, 1, value.ListOfProperties);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::WriteAccessSpecification value)
        => AsduConstructed.Encode<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::WriteAccessSpecification value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<PropertyValueCodec, T::PropertyValue>(1, value.ListOfProperties);
        return length;
    }

    public static int GetEncodedLength(in T::WriteAccessSpecification value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<WriteAccessSpecificationCodec, T::WriteAccessSpecification>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
