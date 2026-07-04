// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTOutOfRangeCodec :
    IAsduElementCodec<T::NotificationParameters.TOutOfRange>,
    IAsduConstructedCodec<T::NotificationParameters.TOutOfRange>
{
    public static T::NotificationParameters.TOutOfRange Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TOutOfRange
        {
            ExceedingValue = AsduElement.Decode<RealCodec, float>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            Deadband = AsduElement.Decode<RealCodec, float>(ref reader, 2),
            ExceededLimit = AsduElement.Decode<RealCodec, float>(ref reader, 3)
        };
    }

    public static T::NotificationParameters.TOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTOutOfRangeCodec, T::NotificationParameters.TOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TOutOfRange value)
    {
        AsduElement.Encode<RealCodec, float>(ref writer, 0, value.ExceedingValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<RealCodec, float>(ref writer, 2, value.Deadband);
        AsduElement.Encode<RealCodec, float>(ref writer, 3, value.ExceededLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TOutOfRange value)
        => AsduConstructed.Encode<NotificationParametersTOutOfRangeCodec, T::NotificationParameters.TOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RealCodec, float>(0, value.ExceedingValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<RealCodec, float>(2, value.Deadband);
        length += AsduElement.GetEncodedLength<RealCodec, float>(3, value.ExceededLimit);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTOutOfRangeCodec, T::NotificationParameters.TOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
