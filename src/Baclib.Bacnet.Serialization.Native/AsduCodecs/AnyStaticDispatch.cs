// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;
using Baclib.Bacnet.Serialization.Native.AsduCodecs;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Static fast-path dispatch for common <c>Any</c> value types.
/// </summary>
internal static class AnyStaticDispatch
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
