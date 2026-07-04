// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultLifeSafetyCodec :
    IAsduElementCodec<T::FaultParameter.TFaultLifeSafety>,
    IAsduConstructedCodec<T::FaultParameter.TFaultLifeSafety>
{
    public static T::FaultParameter.TFaultLifeSafety Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultLifeSafety
        {
            ListOfFaultValues = AsduElement.DecodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref reader, 0),
            ModePropertyReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 1)
        };
    }

    public static T::FaultParameter.TFaultLifeSafety Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultLifeSafetyCodec, T::FaultParameter.TFaultLifeSafety>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultLifeSafety value)
    {
        AsduElement.EncodeSequenceOf<LifeSafetyStateCodec, T::LifeSafetyState>(ref writer, 0, value.ListOfFaultValues);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 1, value.ModePropertyReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultLifeSafety value)
        => AsduConstructed.Encode<FaultParameterTFaultLifeSafetyCodec, T::FaultParameter.TFaultLifeSafety>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultLifeSafety value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<LifeSafetyStateCodec, T::LifeSafetyState>(0, value.ListOfFaultValues);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(1, value.ModePropertyReference);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultLifeSafety value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultLifeSafetyCodec, T::FaultParameter.TFaultLifeSafety>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
