// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfTimerCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfTimer>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfTimer>
{
    public static T::EventParameter.TChangeOfTimer Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfTimer
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            AlarmValues = AsduElement.DecodeSequenceOf<TimerStateCodec, T::TimerState>(ref reader, 1),
            UpdateTimeReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 2)
        };
    }

    public static T::EventParameter.TChangeOfTimer Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfTimerCodec, T::EventParameter.TChangeOfTimer>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfTimer value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.EncodeSequenceOf<TimerStateCodec, T::TimerState>(ref writer, 1, value.AlarmValues);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 2, value.UpdateTimeReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfTimer value)
        => AsduConstructed.Encode<EventParameterTChangeOfTimerCodec, T::EventParameter.TChangeOfTimer>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfTimer value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetSequenceOfEncodedLength<TimerStateCodec, T::TimerState>(1, value.AlarmValues);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(2, value.UpdateTimeReference);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfTimer value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfTimerCodec, T::EventParameter.TChangeOfTimer>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
