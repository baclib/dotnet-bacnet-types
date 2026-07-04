// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTFloatingLimitCodec :
    IAsduElementCodec<T::EventParameter.TFloatingLimit>,
    IAsduConstructedCodec<T::EventParameter.TFloatingLimit>
{
    public static T::EventParameter.TFloatingLimit Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TFloatingLimit
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            SetpointReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 1),
            LowDiffLimit = AsduElement.Decode<RealCodec, float>(ref reader, 2),
            HighDiffLimit = AsduElement.Decode<RealCodec, float>(ref reader, 3),
            Deadband = AsduElement.Decode<RealCodec, float>(ref reader, 4)
        };
    }

    public static T::EventParameter.TFloatingLimit Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTFloatingLimitCodec, T::EventParameter.TFloatingLimit>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TFloatingLimit value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 1, value.SetpointReference);
        AsduElement.Encode<RealCodec, float>(ref writer, 2, value.LowDiffLimit);
        AsduElement.Encode<RealCodec, float>(ref writer, 3, value.HighDiffLimit);
        AsduElement.Encode<RealCodec, float>(ref writer, 4, value.Deadband);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TFloatingLimit value)
        => AsduConstructed.Encode<EventParameterTFloatingLimitCodec, T::EventParameter.TFloatingLimit>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TFloatingLimit value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(1, value.SetpointReference);
        length += AsduElement.GetEncodedLength<RealCodec, float>(2, value.LowDiffLimit);
        length += AsduElement.GetEncodedLength<RealCodec, float>(3, value.HighDiffLimit);
        length += AsduElement.GetEncodedLength<RealCodec, float>(4, value.Deadband);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TFloatingLimit value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTFloatingLimitCodec, T::EventParameter.TFloatingLimit>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
