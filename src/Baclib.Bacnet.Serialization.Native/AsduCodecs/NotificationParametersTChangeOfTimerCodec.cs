// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfTimerCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer Decode(ref NativeReader reader)
    {
        var _newState = Asdu.DecodePrimitive<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref reader, 0);
        var _statusFlags = Asdu.DecodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref reader, 1);
        var _updateTime = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
        var _lastStateChange = Asdu.DecodeOptional<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(ref reader, 3);
        var _initialTimeout = Asdu.DecodeOptional<UnsignedCodec, uint>(ref reader, 4);
        var _expirationTime = Asdu.DecodeOptionalElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 5);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer
        {
            NewState = _newState,
            StatusFlags = _statusFlags,
            UpdateTime = _updateTime,
            LastStateChange = _lastStateChange,
            InitialTimeout = _initialTimeout,
            ExpirationTime = _expirationTime
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer value)
    {
        Asdu.EncodePrimitive<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref writer, 0, value.NewState);
        Asdu.EncodePrimitive<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(ref writer, 1, value.StatusFlags);
        Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.UpdateTime);
        if (value.LastStateChange.HasValue)
        {
            Asdu.EncodePrimitive<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(ref writer, 3, value.LastStateChange.Value);
        }
        if (value.InitialTimeout.HasValue)
        {
            Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 4, value.InitialTimeout.Value);
        }
        if (value.ExpirationTime.HasValue)
        {
            Asdu.EncodeElement<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 5, value.ExpirationTime.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer value)
    {
        return Asdu.GetPrimitiveLength<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(0, value.NewState) + Asdu.GetPrimitiveLength<StatusFlagsCodec, global::Baclib.Bacnet.Types.Application.StatusFlags>(1, value.StatusFlags) + Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.UpdateTime) + (value.LastStateChange.HasValue ? Asdu.GetPrimitiveLength<TimerTransitionCodec, global::Baclib.Bacnet.Types.Application.TimerTransition>(3, value.LastStateChange.Value) : 0) + (value.InitialTimeout.HasValue ? Asdu.GetPrimitiveLength<UnsignedCodec, uint>(4, value.InitialTimeout.Value) : 0) + (value.ExpirationTime.HasValue ? Asdu.GetElementLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(5, value.ExpirationTime.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfTimer value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
