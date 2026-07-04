// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class TimerStateChangeValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>
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
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 or
            3 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.TimerStateChangeValue Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromBoolean(@boolean);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromInteger(@integer);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromReal(@real);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDouble(@double);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromOctetstring(@octetstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromCharacterstring(@characterstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromBitstring(@bitstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromEnumerated(@enumerated);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @date = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDate(@date);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @time = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromTime(@time);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @noValue = NullCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromNoValue(@noValue);
            case 1:
                var @constructedValue = AnyCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromConstructedValue(@constructedValue);
            case 2:
                var @datetime = DateTimeCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromDatetime(@datetime);
            case 3:
                var @lightingCommand = LightingCommandCodec.Decode(ref reader, 3);
                return global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.FromLightingCommand(@lightingCommand);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.TimerStateChangeValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<TimerStateChangeValueCodec, global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Date:
                DatePatternCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Time:
                TimePatternCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.NoValue:
                NullCodec.Encode(ref writer, 0, value.NoValue);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.ConstructedValue:
                AnyCodec.Encode(ref writer, 1, value.ConstructedValue);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Datetime:
                DateTimeCodec.Encode(ref writer, 2, value.Datetime);
                return;
            case global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.LightingCommand:
                LightingCommandCodec.Encode(ref writer, 3, value.LightingCommand);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
        => AsduConstructed.Encode<TimerStateChangeValueCodec, global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Date
                => DatePatternCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Time
                => TimePatternCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.NoValue
                => NullCodec.GetEncodedLength(value.NoValue, 0),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.ConstructedValue
                => AnyCodec.GetEncodedLength(value.ConstructedValue, 1),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.Datetime
                => DateTimeCodec.GetEncodedLength(value.Datetime, 2),
            global::Baclib.Bacnet.Types.Application.TimerStateChangeValue.Option.LightingCommand
                => LightingCommandCodec.GetEncodedLength(value.LightingCommand, 3),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.TimerStateChangeValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<TimerStateChangeValueCodec, global::Baclib.Bacnet.Types.Application.TimerStateChangeValue>(tagNumber, value);
}
