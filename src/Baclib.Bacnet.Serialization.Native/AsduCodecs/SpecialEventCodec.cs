// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SpecialEventCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SpecialEvent>
{
    public static bool Matches(ref NativeReader reader)
    {
        return SpecialEventTPeriodCodec.Matches(ref reader);
    }

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent Decode(ref NativeReader reader)
    {
        var _period = Asdu.DecodeElement<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(ref reader);
        var _listOfTimeValues = Asdu.DecodeSequenceOf<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(ref reader, 2);
        var _eventPriority = Asdu.DecodePrimitive<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref reader, 3);

        return new global::Baclib.Bacnet.Types.Application.SpecialEvent
        {
            Period = _period,
            ListOfTimeValues = _listOfTimeValues,
            EventPriority = _eventPriority
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SpecialEvent Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SpecialEvent value)
    {
        Asdu.EncodeElement<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(ref writer, value.Period);
        writer.WriteOpeningTag(2);
        foreach (var item in value.ListOfTimeValues)
        {
            Asdu.EncodeElement<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
        Asdu.EncodePrimitive<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(ref writer, 3, value.EventPriority);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SpecialEvent value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent value)
    {
        return Asdu.GetElementLength<SpecialEventTPeriodCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TPeriod>(value.Period) + (AsduLength.FromTagNumber((byte)2) + (value.ListOfTimeValues.Items.Sum(static item => Asdu.GetElementLength<TimeValueCodec, global::Baclib.Bacnet.Types.Application.TimeValue>(2, item))) + AsduLength.FromTagNumber((byte)2)) + Asdu.GetPrimitiveLength<SpecialEventTEventPriorityCodec, global::Baclib.Bacnet.Types.Application.SpecialEvent.TEventPriority>(3, value.EventPriority);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SpecialEvent value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
