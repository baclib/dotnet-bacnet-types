// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimerStateChangeValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.Boolean:
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Signed:
            case ApplicationTagNumber.Real:
            case ApplicationTagNumber.Double:
            case ApplicationTagNumber.OctetString:
            case ApplicationTagNumber.CharacterString:
            case ApplicationTagNumber.BitString:
            case ApplicationTagNumber.Enumerated:
            case ApplicationTagNumber.DatePattern:
            case ApplicationTagNumber.TimePattern:
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
            case 3:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.TimerStateChangeValue Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromNull(_null);
        }
        // info
        if (reader.PeekTag(BooleanCodec.TagNumber))
        {
            //var _boolean = Asdu.Decode<BooleanCodec, bool>(ref reader);
            var _boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromBoolean(_boolean);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromUnsigned(_unsigned);
        }
        // info
        if (reader.PeekTag(IntegerCodec.TagNumber))
        {
            //var _integer = Asdu.Decode<IntegerCodec, int>(ref reader);
            var _integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromInteger(_integer);
        }
        // info
        if (reader.PeekTag(RealCodec.TagNumber))
        {
            //var _real = Asdu.Decode<RealCodec, float>(ref reader);
            var _real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromReal(_real);
        }
        // info
        if (reader.PeekTag(DoubleCodec.TagNumber))
        {
            //var _double = Asdu.Decode<DoubleCodec, double>(ref reader);
            var _double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDouble(_double);
        }
        // info
        if (reader.PeekTag(OctetStringCodec.TagNumber))
        {
            //var _octetstring = Asdu.Decode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
            var _octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromOctetstring(_octetstring);
        }
        // info
        if (reader.PeekTag(CharacterStringCodec.TagNumber))
        {
            //var _characterstring = Asdu.Decode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
            var _characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromCharacterstring(_characterstring);
        }
        // info
        if (reader.PeekTag(BitStringCodec.TagNumber))
        {
            //var _bitstring = Asdu.Decode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader);
            var _bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromBitstring(_bitstring);
        }
        // info
        if (reader.PeekTag(Enumerated32Codec.TagNumber))
        {
            //var _enumerated = Asdu.Decode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref reader);
            var _enumerated = Enumerated32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromEnumerated(_enumerated);
        }
        // info
        if (reader.PeekTag(DatePatternCodec.TagNumber))
        {
            //var _date = Asdu.Decode<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref reader);
            var _date = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDate(_date);
        }
        // info
        if (reader.PeekTag(TimePatternCodec.TagNumber))
        {
            //var _time = Asdu.Decode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref reader);
            var _time = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromTime(_time);
        }
        // info
        if (reader.PeekTag(ObjectIdentifierCodec.TagNumber))
        {
            //var _objectidentifier = Asdu.Decode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
            var _objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromObjectidentifier(_objectidentifier);
        }

        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _noValue = Asdu.DecodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromNoValue(_noValue);
            case 1:
                var _constructedValue = Asdu.DecodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromConstructedValue(_constructedValue);
            case 2:
                var _datetime = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDatetime(_datetime);
            case 3:
                var _lightingCommand = Asdu.DecodeConstructed<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromLightingCommand(_lightingCommand);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.TimerStateChangeValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Boolean:
                //Asdu.Encode<BooleanCodec, bool>(ref writer, value.Boolean);
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Integer:
                //Asdu.Encode<IntegerCodec, int>(ref writer, value.Integer);
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Real:
                //Asdu.Encode<RealCodec, float>(ref writer, value.Real);
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Double:
                //Asdu.Encode<DoubleCodec, double>(ref writer, value.Double);
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Octetstring:
                //Asdu.Encode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.Octetstring);
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Characterstring:
                //Asdu.Encode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.Characterstring);
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Bitstring:
                //Asdu.Encode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, value.Bitstring);
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Enumerated:
                //Asdu.Encode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref writer, value.Enumerated);
                Enumerated32Codec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Date:
                //Asdu.Encode<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref writer, value.Date);
                DatePatternCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Time:
                //Asdu.Encode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref writer, value.Time);
                TimePatternCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Objectidentifier:
                //Asdu.Encode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.Objectidentifier);
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.NoValue:
                Asdu.EncodePrimitive<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, 0, value.NoValue);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.ConstructedValue:
                Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, 1, value.ConstructedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Datetime:
                Asdu.EncodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 2, value.Datetime);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.LightingCommand:
                Asdu.EncodeConstructed<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(ref writer, 3, value.LightingCommand);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Boolean:
                return Asdu.GetEncodedLength<BooleanCodec, bool>(value.Boolean);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Integer:
                return Asdu.GetEncodedLength<IntegerCodec, int>(value.Integer);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Real:
                return Asdu.GetEncodedLength<RealCodec, float>(value.Real);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Double:
                return Asdu.GetEncodedLength<DoubleCodec, double>(value.Double);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Octetstring:
                return Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.Octetstring);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Characterstring:
                return Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.Characterstring);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Bitstring:
                return Asdu.GetEncodedLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(value.Bitstring);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Enumerated:
                return Asdu.GetEncodedLength<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(value.Enumerated);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Date:
                return Asdu.GetEncodedLength<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(value.Date);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Time:
                return Asdu.GetEncodedLength<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(value.Time);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Objectidentifier:
                return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.Objectidentifier);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.NoValue:
                return Asdu.GetPrimitiveLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(0, value.NoValue);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.ConstructedValue:
                return Asdu.GetPrimitiveLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(1, value.ConstructedValue);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Datetime:
                return Asdu.GetConstructedLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(2, value.Datetime);
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.LightingCommand:
                return Asdu.GetConstructedLength<LightingCommandCodec, global::Baclib.Bacnet.Types.Application.LightingCommand>(3, value.LightingCommand);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}