// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessSpecificationCodec :
    IAsduElementCodec<T::ReadAccessSpecification>,
    IAsduConstructedCodec<T::ReadAccessSpecification>
{
    public static T::ReadAccessSpecification Decode(ref AsduReader reader)
    {
        return new T::ReadAccessSpecification
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfPropertyReferences = AsduElement.DecodeSequenceOf<PropertyReferenceCodec, T::PropertyReference>(ref reader, 1)
        };
    }

    public static T::ReadAccessSpecification Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadAccessSpecification value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.EncodeSequenceOf<PropertyReferenceCodec, T::PropertyReference>(ref writer, 1, value.ListOfPropertyReferences);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadAccessSpecification value)
        => AsduConstructed.Encode<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadAccessSpecification value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<PropertyReferenceCodec, T::PropertyReference>(1, value.ListOfPropertyReferences);
        return length;
    }

    public static int GetEncodedLength(in T::ReadAccessSpecification value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadAccessSpecificationCodec, T::ReadAccessSpecification>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
