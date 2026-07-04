// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class UtcTimeSynchronizationRequestCodec :
    IAsduElementCodec<T::UtcTimeSynchronizationRequest>,
    IAsduConstructedCodec<T::UtcTimeSynchronizationRequest>
{
    public static T::UtcTimeSynchronizationRequest Decode(ref AsduReader reader)
    {
        return new T::UtcTimeSynchronizationRequest
        {
            Time = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader)
        };
    }

    public static T::UtcTimeSynchronizationRequest Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<UtcTimeSynchronizationRequestCodec, T::UtcTimeSynchronizationRequest>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::UtcTimeSynchronizationRequest value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, value.Time);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::UtcTimeSynchronizationRequest value)
        => AsduConstructed.Encode<UtcTimeSynchronizationRequestCodec, T::UtcTimeSynchronizationRequest>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::UtcTimeSynchronizationRequest value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(value.Time);
        return length;
    }

    public static int GetEncodedLength(in T::UtcTimeSynchronizationRequest value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<UtcTimeSynchronizationRequestCodec, T::UtcTimeSynchronizationRequest>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return DateTimeCodec.Matches(ref reader);
    }
}
