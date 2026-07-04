// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfCharacterstringCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfCharacterstring>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfCharacterstring>
{
    public static T::NotificationParameters.TChangeOfCharacterstring Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfCharacterstring
        {
            ChangedValue = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            AlarmValue = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TChangeOfCharacterstring Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfCharacterstringCodec, T::NotificationParameters.TChangeOfCharacterstring>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfCharacterstring value)
    {
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 0, value.ChangedValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 2, value.AlarmValue);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfCharacterstring value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfCharacterstringCodec, T::NotificationParameters.TChangeOfCharacterstring>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfCharacterstring value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(0, value.ChangedValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(2, value.AlarmValue);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfCharacterstring value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfCharacterstringCodec, T::NotificationParameters.TChangeOfCharacterstring>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
