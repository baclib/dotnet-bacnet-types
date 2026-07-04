// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTExtendedCodec :
    IAsduElementCodec<T::EventParameter.TExtended>,
    IAsduConstructedCodec<T::EventParameter.TExtended>
{
    public static T::EventParameter.TExtended Decode(ref AsduReader reader)
    {
        return new T::EventParameter.TExtended
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            ExtendedEventType = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            Parameters = AsduElement.DecodeSequenceOf<EventParameterTExtendedTParametersItemCodec, T::EventParameter.TExtended.TParametersItem>(ref reader, 2)
        };
    }

    public static T::EventParameter.TExtended Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTExtendedCodec, T::EventParameter.TExtended>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::EventParameter.TExtended value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.ExtendedEventType);
        AsduElement.EncodeSequenceOf<EventParameterTExtendedTParametersItemCodec, T::EventParameter.TExtended.TParametersItem>(ref writer, 2, value.Parameters);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::EventParameter.TExtended value)
        => AsduConstructed.Encode<EventParameterTExtendedCodec, T::EventParameter.TExtended>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::EventParameter.TExtended value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.VendorId);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.ExtendedEventType);
        length += AsduElement.GetSequenceOfEncodedLength<EventParameterTExtendedTParametersItemCodec, T::EventParameter.TExtended.TParametersItem>(2, value.Parameters);
        return length;
    }

    public static int GetEncodedLength(in T::EventParameter.TExtended value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<EventParameterTExtendedCodec, T::EventParameter.TExtended>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
