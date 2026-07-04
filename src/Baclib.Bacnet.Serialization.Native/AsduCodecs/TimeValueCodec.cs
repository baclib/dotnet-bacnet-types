// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeValueCodec :
    IAsduElementCodec<T::TimeValue>,
    IAsduConstructedCodec<T::TimeValue>
{
    public static T::TimeValue Decode(ref AsduReader reader)
    {
        return new T::TimeValue
        {
            Time = AsduElement.Decode<TimeCodec, T::Time>(ref reader),
            Value = AsduElement.Decode<AnyCodec, T::Any>(ref reader)
        };
    }

    public static T::TimeValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<TimeValueCodec, T::TimeValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::TimeValue value)
    {
        AsduElement.Encode<TimeCodec, T::Time>(ref writer, value.Time);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, value.Value);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::TimeValue value)
        => AsduConstructed.Encode<TimeValueCodec, T::TimeValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::TimeValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<TimeCodec, T::Time>(value.Time);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(value.Value);
        return length;
    }

    public static int GetEncodedLength(in T::TimeValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<TimeValueCodec, T::TimeValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return TimeCodec.Matches(ref reader);
    }
}
