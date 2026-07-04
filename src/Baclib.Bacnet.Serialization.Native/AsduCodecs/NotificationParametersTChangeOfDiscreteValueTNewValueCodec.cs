// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NotificationParametersTChangeOfDiscreteValueTNewValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
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

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromBoolean(@boolean);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromInteger(@integer);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromEnumerated(@enumerated);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @characterstring = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromCharacterstring(@characterstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @octetstring = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromOctetstring(@octetstring);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromDate(@date);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @time = TimeCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromTime(@time);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @objectidentifier = ObjectIdentifierCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromObjectidentifier(@objectidentifier);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @datetime = DateTimeCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.FromDatetime(@datetime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Boolean:
                BooleanCodec.Encode(ref writer, value.Boolean);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Enumerated:
                EnumeratedCodec.Encode(ref writer, value.Enumerated);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Characterstring:
                CharacterStringCodec.Encode(ref writer, value.Characterstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Octetstring:
                OctetStringCodec.Encode(ref writer, value.Octetstring);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Date:
                DateCodec.Encode(ref writer, value.Date);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Time:
                TimeCodec.Encode(ref writer, value.Time);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Objectidentifier:
                ObjectIdentifierCodec.Encode(ref writer, value.Objectidentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Datetime:
                DateTimeCodec.Encode(ref writer, 0, value.Datetime);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue value)
        => AsduConstructed.Encode<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Boolean
                => BooleanCodec.GetEncodedLength(value.Boolean),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Enumerated
                => EnumeratedCodec.GetEncodedLength(value.Enumerated),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Characterstring
                => CharacterStringCodec.GetEncodedLength(value.Characterstring),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Octetstring
                => OctetStringCodec.GetEncodedLength(value.Octetstring),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Date
                => DateCodec.GetEncodedLength(value.Date),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Time
                => TimeCodec.GetEncodedLength(value.Time),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Objectidentifier
                => ObjectIdentifierCodec.GetEncodedLength(value.Objectidentifier),
            global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue.Option.Datetime
                => DateTimeCodec.GetEncodedLength(value.Datetime, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<NotificationParametersTChangeOfDiscreteValueTNewValueCodec, global::Baclib.Bacnet.Types.Application.NotificationParameters.TChangeOfDiscreteValue.TNewValue>(tagNumber, value);
}
