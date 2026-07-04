// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessResultCodec :
    IAsduElementCodec<T::ReadAccessResult>,
    IAsduConstructedCodec<T::ReadAccessResult>
{
    public static T::ReadAccessResult Decode(ref AsduReader reader)
    {
        return new T::ReadAccessResult
        {
            ObjectIdentifier = AsduElement.Decode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref reader, 0),
            ListOfResults = AsduElement.DecodeSequenceOf<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(ref reader, 1)
        };
    }

    public static T::ReadAccessResult Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadAccessResultCodec, T::ReadAccessResult>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadAccessResult value)
    {
        AsduElement.Encode<ObjectIdentifierCodec, T::ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        AsduElement.EncodeSequenceOf<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(ref writer, 1, value.ListOfResults);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadAccessResult value)
        => AsduConstructed.Encode<ReadAccessResultCodec, T::ReadAccessResult>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadAccessResult value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ObjectIdentifierCodec, T::ObjectIdentifier>(0, value.ObjectIdentifier);
        length += AsduElement.GetSequenceOfEncodedLength<ReadAccessResultTListOfResultsItemCodec, T::ReadAccessResult.TListOfResultsItem>(1, value.ListOfResults);
        return length;
    }

    public static int GetEncodedLength(in T::ReadAccessResult value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadAccessResultCodec, T::ReadAccessResult>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
