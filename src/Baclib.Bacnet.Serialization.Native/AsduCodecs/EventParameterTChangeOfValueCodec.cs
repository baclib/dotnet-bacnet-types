// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfValueCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfValue>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfValue>
{
    public static T::EventParameter.TChangeOfValue Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfValue
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            CovCriteria = AsduElement.Decode<EventParameterTChangeOfValueTCovCriteriaCodec, T::EventParameter.TChangeOfValue.TCovCriteria>(ref reader, 1)
        };
    }

    public static T::EventParameter.TChangeOfValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfValueCodec, T::EventParameter.TChangeOfValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfValue value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.Encode<EventParameterTChangeOfValueTCovCriteriaCodec, T::EventParameter.TChangeOfValue.TCovCriteria>(ref writer, 1, value.CovCriteria);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfValue value)
        => AsduConstructed.Encode<EventParameterTChangeOfValueCodec, T::EventParameter.TChangeOfValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetEncodedLength<EventParameterTChangeOfValueTCovCriteriaCodec, T::EventParameter.TChangeOfValue.TCovCriteria>(1, value.CovCriteria);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfValueCodec, T::EventParameter.TChangeOfValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
