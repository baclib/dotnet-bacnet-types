// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ChannelValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ChannelValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ChannelValue>
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
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ChannelValue Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromNull(@null);
        }
        if (RealCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromReal(@real);
        }
        if (EnumeratedCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromEnumerated(@enumerated);
        }
        if (UnsignedCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromUnsigned(@unsigned);
        }
        if (BooleanCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromBoolean(@boolean);
        }
        if (IntegerCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromInteger(@integer);
        }
        if (DoubleCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromDouble(@double);
        }
        if (TimeCodec.Matches(ref reader))
        {
            var @time = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromTime(@time);
        }
        if (CharacterStringCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromCharacterstring(@characterstring);
        }
        if (OctetStringCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromOctetstring(@octetstring);
        }
        if (BitStringCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromBitstring(@bitstring);
        }
        if (DateCodec.Matches(ref reader))
        {
            var @date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromDate(@date);
        }
        if (ObjectIdentifierCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ChannelValue.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @lightingCommand = LightingCommandCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromLightingCommand(@lightingCommand);
            case 1:
                var @xycolor = XyColorCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromXycolor(@xycolor);
            case 2:
                var @colorCommand = ColorCommandCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ChannelValue.FromColorCommand(@colorCommand);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ChannelValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ChannelValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Time:
                TimeCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Date:
                DateCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.LightingCommand:
                LightingCommandCodec.Encode(ref writer, 0, value.LightingCommand);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Xycolor:
                XyColorCodec.Encode(ref writer, 1, value.Xycolor);
                return;
            case global::Baclib.Bacnet.Types.Application.ChannelValue.Option.ColorCommand:
                ColorCommandCodec.Encode(ref writer, 2, value.ColorCommand);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ChannelValue value)
        => AsduConstructed.Encode<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ChannelValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Time
                => TimeCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Date
                => DateCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.LightingCommand
                => LightingCommandCodec.GetEncodedLength(value.LightingCommand, 0),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.Xycolor
                => XyColorCodec.GetEncodedLength(value.Xycolor, 1),
            global::Baclib.Bacnet.Types.Application.ChannelValue.Option.ColorCommand
                => ColorCommandCodec.GetEncodedLength(value.ColorCommand, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ChannelValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<ChannelValueCodec, global::Baclib.Bacnet.Types.Application.ChannelValue>(tagNumber, value);
}
