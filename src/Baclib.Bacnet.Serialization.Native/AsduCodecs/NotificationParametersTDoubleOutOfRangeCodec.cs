// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTDoubleOutOfRangeCodec :
    IAsduElementCodec<T::NotificationParameters.TDoubleOutOfRange>,
    IAsduConstructedCodec<T::NotificationParameters.TDoubleOutOfRange>
{
    public static T::NotificationParameters.TDoubleOutOfRange Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TDoubleOutOfRange
        {
            ExceedingValue = AsduElement.Decode<DoubleCodec, double>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            Deadband = AsduElement.Decode<DoubleCodec, double>(ref reader, 2),
            ExceededLimit = AsduElement.Decode<DoubleCodec, double>(ref reader, 3)
        };
    }

    public static T::NotificationParameters.TDoubleOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTDoubleOutOfRangeCodec, T::NotificationParameters.TDoubleOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TDoubleOutOfRange value)
    {
        AsduElement.Encode<DoubleCodec, double>(ref writer, 0, value.ExceedingValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<DoubleCodec, double>(ref writer, 2, value.Deadband);
        AsduElement.Encode<DoubleCodec, double>(ref writer, 3, value.ExceededLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TDoubleOutOfRange value)
        => AsduConstructed.Encode<NotificationParametersTDoubleOutOfRangeCodec, T::NotificationParameters.TDoubleOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TDoubleOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(0, value.ExceedingValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(2, value.Deadband);
        length += AsduElement.GetEncodedLength<DoubleCodec, double>(3, value.ExceededLimit);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TDoubleOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTDoubleOutOfRangeCodec, T::NotificationParameters.TDoubleOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
