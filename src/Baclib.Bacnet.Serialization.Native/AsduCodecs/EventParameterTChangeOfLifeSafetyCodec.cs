// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfLifeSafetyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _listOfLifeSafetyAlarmValues = Asdu.DecodeSequenceOf<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref reader, 1);
        var _listOfAlarmValues = Asdu.DecodeSequenceOf<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref reader, 2);
        var _modePropertyReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety
        {
            TimeDelay = _timeDelay,
            ListOfLifeSafetyAlarmValues = _listOfLifeSafetyAlarmValues,
            ListOfAlarmValues = _listOfAlarmValues,
            ModePropertyReference = _modePropertyReference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        writer.WriteOpeningTag(1);
        foreach (var item in value.ListOfLifeSafetyAlarmValues)
        {
            Asdu.EncodeElement<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref writer, 1, item);
        }
        writer.WriteClosingTag(1);
        writer.WriteOpeningTag(2);
        foreach (var item in value.ListOfAlarmValues)
        {
            Asdu.EncodeElement<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 3, value.ModePropertyReference);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + (AsduLength.FromTagNumber((byte)1) + (value.ListOfLifeSafetyAlarmValues.Items.Sum(static item => Asdu.GetElementLength<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(1, item))) + AsduLength.FromTagNumber((byte)1)) + (AsduLength.FromTagNumber((byte)2) + (value.ListOfAlarmValues.Items.Sum(static item => Asdu.GetElementLength<LifeSafetyStateCodec, global::Baclib.Bacnet.Types.Application.LifeSafetyState>(2, item))) + AsduLength.FromTagNumber((byte)2)) + Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(3, value.ModePropertyReference);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfLifeSafety value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
