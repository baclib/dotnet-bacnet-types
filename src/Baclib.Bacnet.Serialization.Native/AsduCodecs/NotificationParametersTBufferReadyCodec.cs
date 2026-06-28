// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTBufferReadyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady Decode(ref NativeReader reader)
    {
        var _bufferProperty = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 0);
        var _previousNotification = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 1);
        var _currentNotification = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady
        {
            BufferProperty = _bufferProperty,
            PreviousNotification = _previousNotification,
            CurrentNotification = _currentNotification
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady value)
    {
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 0, value.BufferProperty);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 1, value.PreviousNotification);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 2, value.CurrentNotification);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady value)
    {
        return Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(0, value.BufferProperty) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(1, value.PreviousNotification) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(2, value.CurrentNotification);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TBufferReady value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
