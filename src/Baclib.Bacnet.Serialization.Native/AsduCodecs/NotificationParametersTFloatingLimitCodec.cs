// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTFloatingLimitCodec :
    IAsduElementCodec<T::NotificationParameters.TFloatingLimit>,
    IAsduConstructedCodec<T::NotificationParameters.TFloatingLimit>
{
    public static T::NotificationParameters.TFloatingLimit Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TFloatingLimit
        {
            ReferenceValue = AsduElement.Decode<RealCodec, float>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            SetpointValue = AsduElement.Decode<RealCodec, float>(ref reader, 2),
            ErrorLimit = AsduElement.Decode<RealCodec, float>(ref reader, 3)
        };
    }

    public static T::NotificationParameters.TFloatingLimit Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTFloatingLimitCodec, T::NotificationParameters.TFloatingLimit>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TFloatingLimit value)
    {
        AsduElement.Encode<RealCodec, float>(ref writer, 0, value.ReferenceValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<RealCodec, float>(ref writer, 2, value.SetpointValue);
        AsduElement.Encode<RealCodec, float>(ref writer, 3, value.ErrorLimit);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TFloatingLimit value)
        => AsduConstructed.Encode<NotificationParametersTFloatingLimitCodec, T::NotificationParameters.TFloatingLimit>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TFloatingLimit value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<RealCodec, float>(0, value.ReferenceValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<RealCodec, float>(2, value.SetpointValue);
        length += AsduElement.GetEncodedLength<RealCodec, float>(3, value.ErrorLimit);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TFloatingLimit value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTFloatingLimitCodec, T::NotificationParameters.TFloatingLimit>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
