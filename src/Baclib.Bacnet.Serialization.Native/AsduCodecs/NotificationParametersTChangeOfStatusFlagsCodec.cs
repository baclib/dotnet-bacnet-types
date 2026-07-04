// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfStatusFlagsCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfStatusFlags>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfStatusFlags>
{
    public static T::NotificationParameters.TChangeOfStatusFlags Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfStatusFlags
        {
            PresentValue = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader, 0),
            ReferencedFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::NotificationParameters.TChangeOfStatusFlags Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfStatusFlagsCodec, T::NotificationParameters.TChangeOfStatusFlags>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfStatusFlags value)
    {
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, 0, value.PresentValue);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.ReferencedFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfStatusFlags value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfStatusFlagsCodec, T::NotificationParameters.TChangeOfStatusFlags>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfStatusFlags value)
    {
        var length = 0;
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(0, value.PresentValue);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.ReferencedFlags);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfStatusFlags value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfStatusFlagsCodec, T::NotificationParameters.TChangeOfStatusFlags>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        if (reader.PeekContextTag(0))
        {
            return true;
        }
        return reader.PeekContextTag(1);
    }
}
