// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultOutOfRangeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekOpeningTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange Decode(ref NativeReader reader)
    {
        var _minNormalValue = Asdu.DecodeConstructed<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref reader, 0);
        var _maxNormalValue = Asdu.DecodeConstructed<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange
        {
            MinNormalValue = _minNormalValue,
            MaxNormalValue = _maxNormalValue
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange value)
    {
        Asdu.EncodeElement<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref writer, 0, value.MinNormalValue);
        Asdu.EncodeElement<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref writer, 1, value.MaxNormalValue);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange value)
    {
        return Asdu.GetElementLength<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(0, value.MinNormalValue) + Asdu.GetElementLength<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(1, value.MaxNormalValue);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
