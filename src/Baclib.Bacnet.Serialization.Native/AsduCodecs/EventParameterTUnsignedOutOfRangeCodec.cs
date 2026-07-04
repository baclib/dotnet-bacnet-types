// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTUnsignedOutOfRangeCodec :
    IAsduElementCodec<T::EventParameter.TUnsignedOutOfRange>,
    IAsduConstructedCodec<T::EventParameter.TUnsignedOutOfRange>
{
    public static T::EventParameter.TUnsignedOutOfRange Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TUnsignedOutOfRange
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            LowLimit = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            HighLimit = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            Deadband = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 3)
        };
    }

    public static T::EventParameter.TUnsignedOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTUnsignedOutOfRangeCodec, T::EventParameter.TUnsignedOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TUnsignedOutOfRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.LowLimit);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.HighLimit);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 3, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TUnsignedOutOfRange value)
        => AsduConstructed.Encode<EventParameterTUnsignedOutOfRangeCodec, T::EventParameter.TUnsignedOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TUnsignedOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.LowLimit);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.HighLimit);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(3, value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TUnsignedOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTUnsignedOutOfRangeCodec, T::EventParameter.TUnsignedOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
