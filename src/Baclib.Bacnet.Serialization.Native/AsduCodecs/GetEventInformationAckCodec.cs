// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEventInformationAckCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.GetEventInformationAck>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.GetEventInformationAck>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.GetEventInformationAck Decode(ref NativeReader reader)
    {
        var _listOfEventSummaries = Asdu.DecodeSequenceOf<GetEventInformationAckTListOfEventSummariesItemCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck.TListOfEventSummariesItem>(ref reader, 0);
        var _moreEvents = Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.GetEventInformationAck
        {
            ListOfEventSummaries = _listOfEventSummaries,
            MoreEvents = _moreEvents
        };
    }

    public static global::Baclib.Bacnet.Types.Application.GetEventInformationAck Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.GetEventInformationAck value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.ListOfEventSummaries)
        {
            Asdu.EncodeElement<GetEventInformationAckTListOfEventSummariesItemCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck.TListOfEventSummariesItem>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
        Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, 1, value.MoreEvents);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.GetEventInformationAck value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEventInformationAck value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.ListOfEventSummaries.Items.Sum(static item => Asdu.GetElementLength<GetEventInformationAckTListOfEventSummariesItemCodec, global::Baclib.Bacnet.Types.Application.GetEventInformationAck.TListOfEventSummariesItem>(0, item))) + AsduLength.FromTagNumber((byte)0)) + Asdu.GetPrimitiveLength<BooleanCodec, bool>(1, value.MoreEvents);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.GetEventInformationAck value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
