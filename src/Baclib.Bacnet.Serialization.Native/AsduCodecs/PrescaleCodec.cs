// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PrescaleCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.Prescale>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.Prescale>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.Prescale Decode(ref NativeReader reader)
    {
        var _multiplier = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 0);
        var _moduloDivide = Asdu.DecodePrimitive<UnsignedCodec, uint>(ref reader, 1);

        return new global::Baclib.Bacnet.Types.Application.Prescale
        {
            Multiplier = _multiplier,
            ModuloDivide = _moduloDivide
        };
    }

    public static global::Baclib.Bacnet.Types.Application.Prescale Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.Prescale value)
    {
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 0, value.Multiplier);
        Asdu.EncodePrimitive<UnsignedCodec, uint>(ref writer, 1, value.ModuloDivide);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.Prescale value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Prescale value)
    {
        return Asdu.GetPrimitiveLength<UnsignedCodec, uint>(0, value.Multiplier) + Asdu.GetPrimitiveLength<UnsignedCodec, uint>(1, value.ModuloDivide);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.Prescale value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
