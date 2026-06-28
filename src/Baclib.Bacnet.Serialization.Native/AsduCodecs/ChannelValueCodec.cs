// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ChannelValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ChannelValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ChannelValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.Real:
            case ApplicationTagNumber.Enumerated:
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Boolean:
            case ApplicationTagNumber.Signed:
            case ApplicationTagNumber.Double:
            case ApplicationTagNumber.TimePattern:
            case ApplicationTagNumber.CharacterString:
            case ApplicationTagNumber.OctetString:
            case ApplicationTagNumber.BitString:
            case ApplicationTagNumber.DatePattern:
            case ApplicationTagNumber.ObjectIdentifier:
                return true;
            default:
                break;
        }

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ChannelValue Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromNull(_null);
        }
        // info
        if (reader.PeekTag(RealCodec.TagNumber))
        {
            //var _real = Asdu.Decode<RealCodec, float>(ref reader);
            var _real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromReal(_real);
        }
        // info
        if (reader.PeekTag(Enumerated32Codec.TagNumber))
        {
            //var _enumerated = Asdu.Decode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref reader);
            var _enumerated = Enumerated32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromEnumerated(_enumerated);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromUnsigned(_unsigned);
        }
        // info
        if (reader.PeekTag(BooleanCodec.TagNumber))
        {
            //var _boolean = Asdu.Decode<BooleanCodec, bool>(ref reader);
            var _boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromBoolean(_boolean);
        }
        // info
        if (reader.PeekTag(IntegerCodec.TagNumber))
        {
            //var _integer = Asdu.Decode<IntegerCodec, int>(ref reader);
            var _integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromInteger(_integer);
        }
        // info
        if (reader.PeekTag(DoubleCodec.TagNumber))
        {
            //var _double = Asdu.Decode<DoubleCodec, double>(ref reader);
            var _double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromDouble(_double);
        }
        // info
        if (reader.PeekTag(TimeCodec.TagNumber))
        {
            //var _time = Asdu.Decode<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);
            var _time = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromTime(_time);
        }
        // info
        if (reader.PeekTag(CharacterStringCodec.TagNumber))
        {
            //var _characterstring = Asdu.Decode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
            var _characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromCharacterstring(_characterstring);
        }
        // info
        if (reader.PeekTag(OctetStringCodec.TagNumber))
        {
            //var _octetstring = Asdu.Decode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
            var _octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromOctetstring(_octetstring);
        }
        // info
        if (reader.PeekTag(BitStringCodec.TagNumber))
        {
            //var _bitstring = Asdu.Decode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader);
            var _bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromBitstring(_bitstring);
        }
        // info
        if (reader.PeekTag(DateCodec.TagNumber))
        {
            //var _date = Asdu.Decode<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref reader);
            var _date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromDate(_date);
        }
        // info
        if (reader.PeekTag(ObjectIdentifierCodec.TagNumber))
        {
            //var _objectidentifier = Asdu.Decode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
            var _objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromObjectidentifier(_objectidentifier);
        }

        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _lightingCommand = Asdu.DecodeConstructed<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromLightingCommand(_lightingCommand);
            case 1:
                var _xycolor = Asdu.DecodeConstructed<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromXycolor(_xycolor);
            case 2:
                var _colorCommand = Asdu.DecodeConstructed<ColorCommandCodec, global::Baclib.Bacnet.Types.Application.ColorCommand>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromColorCommand(_colorCommand);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ChannelValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ChannelValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Real:
                //Asdu.Encode<RealCodec, float>(ref writer, value.Real);
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Enumerated:
                //Asdu.Encode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref writer, value.Enumerated);
                Enumerated32Codec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Boolean:
                //Asdu.Encode<BooleanCodec, bool>(ref writer, value.Boolean);
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Integer:
                //Asdu.Encode<IntegerCodec, int>(ref writer, value.Integer);
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Double:
                //Asdu.Encode<DoubleCodec, double>(ref writer, value.Double);
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Time:
                //Asdu.Encode<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.Time);
                TimeCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Characterstring:
                //Asdu.Encode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.Characterstring);
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Octetstring:
                //Asdu.Encode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.Octetstring);
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Bitstring:
                //Asdu.Encode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, value.Bitstring);
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Date:
                //Asdu.Encode<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref writer, value.Date);
                DateCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Objectidentifier:
                //Asdu.Encode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.Objectidentifier);
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.LightingCommand:
                Asdu.EncodeConstructed<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(ref writer, 0, value.LightingCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Xycolor:
                Asdu.EncodeConstructed<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(ref writer, 1, value.Xycolor);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.ColorCommand:
                Asdu.EncodeConstructed<ColorCommandCodec, global::Baclib.Bacnet.Types.Application.ColorCommand>(ref writer, 2, value.ColorCommand);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ChannelValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ChannelValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Real:
                return Asdu.GetEncodedLength<RealCodec, float>(value.Real);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Enumerated:
                return Asdu.GetEncodedLength<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(value.Enumerated);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Boolean:
                return Asdu.GetEncodedLength<BooleanCodec, bool>(value.Boolean);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Integer:
                return Asdu.GetEncodedLength<IntegerCodec, int>(value.Integer);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Double:
                return Asdu.GetEncodedLength<DoubleCodec, double>(value.Double);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Time:
                return Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.Time);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Characterstring:
                return Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.Characterstring);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Octetstring:
                return Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.Octetstring);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Bitstring:
                return Asdu.GetEncodedLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(value.Bitstring);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Date:
                return Asdu.GetEncodedLength<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(value.Date);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Objectidentifier:
                return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.Objectidentifier);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.LightingCommand:
                return Asdu.GetConstructedLength<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(0, value.LightingCommand);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Xycolor:
                return Asdu.GetConstructedLength<XyColorCodec, global::Baclib.Bacnet.Types.Application.XyColor>(1, value.Xycolor);
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.ColorCommand:
                return Asdu.GetConstructedLength<ColorCommandCodec, global::Baclib.Bacnet.Types.Application.ColorCommand>(2, value.ColorCommand);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ChannelValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}