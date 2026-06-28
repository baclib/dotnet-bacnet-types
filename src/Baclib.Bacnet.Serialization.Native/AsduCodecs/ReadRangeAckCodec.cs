// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadRangeAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadRangeAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeAck Decode(ref NativeReader reader)
    {
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _propertyIdentifier = Asdu.DecodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref reader, 1);
        var _propertyArrayIndex = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 2);
        var _resultFlags = Asdu.DecodePrimitive<ResultFlagsCodec, global::Baclib.Bacnet.Types.Application.ResultFlags>(ref reader, 3);
        var _itemCount = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 4);
        var _itemData = Asdu.DecodeSequenceOf<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 5);
        var _firstSequenceNumber = Asdu.DecodeOptional<Unsigned32Codec, uint>(ref reader, 6);

        return new global::Baclib.Bacnet.Types.Application.ReadRangeAck
        {
            ObjectIdentifier = _objectIdentifier,
            PropertyIdentifier = _propertyIdentifier,
            PropertyArrayIndex = _propertyArrayIndex,
            ResultFlags = _resultFlags,
            ItemCount = _itemCount,
            ItemData = _itemData,
            FirstSequenceNumber = _firstSequenceNumber
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadRangeAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadRangeAck value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        Asdu.EncodePrimitive<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        if (value.PropertyArrayIndex.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex.Value);
        }
        Asdu.EncodePrimitive<ResultFlagsCodec, global::Baclib.Bacnet.Types.Application.ResultFlags>(ref writer, 3, value.ResultFlags);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 4, value.ItemCount);
        writer.WriteOpeningTag(5);
        foreach (var item in value.ItemData)
        {
            Asdu.EncodeElement<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 5, item);
        }
        writer.WriteClosingTag(5);
        if (value.FirstSequenceNumber.HasValue)
        {
            Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 6, value.FirstSequenceNumber.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadRangeAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeAck value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.ObjectIdentifier) + Asdu.GetPrimitiveLength<PropertyIdentifierCodec, global::Baclib.Bacnet.Types.Application.PropertyIdentifier>(1, value.PropertyIdentifier) + (value.PropertyArrayIndex.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex.Value) : 0) + Asdu.GetPrimitiveLength<ResultFlagsCodec, global::Baclib.Bacnet.Types.Application.ResultFlags>(3, value.ResultFlags) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(4, value.ItemCount) + (AsduLength.FromTagNumber((byte)5) + (value.ItemData.Items.Sum(static item => Asdu.GetElementLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(5, item))) + AsduLength.FromTagNumber((byte)5)) + (value.FirstSequenceNumber.HasValue ? Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(6, value.FirstSequenceNumber.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadRangeAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
