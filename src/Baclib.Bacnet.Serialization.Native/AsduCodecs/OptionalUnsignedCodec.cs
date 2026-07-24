// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalUnsignedCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalUnsigned>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalUnsigned>
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
            ApplicationTagNumber.Unsigned => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalUnsigned Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalUnsigned.FromNull(@null);
        }
        if (UnsignedCodec.Matches(ref reader))
        {
            var @unsigned = UnsignedCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalUnsigned.FromUnsigned(@unsigned);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalUnsigned Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalUnsignedCodec, global::Baclib.Bacnet.Types.Application.OptionalUnsigned>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Unsigned:
                UnsignedCodec.Encode(ref writer, value.Unsigned);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
        => AsduConstructed.Encode<OptionalUnsignedCodec, global::Baclib.Bacnet.Types.Application.OptionalUnsigned>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalUnsigned.Option.Unsigned
                => UnsignedCodec.GetEncodedLength(value.Unsigned),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalUnsigned value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalUnsignedCodec, global::Baclib.Bacnet.Types.Application.OptionalUnsigned>(tagNumber, value);
}
