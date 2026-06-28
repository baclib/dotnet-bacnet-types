// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class WritePropertyMultipleRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return WriteAccessSpecificationCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest Decode(ref NativeReader reader)
    {
        var _listOfWriteAccessSpecifications = Asdu.DecodeSequenceOf<WriteAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.WriteAccessSpecification>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest
        {
            ListOfWriteAccessSpecifications = _listOfWriteAccessSpecifications
        };
    }

    public static global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest value)
    {
        foreach (var item in value.ListOfWriteAccessSpecifications)
        {
            Asdu.EncodeElement<WriteAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.WriteAccessSpecification>(ref writer, item);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest value)
    {
        return (value.ListOfWriteAccessSpecifications.Items.Sum(static item => Asdu.GetElementLength<WriteAccessSpecificationCodec, global::Baclib.Bacnet.Types.Application.WriteAccessSpecification>(item)));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.WritePropertyMultipleRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
