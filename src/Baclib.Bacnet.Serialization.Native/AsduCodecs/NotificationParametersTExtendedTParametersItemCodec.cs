// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTExtendedTParametersItemCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem>
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

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromReal(@real);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromBoolean(@boolean);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromInteger(@integer);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromDouble(@double);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromOctetstring(@octetstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromCharacterstring(@characterstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromBitstring(@bitstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromEnumerated(@enumerated);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromDate(@date);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @time = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromTime(@time);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @propertyValue = DeviceObjectPropertyValueCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.FromPropertyValue(@propertyValue);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Date:
                DateCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Time:
                TimeCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.PropertyValue:
                DeviceObjectPropertyValueCodec.Encode(ref writer, 0, value.PropertyValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem value)
        => AsduConstructed.Encode<NotificationParametersTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Date
                => DateCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Time
                => TimeCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem.Option.PropertyValue
                => DeviceObjectPropertyValueCodec.GetEncodedLength(value.PropertyValue, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem value, byte tagNumber)
        => AsduElement.GetEncodedLength<NotificationParametersTExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TExtended.TParametersItem>(tagNumber, value);
}
