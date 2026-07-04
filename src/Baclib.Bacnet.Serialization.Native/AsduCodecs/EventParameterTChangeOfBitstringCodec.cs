// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfBitstringCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfBitstring>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfBitstring>
{
    public static T::EventParameter.TChangeOfBitstring Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfBitstring
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            Bitmask = AsduElement.Decode<BitStringCodec, T::BitString>(ref reader, 1),
            ListOfBitstringValues = AsduElement.DecodeSequenceOf<BitStringCodec, T::BitString>(ref reader, 2)
        };
    }

    public static T::EventParameter.TChangeOfBitstring Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfBitstringCodec, T::EventParameter.TChangeOfBitstring>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfBitstring value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<BitStringCodec, T::BitString>(ref writer, 1, value.Bitmask);
        AsduElement.EncodeSequenceOf<BitStringCodec, T::BitString>(ref writer, 2, value.ListOfBitstringValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfBitstring value)
        => AsduConstructed.Encode<EventParameterTChangeOfBitstringCodec, T::EventParameter.TChangeOfBitstring>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfBitstring value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<BitStringCodec, T::BitString>(1, value.Bitmask);
        length += AsduElement.GetSequenceOfEncodedLength<BitStringCodec, T::BitString>(2, value.ListOfBitstringValues);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfBitstring value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfBitstringCodec, T::EventParameter.TChangeOfBitstring>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
