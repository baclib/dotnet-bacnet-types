// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AnyPrimitiveCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AnyPrimitive>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AnyPrimitive>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Null or
            ApplicationTagNumber.Boolean or
            ApplicationTagNumber.Unsigned or
            ApplicationTagNumber.Signed or
            ApplicationTagNumber.Real or
            ApplicationTagNumber.Double or
            ApplicationTagNumber.OctetString or
            ApplicationTagNumber.CharacterString or
            ApplicationTagNumber.BitString or
            ApplicationTagNumber.Enumerated or
            ApplicationTagNumber.DatePattern or
            ApplicationTagNumber.TimePattern or
            ApplicationTagNumber.ObjectIdentifier => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AnyPrimitive Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBoolean(@boolean);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromInteger(@integer);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromReal(@real);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDouble(@double);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetString = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromOctetString(@octetString);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterString = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromCharacterString(@characterString);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @bitString = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBitString(@bitString);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromEnumerated(@enumerated);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @datePattern = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDatePattern(@datePattern);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @timePattern = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromTimePattern(@timePattern);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @objectIdentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromObjectIdentifier(@objectIdentifier);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AnyPrimitive Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AnyPrimitiveCodec, global::Baclib.Bacnet.Types.Application.AnyPrimitive>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.OctetString:
                OctetStringCodec.Encode(ref writer, value.OctetString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.CharacterString:
                CharacterStringCodec.Encode(ref writer, value.CharacterString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.BitString:
                BitStringCodec.Encode(ref writer, value.BitString);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.DatePattern:
                DatePatternCodec.Encode(ref writer, value.DatePattern);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.TimePattern:
                TimePatternCodec.Encode(ref writer, value.TimePattern);
                return;
            case global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.ObjectIdentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.ObjectIdentifier);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
        => AsduConstructed.Encode<AnyPrimitiveCodec, global::Baclib.Bacnet.Types.Application.AnyPrimitive>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AnyPrimitive value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.OctetString
                => OctetStringCodec.GetEncodedLength(value.OctetString),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.CharacterString
                => CharacterStringCodec.GetEncodedLength(value.CharacterString),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.BitString
                => BitStringCodec.GetEncodedLength(value.BitString),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.DatePattern
                => DatePatternCodec.GetEncodedLength(value.DatePattern),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.TimePattern
                => TimePatternCodec.GetEncodedLength(value.TimePattern),
            global::Baclib.Bacnet.Types.Application.AnyPrimitive.Option.ObjectIdentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.ObjectIdentifier),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AnyPrimitive value, byte tagNumber)
        => AsduElement.GetEncodedLength<AnyPrimitiveCodec, global::Baclib.Bacnet.Types.Application.AnyPrimitive>(tagNumber, value);
}
