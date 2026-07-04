// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTUnsignedRangeCodec :
    IAsduElementCodec<T::NotificationParameters.TUnsignedRange>,
    IAsduConstructedCodec<T::NotificationParameters.TUnsignedRange>
{
    public static T::NotificationParameters.TUnsignedRange Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TUnsignedRange
        {
            ExceedingValue = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            ExceededLimit = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TUnsignedRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTUnsignedRangeCodec, T::NotificationParameters.TUnsignedRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TUnsignedRange value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.ExceedingValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 2, value.ExceededLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TUnsignedRange value)
        => AsduConstructed.Encode<NotificationParametersTUnsignedRangeCodec, T::NotificationParameters.TUnsignedRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TUnsignedRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.ExceedingValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(2, value.ExceededLimit);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TUnsignedRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTUnsignedRangeCodec, T::NotificationParameters.TUnsignedRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
