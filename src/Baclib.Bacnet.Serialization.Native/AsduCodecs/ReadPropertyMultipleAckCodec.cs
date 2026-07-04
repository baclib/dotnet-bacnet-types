// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ReadPropertyMultipleAckCodec :
    IAsduElementCodec<T::ReadPropertyMultipleAck>,
    IAsduConstructedCodec<T::ReadPropertyMultipleAck>
{
    public static T::ReadPropertyMultipleAck Decode(ref AsduReader reader)
    {
        return new T::ReadPropertyMultipleAck
        {
            ListOfReadAccessResults = AsduElement.DecodeSequenceOf<ReadAccessResultCodec, T::ReadAccessResult>(ref reader)
        };
    }

    public static T::ReadPropertyMultipleAck Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ReadPropertyMultipleAckCodec, T::ReadPropertyMultipleAck>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::ReadPropertyMultipleAck value)
    {
        AsduElement.EncodeSequenceOf<ReadAccessResultCodec, T::ReadAccessResult>(ref writer, value.ListOfReadAccessResults);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::ReadPropertyMultipleAck value)
        => AsduConstructed.Encode<ReadPropertyMultipleAckCodec, T::ReadPropertyMultipleAck>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::ReadPropertyMultipleAck value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<ReadAccessResultCodec, T::ReadAccessResult>(value.ListOfReadAccessResults);
        return length;
    }

    public static int GetEncodedLength(in T::ReadPropertyMultipleAck value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<ReadPropertyMultipleAckCodec, T::ReadPropertyMultipleAck>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return ReadAccessResultCodec.Matches(ref reader);
    }
}
