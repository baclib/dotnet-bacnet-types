// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTDoubleOutOfRangeCodec :
    IAsduElementCodec<T::EventParameter.TDoubleOutOfRange>,
    IAsduConstructedCodec<T::EventParameter.TDoubleOutOfRange>
{
    public static T::EventParameter.TDoubleOutOfRange Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TDoubleOutOfRange
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            LowLimit = AsduElement.Decode<DoubleCodec, double>(ref reader, 1),
            HighLimit = AsduElement.Decode<DoubleCodec, double>(ref reader, 2),
            Deadband = AsduElement.Decode<DoubleCodec, double>(ref reader, 3)
        };
    }

    public static T::EventParameter.TDoubleOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTDoubleOutOfRangeCodec, T::EventParameter.TDoubleOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TDoubleOutOfRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<DoubleCodec, double>(ref writer, 1, value.LowLimit);
        AsduElement.Encode<DoubleCodec, double>(ref writer, 2, value.HighLimit);
        AsduElement.Encode<DoubleCodec, double>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TDoubleOutOfRange value)
        => AsduConstructed.Encode<EventParameterTDoubleOutOfRangeCodec, T::EventParameter.TDoubleOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TDoubleOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(1, value.LowLimit);
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(2, value.HighLimit);
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(3, value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TDoubleOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTDoubleOutOfRangeCodec, T::EventParameter.TDoubleOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
