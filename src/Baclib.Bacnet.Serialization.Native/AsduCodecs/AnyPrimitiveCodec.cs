// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AnyPrimitiveCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AnyPrimitive>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AnyPrimitive>
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
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.AnyPrimitive Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _null = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromNull(_null);
        }
        // info
        if (reader.PeekTag(BooleanCodec.TagNumber))
        {
            //var _boolean = Asdu.Decode<BooleanCodec, bool>(ref reader);
            var _boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBoolean(_boolean);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromUnsigned(_unsigned);
        }
        // info
        if (reader.PeekTag(IntegerCodec.TagNumber))
        {
            //var _integer = Asdu.Decode<IntegerCodec, int>(ref reader);
            var _integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromInteger(_integer);
        }
        // info
        if (reader.PeekTag(RealCodec.TagNumber))
        {
            //var _real = Asdu.Decode<RealCodec, float>(ref reader);
            var _real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromReal(_real);
        }
        // info
        if (reader.PeekTag(DoubleCodec.TagNumber))
        {
            //var _double = Asdu.Decode<DoubleCodec, double>(ref reader);
            var _double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDouble(_double);
        }
        // info
        if (reader.PeekTag(OctetStringCodec.TagNumber))
        {
            //var _octetString = Asdu.Decode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
            var _octetString = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromOctetString(_octetString);
        }
        // info
        if (reader.PeekTag(CharacterStringCodec.TagNumber))
        {
            //var _characterString = Asdu.Decode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
            var _characterString = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromCharacterString(_characterString);
        }
        // info
        if (reader.PeekTag(BitStringCodec.TagNumber))
        {
            //var _bitString = Asdu.Decode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref reader);
            var _bitString = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBitString(_bitString);
        }
        // info
        if (reader.PeekTag(Enumerated32Codec.TagNumber))
        {
            //var _enumerated = Asdu.Decode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref reader);
            var _enumerated = Enumerated32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromEnumerated(_enumerated);
        }
        // info
        if (reader.PeekTag(DatePatternCodec.TagNumber))
        {
            //var _datePattern = Asdu.Decode<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref reader);
            var _datePattern = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDatePattern(_datePattern);
        }
        // info
        if (reader.PeekTag(TimePatternCodec.TagNumber))
        {
            //var _timePattern = Asdu.Decode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref reader);
            var _timePattern = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromTimePattern(_timePattern);
        }
        // info
        if (reader.PeekTag(ObjectIdentifierCodec.TagNumber))
        {
            //var _objectIdentifier = Asdu.Decode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
            var _objectIdentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromObjectIdentifier(_objectIdentifier);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AnyPrimitive Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Null:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.Null);
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Boolean:
                //Asdu.Encode<BooleanCodec, bool>(ref writer, value.Boolean);
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Integer:
                //Asdu.Encode<IntegerCodec, int>(ref writer, value.Integer);
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Real:
                //Asdu.Encode<RealCodec, float>(ref writer, value.Real);
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Double:
                //Asdu.Encode<DoubleCodec, double>(ref writer, value.Double);
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.OctetString:
                //Asdu.Encode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.OctetString);
                OctetStringCodec.Encode(ref writer, value.OctetString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.CharacterString:
                //Asdu.Encode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.CharacterString);
                CharacterStringCodec.Encode(ref writer, value.CharacterString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.BitString:
                //Asdu.Encode<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(ref writer, value.BitString);
                BitStringCodec.Encode(ref writer, value.BitString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Enumerated:
                //Asdu.Encode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref writer, value.Enumerated);
                Enumerated32Codec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.DatePattern:
                //Asdu.Encode<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(ref writer, value.DatePattern);
                DatePatternCodec.Encode(ref writer, value.DatePattern);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.TimePattern:
                //Asdu.Encode<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(ref writer, value.TimePattern);
                TimePatternCodec.Encode(ref writer, value.TimePattern);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.ObjectIdentifier:
                //Asdu.Encode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.ObjectIdentifier);
                ObjectIdentifierCodec.Encode(ref writer, value.ObjectIdentifier);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Null:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.Null);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Boolean:
                return Asdu.GetEncodedLength<BooleanCodec, bool>(value.Boolean);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Integer:
                return Asdu.GetEncodedLength<IntegerCodec, int>(value.Integer);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Real:
                return Asdu.GetEncodedLength<RealCodec, float>(value.Real);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Double:
                return Asdu.GetEncodedLength<DoubleCodec, double>(value.Double);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.OctetString:
                return Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.OctetString);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.CharacterString:
                return Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.CharacterString);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.BitString:
                return Asdu.GetEncodedLength<BitStringCodec, global::Baclib.Bacnet.Types.Application.BitString>(value.BitString);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Enumerated:
                return Asdu.GetEncodedLength<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(value.Enumerated);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.DatePattern:
                return Asdu.GetEncodedLength<DatePatternCodec, global::Baclib.Bacnet.Types.Application.DatePattern>(value.DatePattern);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.TimePattern:
                return Asdu.GetEncodedLength<TimePatternCodec, global::Baclib.Bacnet.Types.Application.TimePattern>(value.TimePattern);
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.ObjectIdentifier:
                return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.ObjectIdentifier);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AnyPrimitive value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}