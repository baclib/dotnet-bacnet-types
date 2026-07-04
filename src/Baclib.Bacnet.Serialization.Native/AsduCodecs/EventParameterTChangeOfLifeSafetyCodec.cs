// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfLifeSafetyCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfLifeSafety>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfLifeSafety>
{
    public static T::EventParameter.TChangeOfLifeSafety Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfLifeSafety
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            ListOfLifeSafetyAlarmValues = AsduElement.DecodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref reader, 1),
            ListOfAlarmValues = AsduElement.DecodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref reader, 2),
            ModePropertyReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 3)
        };
    }

    public static T::EventParameter.TChangeOfLifeSafety Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfLifeSafetyCodec, T::EventParameter.TChangeOfLifeSafety>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfLifeSafety value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.EncodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref writer, 1, value.ListOfLifeSafetyAlarmValues);
        AsduElement.EncodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref writer, 2, value.ListOfAlarmValues);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 3, value.ModePropertyReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfLifeSafety value)
        => AsduConstructed.Encode<EventParameterTChangeOfLifeSafetyCodec, T::EventParameter.TChangeOfLifeSafety>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfLifeSafety value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetSequenceOfEncodedLength<LifeSafetyStateCodec, T::LifeSafetyState>(1, value.ListOfLifeSafetyAlarmValues);
        length += AsduElement.GetSequenceOfEncodedLength<LifeSafetyStateCodec, T::LifeSafetyState>(2, value.ListOfAlarmValues);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(3, value.ModePropertyReference);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfLifeSafety value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfLifeSafetyCodec, T::EventParameter.TChangeOfLifeSafety>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
