// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ShedLevelCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ShedLevel>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ShedLevel>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
            case 2:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ShedLevel Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _percent = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromPercent(_percent);
            case 1:
                var _level = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromLevel(_level);
            case 2:
                var _amount = Asdu.DecodePrimitive<RealCodec, float>(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ShedLevel.FromAmount(_amount);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ShedLevel Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ShedLevel value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Percent:
                Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.Percent);
                return;
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Level:
                Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.Level);
                return;
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Amount:
                Asdu.EncodePrimitive<RealCodec, float>(ref writer, 2, value.Amount);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ShedLevel value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ShedLevel value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Percent:
                return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.Percent);
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Level:
                return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.Level);
            case global::Baclib.Bacnet.Types.Application.ShedLevel.Option.Amount:
                return Asdu.GetPrimitiveLength<RealCodec, float>(2, value.Amount);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ShedLevel value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}