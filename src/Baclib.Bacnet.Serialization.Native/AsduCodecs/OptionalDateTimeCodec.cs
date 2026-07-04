// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalDateTimeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalDateTime>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalDateTime>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDateTime Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDateTime.FromNull(@null);
        }

        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 1:
                var @datetime = DateTimeCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.OptionalDateTime.FromDatetime(@datetime);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDateTime Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalDateTimeCodec, global::Baclib.Bacnet.Types.Application.OptionalDateTime>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalDateTime value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalDateTime.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalDateTime.Option.Datetime:
                DateTimeCodec.Encode(ref writer, 1, value.Datetime);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalDateTime value)
        => AsduConstructed.Encode<OptionalDateTimeCodec, global::Baclib.Bacnet.Types.Application.OptionalDateTime>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDateTime value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalDateTime.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalDateTime.Option.Datetime
                => DateTimeCodec.GetEncodedLength(value.Datetime, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDateTime value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalDateTimeCodec, global::Baclib.Bacnet.Types.Application.OptionalDateTime>(tagNumber, value);
}
