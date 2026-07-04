// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTBufferReadyCodec :
    IAsduElementCodec<T::NotificationParameters.TBufferReady>,
    IAsduConstructedCodec<T::NotificationParameters.TBufferReady>
{
    public static T::NotificationParameters.TBufferReady Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TBufferReady
        {
            BufferProperty = AsduElement.Decode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 0),
            PreviousNotification = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 1),
            CurrentNotification = AsduElement.Decode<Unsigned32Codec, uint>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TBufferReady Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTBufferReadyCodec, T::NotificationParameters.TBufferReady>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TBufferReady value)
    {
        AsduElement.Encode<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 0, value.BufferProperty);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 1, value.PreviousNotification);
        AsduElement.Encode<Unsigned32Codec, uint>(ref writer, 2, value.CurrentNotification);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TBufferReady value)
        => AsduConstructed.Encode<NotificationParametersTBufferReadyCodec, T::NotificationParameters.TBufferReady>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TBufferReady value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(0, value.BufferProperty);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(1, value.PreviousNotification);
        length += AsduElement.GetEncodedLength<Unsigned32Codec, uint>(2, value.CurrentNotification);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TBufferReady value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTBufferReadyCodec, T::NotificationParameters.TBufferReady>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
