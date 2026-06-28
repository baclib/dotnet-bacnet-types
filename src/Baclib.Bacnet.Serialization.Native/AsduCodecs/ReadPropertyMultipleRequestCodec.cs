// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadPropertyMultipleRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return ReadAccessSpecificationCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest Decode(ref NativeReader reader)
    {
        var _listOfReadAccessSpecifications = Asdu.DecodeSequenceOf<ReadAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.ReadAccessSpecification>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest
        {
            ListOfReadAccessSpecifications = _listOfReadAccessSpecifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest value)
    {
        foreach (var item in value.ListOfReadAccessSpecifications)
        {
            Asdu.EncodeElement<ReadAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.ReadAccessSpecification>(ref writer, item);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest value)
    {
        return (value.ListOfReadAccessSpecifications.Items.Sum(static item => Asdu.GetElementLength<ReadAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.ReadAccessSpecification>(item)));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
