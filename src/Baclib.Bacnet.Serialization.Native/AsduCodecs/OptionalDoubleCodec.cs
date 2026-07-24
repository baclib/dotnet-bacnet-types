// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalDoubleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalDouble>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalDouble>
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
            ApplicationTagNumber.Double => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDouble Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDouble.FromNull(@null);
        }
        if (DoubleCodec.Matches(ref reader))
        {
            var @double = DoubleCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDouble.FromDouble(@double);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDouble Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalDoubleCodec, global::Baclib.Bacnet.Types.Application.OptionalDouble>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalDouble value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalDouble.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalDouble.Option.Double:
                DoubleCodec.Encode(ref writer, value.Double);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalDouble value)
        => AsduConstructed.Encode<OptionalDoubleCodec, global::Baclib.Bacnet.Types.Application.OptionalDouble>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDouble value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalDouble.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalDouble.Option.Double
                => DoubleCodec.GetEncodedLength(value.Double),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDouble value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalDoubleCodec, global::Baclib.Bacnet.Types.Application.OptionalDouble>(tagNumber, value);
}
