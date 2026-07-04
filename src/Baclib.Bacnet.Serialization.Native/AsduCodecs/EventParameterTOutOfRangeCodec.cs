// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTOutOfRangeCodec :
    IAsduElementCodec<T::EventParameter.TOutOfRange>,
    IAsduConstructedCodec<T::EventParameter.TOutOfRange>
{
    public static T::EventParameter.TOutOfRange Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TOutOfRange
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            LowLimit = AsduElement.Decode<RealCodec, float>(ref reader, 1),
            HighLimit = AsduElement.Decode<RealCodec, float>(ref reader, 2),
            Deadband = AsduElement.Decode<RealCodec, float>(ref reader, 3)
        };
    }

    public static T::EventParameter.TOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTOutOfRangeCodec, T::EventParameter.TOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TOutOfRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<RealCodec, float>(ref writer, 1, value.LowLimit);
        AsduElement.Encode<RealCodec, float>(ref writer, 2, value.HighLimit);
        AsduElement.Encode<RealCodec, float>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TOutOfRange value)
        => AsduConstructed.Encode<EventParameterTOutOfRangeCodec, T::EventParameter.TOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<RealCodec, float>(1, value.LowLimit);
        length += AsduElement.GetEncodedLength<RealCodec, float>(2, value.HighLimit);
        length += AsduElement.GetEncodedLength<RealCodec, float>(3, value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTOutOfRangeCodec, T::EventParameter.TOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
