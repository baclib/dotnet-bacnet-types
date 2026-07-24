// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Codec for the BACnet <c>ABSTRACT-SYNTAX.&amp;Type</c> ("Any").
/// </summary>
/// <remarks>
/// An <see cref="T.Any"/> is treated primarily as raw ASDU bytes: decoding captures one or more
/// complete elements verbatim, and encoding writes raw bytes back unchanged. When an
/// <see cref="T.Any"/> instead carries a materialized value, that value must be an
/// <see cref="T.AnyPrimitive"/>, which is encoded via <see cref="AnyPrimitiveCodec"/>.
/// </remarks>
public partial class AnyCodec : IAsduElementCodec<T.Any>
{
    /// <inheritdoc/>
    public static bool Matches(ref AsduReader reader) => !reader.End;

    /// <summary>
    /// Decodes a single complete element at the current position, capturing it as raw bytes.
    /// </summary>
    public static T.Any Decode(ref AsduReader reader)
        => T.Any.FromEncoded(reader.ReadElement());

    /// <summary>
    /// Decodes a context-tag-enclosed value, capturing its entire raw content as bytes.
    /// </summary>
    public static T.Any Decode(ref AsduReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var content = reader.ReadRawUntilClosingTag(tagNumber);
        var any = T.Any.FromEncoded(content);
        reader.ReadClosingTag(tagNumber);
        return any;
    }

    /// <summary>
    /// Encodes an <see cref="T.Any"/>, writing raw bytes verbatim or delegating a materialized
    /// <see cref="T.AnyPrimitive"/> to <see cref="AnyPrimitiveCodec"/>.
    /// </summary>
    public static void Encode(ref AsduWriter writer, in T.Any value)
        => Encode(ref writer, value, registry: null);

    /// <summary>
    /// Encodes an <see cref="T.Any"/>, using static dispatch first and an optional runtime registry as fallback.
    /// </summary>
    /// <param name="writer">The writer receiving encoded bytes.</param>
    /// <param name="value">The Any value to encode.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static void Encode(ref AsduWriter writer, in T.Any value, AnyCodecRegistry? registry)
    {
        if (value.IsEncoded)
        {
            writer.WriteAny(value.EncodedData);
            return;
        }

        if (Codecs.TryEncode(ref writer, value.Value))
        {
            return;
        }

        if (registry is not null && registry.TryGetByType(value.ValueType, out var codec))
        {
            codec.Encode(ref writer, value.Value);
            return;
        }

        throw new NotSupportedException($"The type '{value.ValueType}' has no registered codec.");
    }

    /// <summary>
    /// Encodes an <see cref="T.Any"/> enclosed in the specified context tag.
    /// </summary>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
        => Encode(ref writer, tagNumber, value, registry: null);

    /// <summary>
    /// Encodes an <see cref="T.Any"/> enclosed in the specified context tag.
    /// </summary>
    /// <param name="writer">The writer receiving encoded bytes.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The Any value to encode.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value, AnyCodecRegistry? registry)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value, registry);
        writer.WriteClosingTag(tagNumber);
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value)
        => GetEncodedLength(value, registry: null);

    /// <summary>
    /// Gets the encoded length of an <see cref="T.Any"/>, using static dispatch first and an optional runtime registry as fallback.
    /// </summary>
    /// <param name="value">The Any value to size.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static int GetEncodedLength(in T.Any value, AnyCodecRegistry? registry)
    {
        if (value.IsEncoded)
        {
            return value.EncodedData.Length;
        }

        if (Codecs.TryGetEncodedLength(value.Value, out var encodedLength))
        {
            return encodedLength;
        }

        if (registry is not null && registry.TryGetByType(value.ValueType, out var codec))
        {
            return codec.GetEncodedLength(value.Value);
        }

        throw new NotSupportedException($"The type '{value.ValueType}' has no registered codec.");
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value, byte tagNumber)
        => GetEncodedLength(value, tagNumber, registry: null);

    /// <summary>
    /// Gets the encoded length of a context-tagged <see cref="T.Any"/> value.
    /// </summary>
    /// <param name="value">The Any value to size.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static int GetEncodedLength(in T.Any value, byte tagNumber, AnyCodecRegistry? registry)
        => 2 * AsduLength.FromTagNumber(tagNumber) + GetEncodedLength(value, registry);

    /// <summary>
    /// Generated static dispatch for all known primitive <c>Any</c> value types.
    /// </summary>
    internal static class Codecs
    {
        public static bool TryEncode(ref AsduWriter writer, object value)
        {
            switch (value)
            {
                case T.AnyPrimitive anyPrimitive:
                    AnyPrimitiveCodec.Encode(ref writer, anyPrimitive);
                    return true;
                case bool @bool:
                    BooleanCodec.Encode(ref writer, @bool);
                    return true;
                case byte @byte:
                    Unsigned8Codec.Encode(ref writer, @byte);
                    return true;
                case ushort @ushort:
                    Unsigned16Codec.Encode(ref writer, @ushort);
                    return true;
                case uint @uint:
                    UnsignedCodec.Encode(ref writer, @uint);
                    return true;
                case ulong @ulong:
                    Unsigned64Codec.Encode(ref writer, @ulong);
                    return true;
                case sbyte @sbyte:
                    Integer8Codec.Encode(ref writer, @sbyte);
                    return true;
                case short @short:
                    Integer16Codec.Encode(ref writer, @short);
                    return true;
                case int @int:
                    IntegerCodec.Encode(ref writer, @int);
                    return true;
                case long @long:
                    Integer64Codec.Encode(ref writer, @long);
                    return true;
                case float @float:
                    RealCodec.Encode(ref writer, @float);
                    return true;
                case double @double:
                    DoubleCodec.Encode(ref writer, @double);
                    return true;
                case BitString bitString:
                    BitStringCodec.Encode(ref writer, bitString);
                    return true;
                case CharacterString characterString:
                    CharacterStringCodec.Encode(ref writer, characterString);
                    return true;
                case DatePattern datePattern:
                    DatePatternCodec.Encode(ref writer, datePattern);
                    return true;
                case Enumerated enumerated:
                    EnumeratedCodec.Encode(ref writer, enumerated);
                    return true;
                case ObjectIdentifier objectIdentifier:
                    ObjectIdentifierCodec.Encode(ref writer, objectIdentifier);
                    return true;
                case OctetString octetString:
                    OctetStringCodec.Encode(ref writer, octetString);
                    return true;
                case TimePattern timePattern:
                    TimePatternCodec.Encode(ref writer, timePattern);
                    return true;
                default:
                    return false;
            }
        }

        public static bool TryGetEncodedLength(object value, out int encodedLength)
        {
            switch (value)
            {
                case T.AnyPrimitive anyPrimitive:
                    encodedLength = AnyPrimitiveCodec.GetEncodedLength(anyPrimitive);
                    return true;
                case bool @bool:
                    encodedLength = BooleanCodec.GetEncodedLength(@bool);
                    return true;
                case byte @byte:
                    encodedLength = Unsigned8Codec.GetEncodedLength(@byte);
                    return true;
                case ushort @ushort:
                    encodedLength = Unsigned16Codec.GetEncodedLength(@ushort);
                    return true;
                case uint @uint:
                    encodedLength = UnsignedCodec.GetEncodedLength(@uint);
                    return true;
                case ulong @ulong:
                    encodedLength = Unsigned64Codec.GetEncodedLength(@ulong);
                    return true;
                case sbyte @sbyte:
                    encodedLength = Integer8Codec.GetEncodedLength(@sbyte);
                    return true;
                case short @short:
                    encodedLength = Integer16Codec.GetEncodedLength(@short);
                    return true;
                case int @int:
                    encodedLength = IntegerCodec.GetEncodedLength(@int);
                    return true;
                case long @long:
                    encodedLength = Integer64Codec.GetEncodedLength(@long);
                    return true;
                case float @float:
                    encodedLength = RealCodec.GetEncodedLength(@float);
                    return true;
                case double @double:
                    encodedLength = DoubleCodec.GetEncodedLength(@double);
                    return true;
                case BitString bitString:
                    encodedLength = BitStringCodec.GetEncodedLength(bitString);
                    return true;
                case CharacterString characterString:
                    encodedLength = CharacterStringCodec.GetEncodedLength(characterString);
                    return true;
                case DatePattern datePattern:
                    encodedLength = DatePatternCodec.GetEncodedLength(datePattern);
                    return true;
                case Enumerated enumerated:
                    encodedLength = EnumeratedCodec.GetEncodedLength(enumerated);
                    return true;
                case ObjectIdentifier objectIdentifier:
                    encodedLength = ObjectIdentifierCodec.GetEncodedLength(objectIdentifier);
                    return true;
                case OctetString octetString:
                    encodedLength = OctetStringCodec.GetEncodedLength(octetString);
                    return true;
                case TimePattern timePattern:
                    encodedLength = TimePatternCodec.GetEncodedLength(timePattern);
                    return true;
                default:
                    encodedLength = 0;
                    return false;
            }
        }

        public static bool TryDecode(ref AsduReader reader, Type valueType, out object value)
        {
            ArgumentNullException.ThrowIfNull(valueType);

            if (valueType == typeof(T.AnyPrimitive))
            {
                value = AnyPrimitiveCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(bool))
            {
                value = BooleanCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(byte))
            {
                value = Unsigned8Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(ushort))
            {
                value = Unsigned16Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(uint))
            {
                value = UnsignedCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(ulong))
            {
                value = Unsigned64Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(sbyte))
            {
                value = Integer8Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(short))
            {
                value = Integer16Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(int))
            {
                value = IntegerCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(long))
            {
                value = Integer64Codec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(float))
            {
                value = RealCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(double))
            {
                value = DoubleCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(BitString))
            {
                value = BitStringCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(CharacterString))
            {
                value = CharacterStringCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(DatePattern))
            {
                value = DatePatternCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(Enumerated))
            {
                value = EnumeratedCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(ObjectIdentifier))
            {
                value = ObjectIdentifierCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(OctetString))
            {
                value = OctetStringCodec.Decode(ref reader);
                return true;
            }

            if (valueType == typeof(TimePattern))
            {
                value = TimePatternCodec.Decode(ref reader);
                return true;
            }

            value = default!;
            return false;
        }
    }
}

/// <summary>
/// Optional typed materialization helpers for <see cref="T.Any"/>.
/// </summary>
public static class AnyMaterializer
{
    /// <summary>
    /// Tries to materialize an <see cref="T.Any"/> as a specific value type.
    /// </summary>
    public static bool TryDecodeAs<TValue>(
        in T.Any any,
        out TValue value,
        AnyCodecRegistry? registry = null)
    {
        if (TryDecodeAs(any, typeof(TValue), out var boxed, registry) && boxed is TValue typed)
        {
            value = typed;
            return true;
        }

        value = default!;
        return false;
    }

    /// <summary>
    /// Tries to materialize an <see cref="T.Any"/> as a runtime-selected value type.
    /// </summary>
    public static bool TryDecodeAs(
        in T.Any any,
        Type valueType,
        out object? value,
        AnyCodecRegistry? registry = null)
    {
        ArgumentNullException.ThrowIfNull(valueType);

        if (!any.IsEncoded)
        {
            var materialized = any.Value;
            if (valueType.IsInstanceOfType(materialized))
            {
                value = materialized;
                return true;
            }

            value = null;
            return false;
        }

        if (TryDecodeStatic(any.EncodedData.Span, valueType, out value))
        {
            return true;
        }

        if (registry is not null && registry.TryGetByType(valueType, out var codec))
        {
            try
            {
                var reader = new AsduReader(any.EncodedData.Span);
                var decoded = codec.Decode(ref reader);
                if (!reader.End)
                {
                    value = null;
                    return false;
                }

                if (!valueType.IsInstanceOfType(decoded))
                {
                    value = null;
                    return false;
                }

                value = decoded;
                return true;
            }
            catch
            {
                value = null;
                return false;
            }
        }

        value = null;
        return false;
    }

    private static bool TryDecodeStatic(ReadOnlySpan<byte> encoded, Type valueType, out object? value)
    {
        try
        {
            var reader = new AsduReader(encoded);
            if (!AnyCodec.Codecs.TryDecode(ref reader, valueType, out var decoded) || !reader.End)
            {
                value = null;
                return false;
            }

            value = decoded;
            return true;
        }
        catch
        {
            value = null;
            return false;
        }
    }
}

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
        if (BooleanCodec.Matches(ref reader))
        {
            var @boolean = BooleanCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBoolean(@boolean);
        }
        if (UnsignedCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromUnsigned(@unsigned);
        }
        if (IntegerCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromInteger(@integer);
        }
        if (RealCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromReal(@real);
        }
        if (DoubleCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDouble(@double);
        }
        if (OctetStringCodec.Matches(ref reader))
        {
            var @octetString = OctetStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromOctetString(@octetString);
        }
        if (CharacterStringCodec.Matches(ref reader))
        {
            var @characterString = CharacterStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromCharacterString(@characterString);
        }
        if (BitStringCodec.Matches(ref reader))
        {
            var @bitString = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromBitString(@bitString);
        }
        if (EnumeratedCodec.Matches(ref reader))
        {
            var @enumerated = EnumeratedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromEnumerated(@enumerated);
        }
        if (DatePatternCodec.Matches(ref reader))
        {
            var @datePattern = DatePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromDatePattern(@datePattern);
        }
        if (TimePatternCodec.Matches(ref reader))
        {
            var @timePattern = TimePatternCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.AnyPrimitive.FromTimePattern(@timePattern);
        }
        if (ObjectIdentifierCodec.Matches(ref reader))
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

public sealed class OptionalAnyCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalAny>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalAny>
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

    public static global::Baclib.Bacnet.Types.Application.OptionalAny Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalAny.FromNull(@null);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @any = AnyCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.OptionalAny.FromAny(@any);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalAny Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalAnyCodec, global::Baclib.Bacnet.Types.Application.OptionalAny>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalAny value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalAny.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalAny.Option.Any:
                AnyCodec.Encode(ref writer, 0, value.Any);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalAny value)
        => AsduConstructed.Encode<OptionalAnyCodec, global::Baclib.Bacnet.Types.Application.OptionalAny>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalAny value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalAny.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalAny.Option.Any
                => AnyCodec.GetEncodedLength(value.Any, 0),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalAny value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalAnyCodec, global::Baclib.Bacnet.Types.Application.OptionalAny>(tagNumber, value);
}
