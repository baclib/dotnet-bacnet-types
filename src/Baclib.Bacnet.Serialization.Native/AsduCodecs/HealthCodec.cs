// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class HealthCodec :
    IAsduElementCodec<T::Health>,
    IAsduConstructedCodec<T::Health>
{
    public static T::Health Decode(ref AsduReader reader)
    {
        return new T::Health
        {
            Timestamp = AsduElement.Decode<DateTimeCodec, T::DateTime>(ref reader, 0),
            Result = AsduElement.Decode<ErrorCodec, T::Error>(ref reader, 1),
            Property = AsduElement.DecodeOptional<PropertyIdentifierCodec, T::PropertyIdentifier>(ref reader, 2),
            Details = AsduElement.DecodeOptional<CharacterStringCodec, T::CharacterString>(ref reader, 3)
        };
    }

    public static T::Health Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<HealthCodec, T::Health>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::Health value)
    {
        AsduElement.Encode<DateTimeCodec, T::DateTime>(ref writer, 0, value.Timestamp);
        AsduElement.Encode<ErrorCodec, T::Error>(ref writer, 1, value.Result);
        AsduElement.EncodeOptional<PropertyIdentifierCodec, T::PropertyIdentifier>(ref writer, 2, value.Property);
        AsduElement.EncodeOptional<CharacterStringCodec, T::CharacterString>(ref writer, 3, value.Details);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::Health value)
        => AsduConstructed.Encode<HealthCodec, T::Health>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::Health value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<DateTimeCodec, T::DateTime>(0, value.Timestamp);
        length += AsduElement.GetEncodedLength<ErrorCodec, T::Error>(1, value.Result);
        length += AsduElement.GetOptionalEncodedLength<PropertyIdentifierCodec, T::PropertyIdentifier>(2, value.Property);
        length += AsduElement.GetOptionalEncodedLength<CharacterStringCodec, T::CharacterString>(3, value.Details);
        return length;
    }

    public static int GetEncodedLength(in T::Health value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<HealthCodec, T::Health>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
