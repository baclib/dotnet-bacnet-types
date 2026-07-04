// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTUnsignedRangeCodec :
    IAsduElementCodec<T::EventParameter.TUnsignedRange>,
    IAsduConstructedCodec<T::EventParameter.TUnsignedRange>
{
    public static T::EventParameter.TUnsignedRange Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TUnsignedRange
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            LowLimit = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            HighLimit = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2)
        };
    }

    public static T::EventParameter.TUnsignedRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTUnsignedRangeCodec, T::EventParameter.TUnsignedRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TUnsignedRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.LowLimit);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.HighLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TUnsignedRange value)
        => AsduConstructed.Encode<EventParameterTUnsignedRangeCodec, T::EventParameter.TUnsignedRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TUnsignedRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.LowLimit);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.HighLimit);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TUnsignedRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTUnsignedRangeCodec, T::EventParameter.TUnsignedRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
