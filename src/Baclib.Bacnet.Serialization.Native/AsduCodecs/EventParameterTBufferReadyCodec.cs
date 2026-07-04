// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTBufferReadyCodec :
    IAsduElementCodec<T::EventParameter.TBufferReady>,
    IAsduConstructedCodec<T::EventParameter.TBufferReady>
{
    public static T::EventParameter.TBufferReady Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TBufferReady
        {
            NotificationThreshold = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            PreviousNotificationCount = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 1)
        };
    }

    public static T::EventParameter.TBufferReady Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTBufferReadyCodec, T::EventParameter.TBufferReady>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TBufferReady value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.NotificationThreshold);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 1, value.PreviousNotificationCount);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TBufferReady value)
        => AsduConstructed.Encode<EventParameterTBufferReadyCodec, T::EventParameter.TBufferReady>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TBufferReady value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.NotificationThreshold);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(1, value.PreviousNotificationCount);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TBufferReady value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTBufferReadyCodec, T::EventParameter.TBufferReady>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
