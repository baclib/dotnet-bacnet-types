// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalBitStringCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalBitString>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalBitString>
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

    public static global::Baclib.Bacnet.Types.Application.OptionalBitString Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBitString.FromNull(@null);
        }
        if (BitStringCodec.Matches(ref reader))
        {
            var @bitstring = BitStringCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBitString.FromBitstring(@bitstring);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalBitString Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalBitStringCodec, global::Baclib.Bacnet.Types.Application.OptionalBitString>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalBitString value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalBitString.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalBitString.Option.Bitstring:
                BitStringCodec.Encode(ref writer, value.Bitstring);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalBitString value)
        => AsduConstructed.Encode<OptionalBitStringCodec, global::Baclib.Bacnet.Types.Application.OptionalBitString>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBitString value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalBitString.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalBitString.Option.Bitstring
                => BitStringCodec.GetEncodedLength(value.Bitstring),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBitString value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalBitStringCodec, global::Baclib.Bacnet.Types.Application.OptionalBitString>(tagNumber, value);
}
