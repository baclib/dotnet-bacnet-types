// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest Decode(ref NativeReader reader)
    {
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _propertyIdentifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 1);
        var _propertyArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 2);
        var _range = Asdu.DecodeOptionalElement<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadRangeRequest
        {
            ObjectIdentifier = _objectIdentifier,
            PropertyIdentifier = _propertyIdentifier,
            PropertyArrayIndex = _propertyArrayIndex,
            Range = _range
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex.Value);
        }
        if (value.Range.HasValue)
        {
            Asdu.EncodeElement<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(ref writer, value.Range.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.ObjectIdentifier) + Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(1, value.PropertyIdentifier) + (value.PropertyArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex.Value) : 0) + (value.Range.HasValue ? Asdu.GetElementLength<ReadRangeRequestTRangeCodec, global::Baclib.Bacnet.Types.Application.ReadRangeRequest.TRange>(value.Range.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
