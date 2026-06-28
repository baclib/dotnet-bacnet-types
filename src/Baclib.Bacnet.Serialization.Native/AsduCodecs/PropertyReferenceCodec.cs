// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PropertyReferenceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.PropertyReference>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.PropertyReference>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyReference Decode(ref NativeReader reader)
    {
        var _propertyIdentifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 0);
        var _propertyArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.PropertyReference
        {
            PropertyIdentifier = _propertyIdentifier,
            PropertyArrayIndex = _propertyArrayIndex
        };
    }

    public static global::Baclib.Bacnet.Types.Application.PropertyReference Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.PropertyReference value)
    {
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 0, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.PropertyArrayIndex.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.PropertyReference value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyReference value)
    {
        return Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(0, value.PropertyIdentifier) + (value.PropertyArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.PropertyArrayIndex.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.PropertyReference value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
