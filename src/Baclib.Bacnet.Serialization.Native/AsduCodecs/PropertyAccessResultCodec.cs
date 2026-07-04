// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyAccessResultCodec :
    IAsduElementCodec<T::PropertyAccessResult>,
    IAsduConstructedCodec<T::PropertyAccessResult>
{
    public static T::PropertyAccessResult Decode(ref AsduReader reader)
    {
        return new T::PropertyAccessResult
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            DeviceIdentifier = AsduElement.DecodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 3),
            AccessResult = AsduElement.Decode<PropertyAccessResultTAccessResultCodec, T::PropertyAccessResult.TAccessResult>(ref reader)
        };
    }

    public static T::PropertyAccessResult Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PropertyAccessResultCodec, T::PropertyAccessResult>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::PropertyAccessResult value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
        AsduElement.EncodeOptional<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 3, value.DeviceIdentifier);
        AsduElement.Encode<PropertyAccessResultTAccessResultCodec, T::PropertyAccessResult.TAccessResult>(ref writer, value.AccessResult);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::PropertyAccessResult value)
        => AsduConstructed.Encode<PropertyAccessResultCodec, T::PropertyAccessResult>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::PropertyAccessResult value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        length += AsduElement.GetOptionalEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(3, value.DeviceIdentifier);
        length += AsduElement.GetEncodedLength<PropertyAccessResultTAccessResultCodec, T::PropertyAccessResult.TAccessResult>(value.AccessResult);
        return length;
    }

    public static int GetEncodedLength(in T::PropertyAccessResult value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<PropertyAccessResultCodec, T::PropertyAccessResult>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
