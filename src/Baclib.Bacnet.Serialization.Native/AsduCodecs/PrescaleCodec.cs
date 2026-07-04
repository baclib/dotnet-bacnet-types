// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PrescaleCodec :
    IAsduElementCodec<T::Prescale>,
    IAsduConstructedCodec<T::Prescale>
{
    public static T::Prescale Decode(ref AsduReader reader)
    {
        return new T::Prescale
        {
            Multiplier = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 0),
            ModuloDivide = AsduElement.Decode<UnsignedCodec, uint>(ref reader, 1)
        };
    }

    public static T::Prescale Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PrescaleCodec, T::Prescale>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::Prescale value)
    {
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 0, value.Multiplier);
        AsduElement.Encode<UnsignedCodec, uint>(ref writer, 1, value.ModuloDivide);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::Prescale value)
        => AsduConstructed.Encode<PrescaleCodec, T::Prescale>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::Prescale value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(0, value.Multiplier);
        length += AsduElement.GetEncodedLength<UnsignedCodec, uint>(1, value.ModuloDivide);
        return length;
    }

    public static int GetEncodedLength(in T::Prescale value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<PrescaleCodec, T::Prescale>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
