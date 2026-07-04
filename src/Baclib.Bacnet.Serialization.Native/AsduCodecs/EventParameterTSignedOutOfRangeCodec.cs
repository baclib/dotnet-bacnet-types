// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTSignedOutOfRangeCodec :
    IAsduElementCodec<T::EventParameter.TSignedOutOfRange>,
    IAsduConstructedCodec<T::EventParameter.TSignedOutOfRange>
{
    public static T::EventParameter.TSignedOutOfRange Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TSignedOutOfRange
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            LowLimit = AsduElement.Decode<IntegerCodec, int>(ref reader, 1),
            HighLimit = AsduElement.Decode<IntegerCodec, int>(ref reader, 2),
            Deadband = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3)
        };
    }

    public static T::EventParameter.TSignedOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTSignedOutOfRangeCodec, T::EventParameter.TSignedOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TSignedOutOfRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<IntegerCodec, int>(ref writer, 1, value.LowLimit);
        AsduElement.Encode<IntegerCodec, int>(ref writer, 2, value.HighLimit);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TSignedOutOfRange value)
        => AsduConstructed.Encode<EventParameterTSignedOutOfRangeCodec, T::EventParameter.TSignedOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TSignedOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(1, value.LowLimit);
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(2, value.HighLimit);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TSignedOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTSignedOutOfRangeCodec, T::EventParameter.TSignedOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
