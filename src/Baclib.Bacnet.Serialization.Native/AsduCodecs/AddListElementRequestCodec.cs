// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AddListElementRequestCodec :
    IAsduElementCodec<T::AddListElementRequest>,
    IAsduConstructedCodec<T::AddListElementRequest>
{
    public static T::AddListElementRequest Decode(ref AsduReader reader)
    {
        return new T::AddListElementRequest
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            ListOfElements = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 3)
        };
    }

    public static T::AddListElementRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AddListElementRequestCodec, T::AddListElementRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AddListElementRequest value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 3, value.ListOfElements);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AddListElementRequest value)
        => AsduConstructed.Encode<AddListElementRequestCodec, T::AddListElementRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AddListElementRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(3, value.ListOfElements);
        return length;
    }

    public static int GetEncodedLength(in T::AddListElementRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AddListElementRequestCodec, T::AddListElementRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
