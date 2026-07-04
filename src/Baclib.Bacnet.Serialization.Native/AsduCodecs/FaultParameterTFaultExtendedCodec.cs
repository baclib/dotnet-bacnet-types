// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultExtendedCodec :
    IAsduElementCodec<T::FaultParameter.TFaultExtended>,
    IAsduConstructedCodec<T::FaultParameter.TFaultExtended>
{
    public static T::FaultParameter.TFaultExtended Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultExtended
        {
            VendorId = AsduElement.Decode<Unsigned16Codec, ushort>(ref reader, 0),
            ExtendedFaultType = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1),
            Parameters = AsduElement.DecodeSequenceOf<FaultParameterTFaultExtendedTParametersItemCodec, T::FaultParameter.TFaultExtended.TParametersItem>(ref reader, 2)
        };
    }

    public static T::FaultParameter.TFaultExtended Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultExtendedCodec, T::FaultParameter.TFaultExtended>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultExtended value)
    {
        AsduElement.Encode<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.ExtendedFaultType);
        AsduElement.EncodeSequenceOf<FaultParameterTFaultExtendedTParametersItemCodec, T::FaultParameter.TFaultExtended.TParametersItem>(ref writer, 2, value.Parameters);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultExtended value)
        => AsduConstructed.Encode<FaultParameterTFaultExtendedCodec, T::FaultParameter.TFaultExtended>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultExtended value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned16Codec, ushort>(0, value.VendorId);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.ExtendedFaultType);
        length += AsduElement.GetSequenceOfEncodedLength<FaultParameterTFaultExtendedTParametersItemCodec, T::FaultParameter.TFaultExtended.TParametersItem>(2, value.Parameters);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultExtended value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultExtendedCodec, T::FaultParameter.TFaultExtended>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
