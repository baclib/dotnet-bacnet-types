// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfStateCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfState>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfState>
{
    public static T::NotificationParameters.TChangeOfState Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfState
        {
            NewState = AsduElement.Decode<PropertyStatesCodec, T::PropertyStates>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::NotificationParameters.TChangeOfState Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfStateCodec, T::NotificationParameters.TChangeOfState>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfState value)
    {
        AsduElement.Encode<PropertyStatesCodec, T::PropertyStates>(ref writer, 0, value.NewState);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfState value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfStateCodec, T::NotificationParameters.TChangeOfState>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfState value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<PropertyStatesCodec, T::PropertyStates>(0, value.NewState);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfState value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfStateCodec, T::NotificationParameters.TChangeOfState>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
