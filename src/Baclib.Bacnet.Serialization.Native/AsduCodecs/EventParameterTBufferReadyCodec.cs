// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTBufferReadyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady Decode(ref NativeReader reader)
    {
        var _notificationThreshold = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _previousNotificationCount = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady
        {
            NotificationThreshold = _notificationThreshold,
            PreviousNotificationCount = _previousNotificationCount
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.NotificationThreshold);
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 1, value.PreviousNotificationCount);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.NotificationThreshold) + Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(1, value.PreviousNotificationCount);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TBufferReady value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
