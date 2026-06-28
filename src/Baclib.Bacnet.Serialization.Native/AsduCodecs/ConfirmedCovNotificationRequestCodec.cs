// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ConfirmedCovNotificationRequestCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest Decode(ref NativeReader reader)
    {
        var _subscriberProcessIdentifier = Asdu.DecodePrimitive<Unsigned32Codec, uint>(ref reader, 0);
        var _initiatingDeviceIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 1);
        var _monitoredObjectIdentifier = Asdu.DecodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader, 2);
        var _timeRemaining = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 3);
        var _listOfValues = Asdu.DecodeSequenceOf<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref reader, 4);

        return new global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest
        {
            SubscriberProcessIdentifier = _subscriberProcessIdentifier,
            InitiatingDeviceIdentifier = _initiatingDeviceIdentifier,
            MonitoredObjectIdentifier = _monitoredObjectIdentifier,
            TimeRemaining = _timeRemaining,
            ListOfValues = _listOfValues
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest value)
    {
        Asdu.EncodePrimitive<Unsigned32Codec, uint>(ref writer, 0, value.SubscriberProcessIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 1, value.InitiatingDeviceIdentifier);
        Asdu.EncodePrimitive<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, 2, value.MonitoredObjectIdentifier);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 3, value.TimeRemaining);
        writer.WriteOpeningTag(4);
        foreach (var item in value.ListOfValues)
        {
            Asdu.EncodeElement<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(ref writer, 4, item);
        }
        writer.WriteClosingTag(4);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest value)
    {
        return Asdu.GetPrimitiveLength<Unsigned32Codec, uint>(0, value.SubscriberProcessIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(1, value.InitiatingDeviceIdentifier) + Asdu.GetPrimitiveLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(2, value.MonitoredObjectIdentifier) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(3, value.TimeRemaining) + (AsduLength.FromTagNumber((byte)4) + (value.ListOfValues.Items.Sum(static item => Asdu.GetElementLength<PropertyValueCodec, global::Baclib.Bacnet.Types.Application.PropertyValue>(4, item))) + AsduLength.FromTagNumber((byte)4));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ConfirmedCovNotificationRequest value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
