// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultOutOfRangeTMaxNormalValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>
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

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue Decode(ref AsduReader reader)
    {
        if (RealCodec.Matches(ref reader))
        {
            var @real = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.FromReal(@real);
        }
        if (UnsignedCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.FromUnsigned(@unsigned);
        }
        if (DoubleCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.FromDouble(@double);
        }
        if (IntegerCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.FromInteger(@integer);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Real:
                RealCodec.Encode(ref writer, value.Real);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            case global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue value)
        => AsduConstructed.Encode<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Real
                => RealCodec.GetEncodedLength(value.Real),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<FaultParameterTFaultOutOfRangeTMaxNormalValueCodec, global::Baclib.Bacnet.Types.Application.FaultParameter.TFaultOutOfRange.TMaxNormalValue>(tagNumber, value);
}
