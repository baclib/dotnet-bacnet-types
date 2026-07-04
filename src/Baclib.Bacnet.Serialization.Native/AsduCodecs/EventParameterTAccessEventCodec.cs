// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTAccessEventCodec :
    IAsduElementCodec<T::EventParameter.TAccessEvent>,
    IAsduConstructedCodec<T::EventParameter.TAccessEvent>
{
    public static T::EventParameter.TAccessEvent Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TAccessEvent
        {
            ListOfAccessEvents = AsduElement.DecodeSequenceOf<AccessEventCodec, T::AccessEvent>(ref reader, 0),
            AccessEventTimeReference = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 1)
        };
    }

    public static T::EventParameter.TAccessEvent Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTAccessEventCodec, T::EventParameter.TAccessEvent>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TAccessEvent value)
    {
        AsduElement.EncodeSequenceOf<AccessEventCodec, T::AccessEvent>(ref writer, 0, value.ListOfAccessEvents);
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 1, value.AccessEventTimeReference);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TAccessEvent value)
        => AsduConstructed.Encode<EventParameterTAccessEventCodec, T::EventParameter.TAccessEvent>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TAccessEvent value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<AccessEventCodec, T::AccessEvent>(0, value.ListOfAccessEvents);
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(1, value.AccessEventTimeReference);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TAccessEvent value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTAccessEventCodec, T::EventParameter.TAccessEvent>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
