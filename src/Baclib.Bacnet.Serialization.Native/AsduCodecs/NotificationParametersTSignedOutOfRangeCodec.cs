// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTSignedOutOfRangeCodec :
    IAsduElementCodec<T::NotificationParameters.TSignedOutOfRange>,
    IAsduConstructedCodec<T::NotificationParameters.TSignedOutOfRange>
{
    public static T::NotificationParameters.TSignedOutOfRange Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TSignedOutOfRange
        {
            ExceedingValue = AsduElement.Decode<IntegerCodec, int>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            Deadband = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2),
            ExceededLimit = AsduElement.Decode<IntegerCodec, int>(ref reader, 3)
        };
    }

    public static T::NotificationParameters.TSignedOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTSignedOutOfRangeCodec, T::NotificationParameters.TSignedOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TSignedOutOfRange value)
    {
        AsduElement.Encode<IntegerCodec, int>(ref writer, 0, value.ExceedingValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.Deadband);
        AsduElement.Encode<IntegerCodec, int>(ref writer, 3, value.ExceededLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TSignedOutOfRange value)
        => AsduConstructed.Encode<NotificationParametersTSignedOutOfRangeCodec, T::NotificationParameters.TSignedOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TSignedOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(0, value.ExceedingValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.Deadband);
        length += AsduElement.GetEncodedLength<IntegerCodec, int>(3, value.ExceededLimit);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TSignedOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTSignedOutOfRangeCodec, T::NotificationParameters.TSignedOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
