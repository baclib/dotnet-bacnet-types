// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalIntegerCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalInteger>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalInteger>
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
            ApplicationTagNumber.Signed => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalInteger Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalInteger.FromNull(@null);
        }
        if (IntegerCodec.Matches(ref reader))
        {
            var @integer = IntegerCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalInteger.FromInteger(@integer);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalInteger Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalIntegerCodec, global::Baclib.Bacnet.Types.Application.OptionalInteger>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalInteger value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalInteger.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalInteger.Option.Integer:
                IntegerCodec.Encode(ref writer, value.Integer);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalInteger value)
        => AsduConstructed.Encode<OptionalIntegerCodec, global::Baclib.Bacnet.Types.Application.OptionalInteger>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalInteger value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalInteger.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalInteger.Option.Integer
                => IntegerCodec.GetEncodedLength(value.Integer),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalInteger value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalIntegerCodec, global::Baclib.Bacnet.Types.Application.OptionalInteger>(tagNumber, value);
}
