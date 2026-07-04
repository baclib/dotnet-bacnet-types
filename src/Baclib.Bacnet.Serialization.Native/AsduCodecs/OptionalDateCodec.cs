// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalDateCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalDate>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalDate>
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
            ApplicationTagNumber.DatePattern => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDate Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDate.FromNull(@null);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @date = DateCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDate.FromDate(@date);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDate Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalDateCodec, global::Baclib.Bacnet.Types.Application.OptionalDate>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalDate value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalDate.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalDate.Option.Date:
                DateCodec.Encode(ref writer, value.Date);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalDate value)
        => AsduConstructed.Encode<OptionalDateCodec, global::Baclib.Bacnet.Types.Application.OptionalDate>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDate value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalDate.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalDate.Option.Date
                => DateCodec.GetEncodedLength(value.Date),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDate value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalDateCodec, global::Baclib.Bacnet.Types.Application.OptionalDate>(tagNumber, value);
}
