// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTCommandFailureCodec :
    IAsduElementCodec<T::NotificationParameters.TCommandFailure>,
    IAsduConstructedCodec<T::NotificationParameters.TCommandFailure>
{
    public static T::NotificationParameters.TCommandFailure Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TCommandFailure
        {
            CommandValue = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1),
            FeedbackValue = AsduElement.Decode<AnyCodec, T::Any>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TCommandFailure Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTCommandFailureCodec, T::NotificationParameters.TCommandFailure>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TCommandFailure value)
    {
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 0, value.CommandValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
        AsduElement.Encode<AnyCodec, T::Any>(ref writer, 2, value.FeedbackValue);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TCommandFailure value)
        => AsduConstructed.Encode<NotificationParametersTCommandFailureCodec, T::NotificationParameters.TCommandFailure>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TCommandFailure value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(0, value.CommandValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        length += AsduElement.GetEncodedLength<AnyCodec, T::Any>(2, value.FeedbackValue);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TCommandFailure value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTCommandFailureCodec, T::NotificationParameters.TCommandFailure>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
