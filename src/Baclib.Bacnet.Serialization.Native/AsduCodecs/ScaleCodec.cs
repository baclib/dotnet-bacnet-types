// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ScaleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Scale>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Scale>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.Scale Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _floatScale = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.Scale.FromFloatScale(_floatScale);
            case 1:
                var _integerScale = Asdu.DecodePrimitive<IntegerCodec, int>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.Scale.FromIntegerScale(_integerScale);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.Scale Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Scale value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Scale.Option.FloatScale:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 0, value.FloatScale);
                return;
            case global::Baclib.Bacnet.Types.Application.Scale.Option.IntegerScale:
                Asdu.EncodePrimitive<IntegerCodec, int>(ref writer, 1, value.IntegerScale);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Scale value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Scale value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.Scale.Option.FloatScale:
                return Asdu.GetPrimitiveLength<RealCodec, float>(0, value.FloatScale);
            case global::Baclib.Bacnet.Types.Application.Scale.Option.IntegerScale:
                return Asdu.GetPrimitiveLength<IntegerCodec, int>(1, value.IntegerScale);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Scale value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}