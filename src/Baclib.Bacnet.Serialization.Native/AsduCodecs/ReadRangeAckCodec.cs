// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadRangeAckCodec :
    IAsduElementCodec<T::ReadRangeAck>,
    IAsduConstructedCodec<T::ReadRangeAck>
{
    public static T::ReadRangeAck Decode(ref AsduReader reader)
    {
        return new T::ReadRangeAck
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 1),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 2),
            ResultFlags = AsduElement.Decode<ResultFlagsCodec, T::ResultFlags>(ref reader, 3),
            ItemCount = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 4),
            ItemData = AsduElement.DecodeSequenceOf<AnyCodec, T::Any>(ref reader, 5),
            FirstSequenceNumber = AsduElement.DecodeOptional<Unsigned32Codec, uint>(ref reader, 6)
        };
    }

    public static T::ReadRangeAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadRangeAckCodec, T::ReadRangeAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadRangeAck value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 1, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 2, value.PropertyArrayIndex);
        AsduElement.Encode<ResultFlagsCodec, T::ResultFlags>(ref writer, 3, value.ResultFlags);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 4, value.ItemCount);
        AsduElement.EncodeSequenceOf<AnyCodec, T::Any>(ref writer, 5, value.ItemData);
        AsduElement.EncodeOptional<Unsigned32Codec, uint>(ref writer, 6, value.FirstSequenceNumber);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadRangeAck value)
        => AsduConstructed.Encode<ReadRangeAckCodec, T::ReadRangeAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadRangeAck value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(1, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(2, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<ResultFlagsCodec, T::ResultFlags>(3, value.ResultFlags);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(4, value.ItemCount);
        length += AsduElement.GetSequenceOfEncodedLength<AnyCodec, T::Any>(5, value.ItemData);
        length += AsduElement.GetOptionalEncodedLength<Unsigned32Codec, uint>(6, value.FirstSequenceNumber);
        return length;
    }

    public static int GetEncodedLength(in T::ReadRangeAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadRangeAckCodec, T::ReadRangeAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
