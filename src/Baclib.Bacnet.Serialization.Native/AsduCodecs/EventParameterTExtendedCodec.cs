// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTExtendedCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TExtended>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TExtended>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TExtended Decode(ref NativeReader reader)
    {
        var _vendorId = Asdu.DecodePrimitive<Unsigned16Codec, ushort>(ref reader, 0);
        var _extendedEventType = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
        var _parameters = Asdu.DecodeSequenceOf<EventParameterTExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParameters.TParametersItem>(ref reader, 2);

        return new global::Baclib.Bacnet.Types.Application.EventParameter.TExtended
        {
            VendorId = _vendorId,
            ExtendedEventType = _extendedEventType,
            Parameters = _parameters
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TExtended Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended value)
    {
        Asdu.EncodePrimitive<Unsigned16Codec, ushort>(ref writer, 0, value.VendorId);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.ExtendedEventType);
        writer.WriteOpeningTag(2);
        foreach (var item in value.Parameters)
        {
            Asdu.EncodeElement<EventParameterTExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParameters.TParametersItem>(ref writer, 2, item);
        }
        writer.WriteClosingTag(2);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended value)
    {
        return Asdu.GetPrimitiveLength<Unsigned16Codec, ushort>(0, value.VendorId) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.ExtendedEventType) + (AsduLength.FromTagNumber((byte)2) + (value.Parameters.Items.Sum(static item => Asdu.GetElementLength<EventParameterTExtendedTParametersTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParameters.TParametersItem>(2, item))) + AsduLength.FromTagNumber((byte)2));
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
