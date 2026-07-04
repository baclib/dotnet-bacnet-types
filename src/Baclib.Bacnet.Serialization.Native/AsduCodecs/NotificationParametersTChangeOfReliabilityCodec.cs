// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfReliabilityCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfReliability>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfReliability>
{
    public static T::NotificationParameters.TChangeOfReliability Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfReliability
        {
            Reliability = AsduElement.Decode<ReliabilityCodec, T::Reliability>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            PropertyValues = AsduElement.DecodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TChangeOfReliability Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfReliabilityCodec, T::NotificationParameters.TChangeOfReliability>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfReliability value)
    {
        AsduElement.Encode<ReliabilityCodec, T::Reliability>(ref writer, 0, value.Reliability);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.EncodeSequenceOf<PropertyValueCodec, T::PropertyValue>(ref writer, 2, value.PropertyValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfReliability value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfReliabilityCodec, T::NotificationParameters.TChangeOfReliability>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfReliability value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<ReliabilityCodec, T::Reliability>(0, value.Reliability);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetSequenceOfEncodedLength<PropertyValueCodec, T::PropertyValue>(2, value.PropertyValues);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfReliability value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfReliabilityCodec, T::NotificationParameters.TChangeOfReliability>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
