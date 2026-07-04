// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTExtendedCodec :
    IAsduElementCodec<T::NotificationParameters.TExtended>,
    IAsduConstructedCodec<T::NotificationParameters.TExtended>
{
    public static T::NotificationParameters.TExtended Decode(ref AsduReader reader)
    {
        return new T::NotificationParameters.TExtended
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            ExtendedEventType = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            Parameters = AsduElement.DecodeSequenceOf<NotificationParametersTExtendedTParametersItemCodec, T::NotificationParameters.TExtended.TParametersItem>(ref reader, 2)
        };
    }

    public static T::NotificationParameters.TExtended Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTExtendedCodec, T::NotificationParameters.TExtended>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NotificationParameters.TExtended value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.ExtendedEventType);
        AsduElement.EncodeSequenceOf<NotificationParametersTExtendedTParametersItemCodec, T::NotificationParameters.TExtended.TParametersItem>(ref writer, 2, value.Parameters);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NotificationParameters.TExtended value)
        => AsduConstructed.Encode<NotificationParametersTExtendedCodec, T::NotificationParameters.TExtended>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NotificationParameters.TExtended value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.VendorId);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.ExtendedEventType);
        length += AsduElement.GetSequenceOfEncodedLength<NotificationParametersTExtendedTParametersItemCodec, T::NotificationParameters.TExtended.TParametersItem>(2, value.Parameters);
        return length;
    }

    public static int GetEncodedLength(in T::NotificationParameters.TExtended value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NotificationParametersTExtendedCodec, T::NotificationParameters.TExtended>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
