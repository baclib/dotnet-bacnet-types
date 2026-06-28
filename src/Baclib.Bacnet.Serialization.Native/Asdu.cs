
using System.Collections.Immutable;

namespace Baclib.Bacnet.Serialization.Native;

public static class Asdu
{
    public static T DecodePrimitive<TCodec, T>(ref NativeReader reader)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var source = reader.ReadBytes(TCodec.TagNumber);
        return TCodec.DecodeValue(source);
    }






    public static T DecodePrimitive<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var source = reader.ReadBytes(tagNumber);
        return TCodec.DecodeValue(source);
    }


    public static T DecodeConstructed<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduConstructedCodec<T>
    {
        reader.ReadOpeningTag();
        var value = TCodec.Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }




    public static Optional<T> DecodeOptional<TCodec, T>(ref NativeReader reader)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        if (reader.PeekTag(TCodec.TagNumber))
        {
            return DecodePrimitive<TCodec, T>(ref reader);
        }
        return Optional<T>.None;
    }

    public static Optional<T> DecodeOptional<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        if (reader.PeekTag(tagNumber))
        {
            return DecodePrimitive<TCodec, T>(ref reader, tagNumber);
        }
        return Optional<T>.None;
    }






    public static void EncodePrimitive<TCodec, T>(ref NativeWriter writer, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var destination = writer.WriteBlank(TCodec.TagNumber, TCodec.GetEncodedValueLength(value));
        TCodec.EncodeValue(destination, value);
    }

    public static void EncodePrimitive<TCodec, T>(ref NativeWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        var destination = writer.WriteBlank(tagNumber, TCodec.GetEncodedValueLength(value));
        TCodec.EncodeValue(destination, value);
    }

    public static void EncodeConstructed<TCodec, T>(ref NativeWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduConstructedCodec<T>
    {
        var destination = writer.WriteBlank(tagNumber, TCodec.GetLength(value));
        //TCodec.EncodeContents(destination, value);
        throw new NotImplementedException();
    }











    public static void EncodeOptional<TCodec, T>(ref NativeWriter writer, byte tagNumber, in Optional<T> value)
            where TCodec : IAsduPrimitiveCodec<T>
    {
        if (value.HasValue)
        {
            EncodePrimitive<TCodec, T>(ref writer, tagNumber, value.Value);
        }
    }







    public static int GetEncodedLength<TCodec, T>(in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return 1 + TCodec.GetEncodedValueLength(value);
    }

    public static int GetPrimitiveLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return (tagNumber < 15 ? 1 : 2) + TCodec.GetEncodedValueLength(value);
    }


    public static int GetConstructedLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduConstructedCodec<T>
    {
        return (tagNumber < 15 ? 1 : 2) + TCodec.GetLength(value);
    }













    public static int GetEncodedLengthOptional<TCodec, T>(byte tagNumber, in Optional<T> value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return value.HasValue ? GetPrimitiveLength<TCodec, T>(tagNumber, value.Value) : 0;
    }































    public static T DecodeElement<TCodec, T>(ref NativeReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.Decode(ref reader);
    }

    public static T DecodeElement<TCodec, T>(ref NativeReader reader, byte tagNumber)   
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.Decode(ref reader, tagNumber);
    }

    public static Optional<T> DecodeOptionalElement<TCodec, T>(ref NativeReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return TCodec.Decode(ref reader);
        }
        return Optional<T>.None;
    }

    public static Optional<T> DecodeOptionalElement<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return TCodec.Decode(ref reader, tagNumber);
        }
        return Optional<T>.None;
    }

    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref NativeReader reader)
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

    public static SequenceOf<T> DecodeSequenceOf<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        var items = new List<T>();
        reader.ReadOpeningTag(tagNumber);
        while (!reader.ReadClosingTagOptional(tagNumber))
        {
            var item = TCodec.Decode(ref reader, tagNumber);
            items.Add(item);
        }
        reader.ReadClosingTag(tagNumber);
        return new SequenceOf<T>([.. items]);
    }

    public static SequenceOf<T> DecodeOptionalSequenceOf<TCodec, T>(ref NativeReader reader)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return DecodeSequenceOf<TCodec, T>(ref reader);
        }
        return SequenceOf<T>.Empty;
    }

    public static SequenceOf<T> DecodeOptionalSequenceOf<TCodec, T>(ref NativeReader reader, byte tagNumber)
        where TCodec : IAsduElementCodec<T>
    {
        if (TCodec.Matches(ref reader))
        {
            return DecodeSequenceOf<TCodec, T>(ref reader, tagNumber);
        }
        return SequenceOf<T>.Empty;
    }








    public static void EncodeElement<TCodec, T>(ref NativeWriter writer, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        TCodec.Encode(ref writer, value);
    }

    public static void EncodeElement<TCodec, T>(ref NativeWriter writer, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            TCodec.Encode(ref writer, value.Value);
        }
        throw new NotImplementedException();
    }

    public static void EncodeElement<TCodec, T>(ref NativeWriter writer, byte tagNumber, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        TCodec.Encode(ref writer, tagNumber, value);
    }

    public static void EncodeOptionalElement<TCodec, T>(ref NativeWriter writer, byte tagNumber, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            TCodec.Encode(ref writer, tagNumber, value.Value);
        }
        throw new NotImplementedException();
    }

    public static int GetElementLength<TCodec, T>(in T value)
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.GetLength(value);
    }

    public static int GetElementLength<TCodec, T>(in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return TCodec.GetLength(value.Value);
        }
        return 0;
    }

    public static int GetElementLength<TCodec, T>(byte tagNumber, in T value)
        where TCodec : IAsduElementCodec<T>
    {
        return TCodec.GetLength(value, tagNumber);
    }

    public static int GetElementLength<TCodec, T>(byte tagNumber, in Optional<T> value)
        where TCodec : IAsduElementCodec<T>
    {
        if (value.HasValue)
        {
            return TCodec.GetLength(value.Value, tagNumber);
        }
        return 0;
    }
}
