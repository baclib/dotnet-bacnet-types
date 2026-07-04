// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfTimerCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfTimer>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfTimer>
{
    public static T::NotificationParameters.TChangeOfTimer Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfTimer
        {
            NewState = AsduElement.Decode<TimerStateCodec, T::TimerState>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            UpdateTime = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 2),
            LastStateChange = AsduElement.DecodeOptional<TimerTransitionCodec, T::TimerTransition>(ref reader, 3),
            InitialTimeout = AsduElement.DecodeOptional<UnsignedCodec, uint>(ref reader, 4),
            ExpirationTime = AsduElement.DecodeOptional<DateTimeCodec, T::DateTime>(ref reader, 5)
        };
    }

    public static T::NotificationParameters.TChangeOfTimer Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfTimerCodec, T::NotificationParameters.TChangeOfTimer>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfTimer value)
    {
        AsduElement.Encode<TimerStateCodec, T::TimerState>(ref writer, 0, value.NewState);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 2, value.UpdateTime);
        AsduElement.EncodeOptional<TimerTransitionCodec, T::TimerTransition>(ref writer, 3, value.LastStateChange);
        AsduElement.EncodeOptional<UnsignedCodec, uint>(ref writer, 4, value.InitialTimeout);
        AsduElement.EncodeOptional<DateTimeCodec, T::DateTime>(ref writer, 5, value.ExpirationTime);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfTimer value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfTimerCodec, T::NotificationParameters.TChangeOfTimer>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfTimer value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<TimerStateCodec, T::TimerState>(0, value.NewState);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(2, value.UpdateTime);
        length += AsduElement.GetOptionalEncodedLength<TimerTransitionCodec, T::TimerTransition>(3, value.LastStateChange);
        length += AsduElement.GetOptionalEncodedLength<UnsignedCodec, uint>(4, value.InitialTimeout);
        length += AsduElement.GetOptionalEncodedLength<DateTimeCodec, T::DateTime>(5, value.ExpirationTime);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfTimer value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfTimerCodec, T::NotificationParameters.TChangeOfTimer>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
