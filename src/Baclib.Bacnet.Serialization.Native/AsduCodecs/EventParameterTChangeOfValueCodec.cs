// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue Decode(ref NativeReader reader)
    {
        var _timeDelay = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _covCriteria = Asdu.DecodeConstructed<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue
        {
            TimeDelay = _timeDelay,
            CovCriteria = _covCriteria
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        Asdu.EncodeElement<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(ref writer, 1, value.CovCriteria);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.TimeDelay) + Asdu.GetElementLength<EventParameterTChangeOfValueTCovCriteriaCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue.TCovCriteria>(1, value.CovCriteria);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
