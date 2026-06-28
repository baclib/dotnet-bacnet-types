// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfTimerCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _alarmValues = Asdu.DecodeSequenceOf<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref reader, 1);
        var _updateTimeReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer
        {
            TimeDelay = _timeDelay,
            AlarmValues = _alarmValues,
            UpdateTimeReference = _updateTimeReference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        writer.WriteOpeningTag(1);
        foreach (var item in value.AlarmValues)
        {
            Asdu.EncodeElement<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 2, value.UpdateTimeReference);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + (AsduLength.FromTagNumber((byte)1) + (value.AlarmValues.Items.Sum(static item => Asdu.GetElementLength<TimerStateCodec, global::Baclib.Bacnet.Types.Application.TimerState>(1, item))) + AsduLength.FromTagNumber((byte)1)) + Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(2, value.UpdateTimeReference);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfTimer value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
