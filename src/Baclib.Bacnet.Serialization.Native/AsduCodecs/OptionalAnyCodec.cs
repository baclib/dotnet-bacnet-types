// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

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
