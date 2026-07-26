// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class AsduElement
{


    public static T Decode<TCodec, T>(ref AsduReader reader)
    where TCodec : IAsduElementCodec<T>
    {
        return TCodec.Decode(ref reader);
    }

    public static T Decode<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.Decode(ref reader, tagNumber);
    }

    public static Optional<T> DecodeOptional<TCodec, T>(ref AsduReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return Decode<TCodec, T>(ref reader);
        }
        return Optional<T>.None;
    }

    public static Optional<T> DecodeOptional<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        if (reader.PeekContextTag(tagNumber))
        {
            return Decode<TCodec, T>(ref reader, tagNumber);
        }
        return Optional<T>.None;
    }







    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref AsduReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        var items = new List<T>();
        while (!reader.End)
        {
            var item = TCodec.Decode(ref reader);
            items.Add(item);
        }
        return new SequenceOf<T>([.. items]);
    }

    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        var items = new List<T>();
        reader.ReadOpeningTag(tagNumber);
        while (!reader.PeekClosingTag(tagNumber))
        {
            var item = TCodec.Decode(ref reader, tagNumber);
            items.Add(item);
        }
        reader.ReadClosingTag(tagNumber);
        return new SequenceOf<T>([.. items]);
    }

    public static Optional<SequenceOf<T>> DecodeOptionalSequenceOf<TCodec, T>(ref AsduReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return DecodeSequenceOf<TCodec, T>(ref reader);
        }
        return default;
    }

    public static Optional<SequenceOf<T>> DecodeOptionalSequenceOf<TCodec, T>(ref AsduReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return DecodeSequenceOf<TCodec, T>(ref reader, tagNumber);
        }
        return default;
    }








    public static void Encode<TCodec, T>(ref AsduWriter writer, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        TCodec.Encode(ref writer, value);
    }

    public static void Encode<TCodec, T>(ref AsduWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        TCodec.Encode(ref writer, tagNumber, value);
    }

    public static void EncodeOptional<TCodec, T>(ref AsduWriter writer, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            Encode<TCodec, T>(ref writer, value.Value);
        }
    }

    public static void EncodeOptional<TCodec, T>(ref AsduWriter writer, byte tagNumber, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            Encode<TCodec, T>(ref writer, tagNumber, value.Value);
        }
    }









    public static void EncodeSequenceOf<TCodec, T>(ref AsduWriter writer, in SequenceOf<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        foreach (var item in value)
        {
            TCodec.Encode(ref writer, in item);
        }
    }

    public static void EncodeSequenceOf<TCodec, T>(ref AsduWriter writer, byte tagNumber, in SequenceOf<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        writer.WriteOpeningTag(tagNumber);
        foreach (var item in value)
        {
            TCodec.Encode(ref writer, tagNumber, in item);
        }
        writer.WriteClosingTag(tagNumber);
    }

    public static void EncodeOptionalSequenceOf<TCodec, T>(ref AsduWriter writer, in Optional<SequenceOf<T>> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            var actualValue = value.Value;
            EncodeSequenceOf<TCodec, T>(ref writer, in actualValue);
        }
    }

    public static void EncodeOptionalSequenceOf<TCodec, T>(ref AsduWriter writer, byte tagNumber, in Optional<SequenceOf<T>> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            var actualValue = value.Value;
            EncodeSequenceOf<TCodec, T>(ref writer, tagNumber, in actualValue);
        }
    }
















    public static int GetEncodedLength<TCodec, T>(in T value)
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.GetEncodedLength(value);
    }

    public static int GetEncodedLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        return (tagNumber < 15 ? 2 : 4) + GetEncodedLength<TCodec, T>(value);
    }

    public static int GetOptionalEncodedLength<TCodec, T>(in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return GetEncodedLength<TCodec, T>(value.Value);
        }
        return 0;
    }

    public static int GetOptionalEncodedLength<TCodec, T>(byte tagNumber, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return GetEncodedLength<TCodec, T>(tagNumber, value.Value);
        }
        return 0;
    }

    public static int GetSequenceOfEncodedLength<TCodec, T>(in SequenceOf<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        int length = 0;
        foreach (var item in value.Items)
        {
            length += TCodec.GetEncodedLength(item);
        }
        return length;
    }

    public static int GetSequenceOfEncodedLength<TCodec, T>(byte tagNumber, in SequenceOf<T> value)
    where TCodec : IAsduElementCodec<T>
    {
        return (tagNumber < 15 ? 2 : 4) + GetSequenceOfEncodedLength<TCodec, T>(value);
    }

    public static int GetOptionalSequenceOfEncodedLength<TCodec, T>(in Optional<SequenceOf<T>> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return GetSequenceOfEncodedLength<TCodec, T>(value.Value);
        }
        return 0;
    }

    public static int GetOptionalSequenceOfEncodedLength<TCodec, T>(byte tagNumber, in Optional<SequenceOf<T>> value)
    where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return GetSequenceOfEncodedLength<TCodec, T>(tagNumber, value.Value);
        }
        return 0;
    }











}

/*
    /// <summary>
    /// Advances the decoder index until the specified closing tag is found or end of input is reached.
    /// </summary>
    /// <param name="closingTagNumber">The closing context tag number that terminates the scan.</param>
    /// <returns>The number of payload bytes traversed.</returns>
    /// <exception cref="ArgumentException">Thrown when an unexpected closing tag is encountered.</exception>
    private int ForwardIndex(int closingTagNumber)
    {
        var start = _index;
        while (!End)
        {
            var control = _asdu[_index++];
            var number = control >> 4;
            if (number == 15)
            {
                number = _asdu[_index++];
            }
            int length = control & 0x07;
            switch (length)
            {
                case < 5:
                {
                    _index += length;
                    break;
                }
                case 5:
                {
                    length = _asdu[_index++];
                    if (length > 253)
                    {
                        length = length == 254 ? _asdu[_index++] << 8 | _asdu[_index++] : _asdu[_index++] << 24 | _asdu[_index++] << 16 | _asdu[_index++] << 8 | _asdu[_index++];
                    }
                    _index += length;
                    break;
                }
                case 6:
                {
                    ForwardIndex(number);
                    break;
                }
                case 7:
                {
                    if (number == closingTagNumber)
                    {
                        return _index - (number < 15 ? 1 : 2) - start;
                    }
                    throw new ArgumentException($"Invalid closing tag number {number}.");
                }
            }
        }
        return _index - start;
    }
 
 */