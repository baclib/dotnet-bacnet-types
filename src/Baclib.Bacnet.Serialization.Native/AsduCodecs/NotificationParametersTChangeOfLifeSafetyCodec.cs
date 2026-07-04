// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfLifeSafetyCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfLifeSafety>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfLifeSafety>
{
    public static T::NotificationParameters.TChangeOfLifeSafety Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfLifeSafety
        {
            NewState = AsduElement.Decode<LifeSafetyStateCodec, T::LifeSafetyState>(ref reader, 0),
            NewMode = AsduElement.Decode<LifeSafetyModeCodec, T::LifeSafetyMode>(ref reader, 1),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 2),
            OperationExpected = AsduElement.Decode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref reader, 3)
        };
    }

    public static T::NotificationParameters.TChangeOfLifeSafety Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfLifeSafetyCodec, T::NotificationParameters.TChangeOfLifeSafety>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfLifeSafety value)
    {
        AsduElement.Encode<LifeSafetyStateCodec, T::LifeSafetyState>(ref writer, 0, value.NewState);
        AsduElement.Encode<LifeSafetyModeCodec, T::LifeSafetyMode>(ref writer, 1, value.NewMode);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 2, value.StatusFlags);
        AsduElement.Encode<LifeSafetyOperationCodec, T::LifeSafetyOperation>(ref writer, 3, value.OperationExpected);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfLifeSafety value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfLifeSafetyCodec, T::NotificationParameters.TChangeOfLifeSafety>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfLifeSafety value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<LifeSafetyStateCodec, T::LifeSafetyState>(0, value.NewState);
        length += AsduElement.GetEncodedLength<LifeSafetyModeCodec, T::LifeSafetyMode>(1, value.NewMode);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(2, value.StatusFlags);
        length += AsduElement.GetEncodedLength<LifeSafetyOperationCodec, T::LifeSafetyOperation>(3, value.OperationExpected);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfLifeSafety value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfLifeSafetyCodec, T::NotificationParameters.TChangeOfLifeSafety>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
