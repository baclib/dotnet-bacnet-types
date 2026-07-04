// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfBitstringCodec :
    IAsduElementCodec<T::NotificationParameters.TChangeOfBitstring>,
    IAsduConstructedCodec<T::NotificationParameters.TChangeOfBitstring>
{
    public static T::NotificationParameters.TChangeOfBitstring Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TChangeOfBitstring
        {
            ReferencedBitstring = AsduElement.Decode<BitStringCodec, T::BitString>(ref reader, 0),
            StatusFlags = AsduElement.Decode<StatusFlagsCodec, T::StatusFlags>(ref reader, 1)
        };
    }

    public static T::NotificationParameters.TChangeOfBitstring Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfBitstringCodec, T::NotificationParameters.TChangeOfBitstring>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TChangeOfBitstring value)
    {
        AsduElement.Encode<BitStringCodec, T::BitString>(ref writer, 0, value.ReferencedBitstring);
        AsduElement.Encode<StatusFlagsCodec, T::StatusFlags>(ref writer, 1, value.StatusFlags);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TChangeOfBitstring value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfBitstringCodec, T::NotificationParameters.TChangeOfBitstring>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfBitstring value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<BitStringCodec, T::BitString>(0, value.ReferencedBitstring);
        length += AsduElement.GetEncodedLength<StatusFlagsCodec, T::StatusFlags>(1, value.StatusFlags);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TChangeOfBitstring value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTChangeOfBitstringCodec, T::NotificationParameters.TChangeOfBitstring>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
