// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTChangeOfDiscreteValueTNewValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Boolean:
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Signed:
            case ApplicationTagNumber.Enumerated:
            case ApplicationTagNumber.CharacterString:
            case ApplicationTagNumber.OctetString:
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
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(BooleanCodec.TagNumber))
        {
            //var _boolean = Asdu.Decode<BooleanCodec, bool>(ref reader);
            var _boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromBoolean(_boolean);
        }
        // info
        if (reader.PeekTag(UnsignedCodec.TagNumber))
        {
            //var _unsigned = Asdu.Decode<UnsignedCodec, uint>(ref reader);
            var _unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromUnsigned(_unsigned);
        }
        // info
        if (reader.PeekTag(IntegerCodec.TagNumber))
        {
            //var _integer = Asdu.Decode<IntegerCodec, int>(ref reader);
            var _integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromInteger(_integer);
        }
        // info
        if (reader.PeekTag(Enumerated32Codec.TagNumber))
        {
            //var _enumerated = Asdu.Decode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref reader);
            var _enumerated = Enumerated32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromEnumerated(_enumerated);
        }
        // info
        if (reader.PeekTag(CharacterStringCodec.TagNumber))
        {
            //var _characterstring = Asdu.Decode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
            var _characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromCharacterstring(_characterstring);
        }
        // info
        if (reader.PeekTag(OctetStringCodec.TagNumber))
        {
            //var _octetstring = Asdu.Decode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref reader);
            var _octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromOctetstring(_octetstring);
        }
        // info
        if (reader.PeekTag(DateCodec.TagNumber))
        {
            //var _datepattern = Asdu.Decode<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref reader);
            var _datepattern = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromDatepattern(_datepattern);
        }
        // info
        if (reader.PeekTag(TimeCodec.TagNumber))
        {
            //var _timepattern = Asdu.Decode<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref reader);
            var _timepattern = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromTimepattern(_timepattern);
        }
        // info
        if (reader.PeekTag(ObjectIdentifierCodec.TagNumber))
        {
            //var _objectidentifier = Asdu.Decode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref reader);
            var _objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromObjectidentifier(_objectidentifier);
        }

        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _datetime = Asdu.DecodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.FromDatetime(_datetime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Boolean:
                //Asdu.Encode<BooleanCodec, bool>(ref writer, value.Boolean);
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Unsigned:
                //Asdu.Encode<UnsignedCodec, uint>(ref writer, value.Unsigned);
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Integer:
                //Asdu.Encode<IntegerCodec, int>(ref writer, value.Integer);
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Enumerated:
                //Asdu.Encode<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(ref writer, value.Enumerated);
                Enumerated32Codec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Characterstring:
                //Asdu.Encode<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.Characterstring);
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Octetstring:
                //Asdu.Encode<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(ref writer, value.Octetstring);
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Datepattern:
                //Asdu.Encode<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(ref writer, value.Datepattern);
                DateCodec.Encode(ref writer, value.Datepattern);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Timepattern:
                //Asdu.Encode<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(ref writer, value.Timepattern);
                TimeCodec.Encode(ref writer, value.Timepattern);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Objectidentifier:
                //Asdu.Encode<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(ref writer, value.Objectidentifier);
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Datetime:
                Asdu.EncodeConstructed<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(ref writer, 0, value.Datetime);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Boolean:
                return Asdu.GetEncodedLength<BooleanCodec, bool>(value.Boolean);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Unsigned:
                return Asdu.GetEncodedLength<UnsignedCodec, uint>(value.Unsigned);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Integer:
                return Asdu.GetEncodedLength<IntegerCodec, int>(value.Integer);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Enumerated:
                return Asdu.GetEncodedLength<Enumerated32Codec, global::Baclib.Bacnet.Types.Application.Enumerated>(value.Enumerated);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Characterstring:
                return Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.Characterstring);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Octetstring:
                return Asdu.GetEncodedLength<OctetStringCodec, global::Baclib.Bacnet.Types.Application.OctetString>(value.Octetstring);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Datepattern:
                return Asdu.GetEncodedLength<DateCodec, global::Baclib.Bacnet.Types.Application.Date>(value.Datepattern);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Timepattern:
                return Asdu.GetEncodedLength<TimeCodec, global::Baclib.Bacnet.Types.Application.Time>(value.Timepattern);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Objectidentifier:
                return Asdu.GetEncodedLength<ObjectIdentifierCodec, global::Baclib.Bacnet.Types.Application.ObjectIdentifier>(value.Objectidentifier);
            case global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue.Option.Datetime:
                return Asdu.GetConstructedLength<DateTimeCodec, global::Baclib.Bacnet.Types.Application.DateTime>(0, value.Datetime);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TChangeOfDiscreteValue.TNewValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}