// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfCharacterstringCodec :
    IAsduElementCodec<T::EventParameter.TChangeOfCharacterstring>,
    IAsduConstructedCodec<T::EventParameter.TChangeOfCharacterstring>
{
    public static T::EventParameter.TChangeOfCharacterstring Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TChangeOfCharacterstring
        {
            TimeDelay = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            ListOfAlarmValues = AsduElement.DecodeSequenceOf<CharacterStringCodec, T::CharacterString>(ref reader, 1)
        };
    }

    public static T::EventParameter.TChangeOfCharacterstring Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTChangeOfCharacterstringCodec, T::EventParameter.TChangeOfCharacterstring>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TChangeOfCharacterstring value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.TimeDelay);
        AsduElement.EncodeSequenceOf<CharacterStringCodec, T::CharacterString>(ref writer, 1, value.ListOfAlarmValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TChangeOfCharacterstring value)
        => AsduConstructed.Encode<EventParameterTChangeOfCharacterstringCodec, T::EventParameter.TChangeOfCharacterstring>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TChangeOfCharacterstring value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.TimeDelay);
        length += AsduElement.GetSequenceOfEncodedLength<CharacterStringCodec, T::CharacterString>(1, value.ListOfAlarmValues);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TChangeOfCharacterstring value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTChangeOfCharacterstringCodec, T::EventParameter.TChangeOfCharacterstring>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
