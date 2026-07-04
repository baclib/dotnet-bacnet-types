// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultOutOfRangeCodec :
    IAsduElementCodec<T::FaultParameter.TFaultOutOfRange>,
    IAsduConstructedCodec<T::FaultParameter.TFaultOutOfRange>
{
    public static T::FaultParameter.TFaultOutOfRange Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultOutOfRange
        {
            MinNormalValue = AsduElement.Decode<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref reader, 0),
            MaxNormalValue = AsduElement.Decode<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref reader, 1)
        };
    }

    public static T::FaultParameter.TFaultOutOfRange Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultOutOfRangeCodec, T::FaultParameter.TFaultOutOfRange>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultOutOfRange value)
    {
        AsduElement.Encode<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref writer, 0, value.MinNormalValue);
        AsduElement.Encode<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref writer, 1, value.MaxNormalValue);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultOutOfRange value)
        => AsduConstructed.Encode<FaultParameterTFaultOutOfRangeCodec, T::FaultParameter.TFaultOutOfRange>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultOutOfRange value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMinNormalValue>(0, value.MinNormalValue);
        length += AsduElement.GetEncodedLength<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, T::FaultParameter.TFaultOutOfRange.TMaxNormalValue>(1, value.MaxNormalValue);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultOutOfRange value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultOutOfRangeCodec, T::FaultParameter.TFaultOutOfRange>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
