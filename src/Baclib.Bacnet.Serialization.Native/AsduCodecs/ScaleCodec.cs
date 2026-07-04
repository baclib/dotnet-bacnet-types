// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScaleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Scale>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Scale>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Scale Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @floatScale = RealCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.Scale.FromFloatScale(@floatScale);
            case 1:
                var @integerScale = IntegerCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.Scale.FromIntegerScale(@integerScale);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.Scale Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ScaleCodec, global::Baclib.Bacnet.Types.Application.Scale>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.Scale value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Scale.Option.FloatScale:
                RealCodec.Encode(ref writer, 0, value.FloatScale);
                return;
            case global::Baclib.Bacnet.Types.Application.Scale.Option.IntegerScale:
                IntegerCodec.Encode(ref writer, 1, value.IntegerScale);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Scale value)
        => AsduConstructed.Encode<ScaleCodec, global::Baclib.Bacnet.Types.Application.Scale>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.Scale value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.Scale.Option.FloatScale
                => RealCodec.GetEncodedLength(value.FloatScale, 0),
            global::Baclib.Bacnet.Types.Application.Scale.Option.IntegerScale
                => IntegerCodec.GetEncodedLength(value.IntegerScale, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.Scale value, byte tagNumber)
        => AsduElement.GetEncodedLength<ScaleCodec, global::Baclib.Bacnet.Types.Application.Scale>(tagNumber, value);
}
