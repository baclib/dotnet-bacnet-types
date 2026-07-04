// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultExtendedTParametersItemCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem>
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

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromReal(@real);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromBoolean(@boolean);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromInteger(@integer);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromDouble(@double);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromOctetstring(@octetstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromCharacterstring(@characterstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromBitstring(@bitstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromEnumerated(@enumerated);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromDate(@date);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @time = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromTime(@time);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @reference = DeviceObjectPropertyReferenceCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.FromReference(@reference);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Date:
                DateCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Time:
                TimeCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Reference:
                DeviceObjectPropertyReferenceCodec.Encode(ref writer, 0, value.Reference);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem value)
        => AsduConstructed.Encode<FaultParameterTFaultExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Date
                => DateCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Time
                => TimeCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem.Option.Reference
                => DeviceObjectPropertyReferenceCodec.GetEncodedLength(value.Reference, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem value, byte tagNumber)
        => AsduElement.GetEncodedLength<FaultParameterTFaultExtendedTParametersItemCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultExtended.TParametersItem>(tagNumber, value);
}
