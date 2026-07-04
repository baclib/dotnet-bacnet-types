// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTCommandFailureCodec :
    IAsduElementCodec<T::EventParameter.TCommandFailure>,
    IAsduConstructedCodec<T::EventParameter.TCommandFailure>
{
    public static T::EventParameter.TCommandFailure Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TCommandFailure
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            FeedbackPropertyReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 1)
        };
    }

    public static T::EventParameter.TCommandFailure Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTCommandFailureCodec, T::EventParameter.TCommandFailure>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TCommandFailure value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 1, value.FeedbackPropertyReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TCommandFailure value)
        => AsduConstructed.Encode<EventParameterTCommandFailureCodec, T::EventParameter.TCommandFailure>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TCommandFailure value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(1, value.FeedbackPropertyReference);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TCommandFailure value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTCommandFailureCodec, T::EventParameter.TCommandFailure>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
