// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class EventParameterTExtendedTParametersItemCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Null:
            case ApplicationTagNumber.Real:
            case ApplicationTagNumber.Unsigned:
            case ApplicationTagNumber.Boolean:
            case ApplicationTagNumber.Signed:
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
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromNull(@null);
        }
        if (RealCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromReal(@real);
        }
        if (UnsignedCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromUnsigned(@unsigned);
        }
        if (BooleanCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromBoolean(@boolean);
        }
        if (IntegerCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromInteger(@integer);
        }
        if (DoubleCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromDouble(@double);
        }
        if (OctetStringCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromOctetstring(@octetstring);
        }
        if (CharacterStringCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromCharacterstring(@characterstring);
        }
        if (BitStringCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromBitstring(@bitstring);
        }
        if (EnumeratedCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromEnumerated(@enumerated);
        }
        if (DatePatternCodec.Matches(ref reader))
        {
            var @date = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromDate(@date);
        }
        if (TimePatternCodec.Matches(ref reader))
        {
            var @time = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromTime(@time);
        }
        if (ObjectIdentifierCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @reference = DeviceObjectPropertyReferenceCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.FromReference(@reference);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<EventParameterTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Date:
                DatePatternCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Time:
                TimePatternCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Reference:
                DeviceObjectPropertyReferenceCodec.Encode(ref writer, 0, value.Reference);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem value)
        => AsduConstructed.Encode<EventParameterTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Date
                => DatePatternCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Time
                => TimePatternCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem.Option.Reference
                => DeviceObjectPropertyReferenceCodec.GetEncodedLength(value.Reference, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem value, byte tagNumber)
        => AsduElement.GetEncodedLength<EventParameterTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.EventParameter.TExtended.TParametersItem>(tagNumber, value);
}
