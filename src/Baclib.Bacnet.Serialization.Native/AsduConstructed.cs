// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class AsduConstructed
{
    public static T Decode<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduConstructedCodec<T>
    {
        reader.ReadOpeningTag(tagNumber);
        var value = TCodec.Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode<TCodec, T>(ref AsduWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduConstructedCodec<T>
    {
        writer.WriteOpeningTag(tagNumber);
        TCodec.Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetEncodedLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduConstructedCodec<T>
    {
        return 2 * AsduLength.FromTagNumber(tagNumber) + TCodec.GetEncodedLength(value);
    }
}
