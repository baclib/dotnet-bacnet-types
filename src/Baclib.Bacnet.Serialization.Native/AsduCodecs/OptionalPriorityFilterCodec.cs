// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalPriorityFilterCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter>
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
            ApplicationTagNumber.BitString => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.FromNull(@null);
        }
        if (PriorityFilterCodec.Matches(ref reader))
        {
            var @filter = PriorityFilterCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.FromFilter(@filter);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.Option.Filter:
                PriorityFilterCodec.Encode(ref writer, value.Filter);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter value)
        => AsduConstructed.Encode<OptionalPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter.Option.Filter
                => PriorityFilterCodec.GetEncodedLength(value.Filter),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalPriorityFilterCodec, global::Baclib.Bacnet.Types.Application.OptionalPriorityFilter>(tagNumber, value);
}
