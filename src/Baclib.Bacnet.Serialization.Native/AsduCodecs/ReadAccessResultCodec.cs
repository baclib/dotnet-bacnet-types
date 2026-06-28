// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadAccessResultCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadAccessResult>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult Decode(ref NativeReader reader)
    {
        var _objectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 0);
        var _listOfResults = Asdu.DecodeSequenceOf<ReadAccessResultTListOfResultsItemCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.ReadAccessResult
        {
            ObjectIdentifier = _objectIdentifier,
            ListOfResults = _listOfResults
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadAccessResult Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadAccessResult value)
    {
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 0, value.ObjectIdentifier);
        writer.WriteOpeningTag(1);
        foreach (var item in value.ListOfResults)
        {
            Asdu.EncodeElement<ReadAccessResultTListOfResultsItemCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadAccessResult value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult value)
    {
        return Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(0, value.ObjectIdentifier) + (AsduLength.FromTagNumber((byte)1) + (value.ListOfResults.Items.Sum(static item => Asdu.GetElementLength<ReadAccessResultTListOfResultsItemCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult.TListOfResultsItem>(1, item))) + AsduLength.FromTagNumber((byte)1));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadAccessResult value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
