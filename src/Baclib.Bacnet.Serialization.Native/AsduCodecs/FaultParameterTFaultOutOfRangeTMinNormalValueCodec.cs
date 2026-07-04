// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultOutOfRangeTMinNormalValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Real or
            ApplicationTagNumber.Unsigned or
            ApplicationTagNumber.Double or
            ApplicationTagNumber.Signed => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromReal(@real);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromUnsigned(@unsigned);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromDouble(@double);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.FromInteger(@integer);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
        => AsduConstructed.Encode<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<FaultParameterTFaultOutOfRangeTMinNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMinNormalValue>(tagNumber, value);
}
