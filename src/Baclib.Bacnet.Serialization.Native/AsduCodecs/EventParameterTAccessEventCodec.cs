// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTAccessEventCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag(0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent Decode(ref NativeReader reader)
    {
        var _listOfAccessEvents = Asdu.DecodeSequenceOf<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref reader, 0);
        var _accessEventTimeReference = Asdu.DecodeConstructed<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent
        {
            ListOfAccessEvents = _listOfAccessEvents,
            AccessEventTimeReference = _accessEventTimeReference
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent value)
    {
        writer.WriteOpeningTag(0);
        foreach (var item in value.ListOfAccessEvents)
        {
            Asdu.EncodeElement<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(ref writer, 0, item);
        }
        writer.WriteClosingTag(0);
        Asdu.EncodeElement<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(ref writer, 1, value.AccessEventTimeReference);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent value)
    {
        return (AsduLength.FromTagNumber((byte)0) + (value.ListOfAccessEvents.Items.Sum(static item => Asdu.GetElementLength<AccessEventCodec, global::Baclib.Bacnet.Types.Application.AccessEvent>(0, item))) + AsduLength.FromTagNumber((byte)0)) + Asdu.GetElementLength<DeviceObjectPropertyReferenceCodec, global::Baclib.Bacnet.Types.Application.DeviceObjectPropertyReference>(1, value.AccessEventTimeReference);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TAccessEvent value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
