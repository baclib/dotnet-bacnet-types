// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class GetEventInformationAckCodec :
    IAsduElementCodec<T::GetEventInformationAck>,
    IAsduConstructedCodec<T::GetEventInformationAck>
{
    public static T::GetEventInformationAck Decode(ref AsduReader reader)
    {
        return new T::GetEventInformationAck
        {
            ListOfEventSummaries = AsduElement.DecodeSequenceOf<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(ref reader, 0),
            MoreEvents = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1)
        };
    }

    public static T::GetEventInformationAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<GetEventInformationAckCodec, T::GetEventInformationAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::GetEventInformationAck value)
    {
        AsduElement.EncodeSequenceOf<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(ref writer, 0, value.ListOfEventSummaries);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.MoreEvents);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::GetEventInformationAck value)
        => AsduConstructed.Encode<GetEventInformationAckCodec, T::GetEventInformationAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::GetEventInformationAck value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<GetEventInformationAckTListOfEventSummariesItemCodec, T::GetEventInformationAck.TListOfEventSummariesItem>(0, value.ListOfEventSummaries);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.MoreEvents);
        return length;
    }

    public static int GetEncodedLength(in T::GetEventInformationAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<GetEventInformationAckCodec, T::GetEventInformationAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
