// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalBinaryPvCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>
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
            ApplicationTagNumber.Enumerated => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryPv Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.FromNull(@null);
        }
        if (BinaryPvCodec.Matches(ref reader))
        {
            var @binaryPv = BinaryPvCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.FromBinaryPv(@binaryPv);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryPv Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalBinaryPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.BinaryPv:
                BinaryPvCodec.Encode(ref writer, value.BinaryPv);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
        => AsduConstructed.Encode<OptionalBinaryPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalBinaryPv.Option.BinaryPv
                => BinaryPvCodec.GetEncodedLength(value.BinaryPv),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryPv value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalBinaryPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryPv>(tagNumber, value);
}
