// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadPropertyMultipleAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return ReadAccessResultCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck Decode(ref NativeReader reader)
    {
        var _listOfReadAccessResults = Asdu.DecodeSequenceOf<ReadAccessResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck
        {
            ListOfReadAccessResults = _listOfReadAccessResults
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck value)
    {
        foreach (var item in value.ListOfReadAccessResults)
        {
            Asdu.EncodeElement<ReadAccessResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult>(ref writer, item);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck value)
    {
        return (value.ListOfReadAccessResults.Items.Sum(static item => Asdu.GetElementLength<ReadAccessResultCodec, global::Baclib.Bacnet.Types.Application.ReadAccessResult>(item)));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ReadPropertyMultipleAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
