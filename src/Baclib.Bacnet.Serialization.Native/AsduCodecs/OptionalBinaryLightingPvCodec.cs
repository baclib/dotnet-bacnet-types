// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalBinaryLightingPvCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv>
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

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.FromNull(@null);
        }
        if (BinaryLightingPvCodec.Matches(ref reader))
        {
            var @binaryLightingPv = BinaryLightingPvCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.FromBinaryLightingPv(@binaryLightingPv);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalBinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.Option.BinaryLightingPv:
                BinaryLightingPvCodec.Encode(ref writer, value.BinaryLightingPv);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv value)
        => AsduConstructed.Encode<OptionalBinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv.Option.BinaryLightingPv
                => BinaryLightingPvCodec.GetEncodedLength(value.BinaryLightingPv),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalBinaryLightingPvCodec, global::Baclib.Bacnet.Types.Application.OptionalBinaryLightingPv>(tagNumber, value);
}
