// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ObjectPropertyReferenceCodec :
    IAsduElementCodec<T::ObjectPropertyReference>,
    IAsduConstructedCodec<T::ObjectPropertyReference>
{
    public static T::ObjectPropertyReference Decode(ref AsduReader reader)
    {
        return new T::ObjectPropertyReference
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2)
        };
    }

    public static T::ObjectPropertyReference Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ObjectPropertyReference value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ObjectPropertyReference value)
        => AsduConstructed.Encode<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ObjectPropertyReference value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        return length;
    }

    public static int GetEncodedLength(in T::ObjectPropertyReference value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ObjectPropertyReferenceCodec, T::ObjectPropertyReference>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
