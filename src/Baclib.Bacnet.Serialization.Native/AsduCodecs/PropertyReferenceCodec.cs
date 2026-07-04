// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyReferenceCodec :
    IAsduElementCodec<T::PropertyReference>,
    IAsduConstructedCodec<T::PropertyReference>
{
    public static T::PropertyReference Decode(ref AsduReader reader)
    {
        return new T::PropertyReference
        {
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 0),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 1)
        };
    }

    public static T::PropertyReference Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PropertyReferenceCodec, T::PropertyReference>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::PropertyReference value)
    {
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 0, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 1, value.PropertyArrayIndex);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::PropertyReference value)
        => AsduConstructed.Encode<PropertyReferenceCodec, T::PropertyReference>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::PropertyReference value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(0, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(1, value.PropertyArrayIndex);
        return length;
    }

    public static int GetEncodedLength(in T::PropertyReference value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<PropertyReferenceCodec, T::PropertyReference>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
