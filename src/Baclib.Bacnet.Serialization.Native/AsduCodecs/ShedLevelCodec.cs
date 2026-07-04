// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ShedLevelCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ShedLevel>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ShedLevel>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ShedLevel Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @percent = UnsignedCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromPercent(@percent);
            case 1:
                var @level = UnsignedCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromLevel(@level);
            case 2:
                var @amount = RealCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromAmount(@amount);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ShedLevel Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ShedLevelCodec, global::Baclib.Bacnet.Types.Application.ShedLevel>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ShedLevel value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Percent:
                UnsignedCodec.Encode(ref writer, 0, value.Percent);
                return;
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Level:
                UnsignedCodec.Encode(ref writer, 1, value.Level);
                return;
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Amount:
                RealCodec.Encode(ref writer, 2, value.Amount);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ShedLevel value)
        => AsduConstructed.Encode<ShedLevelCodec, global::Baclib.Bacnet.Types.Application.ShedLevel>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ShedLevel value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Percent
                => UnsignedCodec.GetEncodedLength(value.Percent, 0),
            global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Level
                => UnsignedCodec.GetEncodedLength(value.Level, 1),
            global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Amount
                => RealCodec.GetEncodedLength(value.Amount, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ShedLevel value, byte tagNumber)
        => AsduElement.GetEncodedLength<ShedLevelCodec, global::Baclib.Bacnet.Types.Application.ShedLevel>(tagNumber, value);
}
