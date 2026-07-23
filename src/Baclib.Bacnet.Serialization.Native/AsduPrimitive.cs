// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class AsduPrimitive
{
    public static T Decode<TCodec, T>(ref AsduReader reader)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var source = reader.ReadApplicationPrimitive(TCodec.TagNumber);
        return TCodec.DecodeValue(source);
    }

    public static T Decode<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var source = reader.ReadContextPrimitive(tagNumber);
        return TCodec.DecodeValue(source);
    }

    public static void Encode<TCodec, T>(ref AsduWriter writer, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var destination = writer.WriteTagAndReserve(TCodec.TagNumber, TCodec.GetEncodedValueLength(value));
        TCodec.EncodeValue(destination, value);
    }

    public static void Encode<TCodec, T>(ref AsduWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var destination = writer.WriteTagAndReserve(tagNumber, TCodec.GetEncodedValueLength(value));
        TCodec.EncodeValue(destination, value);
    }

    public static int GetEncodedLength<TCodec, T>(in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return AsduLength.FromTagNumber(TCodec.TagNumber) + TCodec.GetEncodedValueLength(value);
    }

    public static int GetEncodedLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return AsduLength.FromTagNumber(tagNumber) + TCodec.GetEncodedValueLength(value);
    }


    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref AsduReader reader)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var items = new List<T>();
        while (!reader.End)
        {
            var item = Decode<TCodec, T>(ref reader);
            items.Add(item);
        }
        return new SequenceOf<T>([.. items]);
    }

    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var items = new List<T>();
        reader.ReadOpeningTag(tagNumber);
        while (!reader.PeekClosingTag(tagNumber))
        {
            var item = Decode<TCodec, T>(ref reader, tagNumber);
            items.Add(item);
        }
        reader.ReadClosingTag(tagNumber);
        return new SequenceOf<T>([.. items]);
    }
}
