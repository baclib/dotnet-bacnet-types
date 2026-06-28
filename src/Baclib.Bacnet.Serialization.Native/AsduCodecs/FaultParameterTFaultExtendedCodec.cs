// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultExtendedCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _extendedFaultType = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _parameters = Asdu.DecodeSequenceOf<FaultParameterTFaultExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParameters.TParametersItem>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended
        {
            VendorId = _vendorId,
            ExtendedFaultType = _extendedFaultType,
            Parameters = _parameters
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.ExtendedFaultType);
        writer.WriteOpeningTag(2);
        foreach (var item in value.Parameters)
        {
            Asdu.EncodeElement<FaultParameterTFaultExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParameters.TParametersItem>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.VendorId) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.ExtendedFaultType) + (AsduLength.FromTagNumber((byte)2) + (value.Parameters.Items.Sum(static item => Asdu.GetElementLength<FaultParameterTFaultExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParameters.TParametersItem>(2, item))) + AsduLength.FromTagNumber((byte)2));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
