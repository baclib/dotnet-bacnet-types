// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimeSynchronizationRequestCodec :
    IAsduElementCodec<T::TimeSynchronizationRequest>,
    IAsduConstructedCodec<T::TimeSynchronizationRequest>
{
    public static T::TimeSynchronizationRequest Decode(ref AsduReader reader)
    {
        return new T::TimeSynchronizationRequest
        {
            Time = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader)
        };
    }

    public static T::TimeSynchronizationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<TimeSynchronizationRequestCodec, T::TimeSynchronizationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::TimeSynchronizationRequest value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, value.Time);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::TimeSynchronizationRequest value)
        => AsduConstructed.Encode<TimeSynchronizationRequestCodec, T::TimeSynchronizationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::TimeSynchronizationRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(value.Time);
        return length;
    }

    public static int GetEncodedLength(in T::TimeSynchronizationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<TimeSynchronizationRequestCodec, T::TimeSynchronizationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DateTimeCodec.Matches(ref reader);
    }
}
