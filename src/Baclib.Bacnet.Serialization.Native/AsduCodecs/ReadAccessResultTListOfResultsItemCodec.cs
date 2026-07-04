// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessResultTListOfResultsItemCodec :
    IAsduElementCodec<T::ReadAccessResult.TListOfResultsItem>,
    IAsduConstructedCodec<T::ReadAccessResult.TListOfResultsItem>
{
    public static T::ReadAccessResult.TListOfResultsItem Decode(ref AsduReader reader)
    {
        return new T::ReadAccessResult.TListOfResultsItem
        {
            PropertyIdentifier = AsduElement.Decode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 2),
            PropertyArrayIndex = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 3),
            ReadResult = AsduElement.Decode<ReadAccessResultTListOfResultsItemTReadResultCodec, T::ReadAccessResult.TListOfResultsItem.TReadResult>(ref reader)
        };
    }

    public static T::ReadAccessResult.TListOfResultsItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadAccessResult.TListOfResultsItem value)
    {
        AsduElement.Encode<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 2, value.PropertyIdentifier);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 3, value.PropertyArrayIndex);
        AsduElement.Encode<ReadAccessResultTListOfResultsItemTReadResultCodec, T::ReadAccessResult.TListOfResultsItem.TReadResult>(ref writer, value.ReadResult);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadAccessResult.TListOfResultsItem value)
        => AsduConstructed.Encode<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadAccessResult.TListOfResultsItem value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(2, value.PropertyIdentifier);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(3, value.PropertyArrayIndex);
        length += AsduElement.GetEncodedLength<ReadAccessResultTListOfResultsItemTReadResultCodec, T::ReadAccessResult.TListOfResultsItem.TReadResult>(value.ReadResult);
        return length;
    }

    public static int GetEncodedLength(in T::ReadAccessResult.TListOfResultsItem value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(2);
    }
}
