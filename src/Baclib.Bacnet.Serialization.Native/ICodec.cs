// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Formats.Asn1;
using System.Text;

namespace Baclib.Bacnet.Serialization.Native;


public interface ICodec<T>
{
    static abstract ApplicationTagNumber TagNumber { get; }

    static abstract T DecodeBasicValue(ReadOnlySpan<byte> source);

    static abstract T DecodeContextValue(ReadOnlySpan<byte> source);

    static abstract void EncodeBasicValue(Span<byte> bytes, in T value);

    static abstract void EncodeContextValue(Span<byte> bytes, in T value);

    static abstract int GetBasicLength(in T value);

    static abstract int GetContextLength(in T value);

    static abstract int GetBasicValueSize(in T value);

    static abstract int GetContextValueSize(in T value);

    static abstract bool PeekBasicTag(ref NativeReader reader);
}




public interface ICodec<TSelf, T> : ICodec<T> where TSelf : ICodec<TSelf, T>
{
    static T ICodec<T>.DecodeContextValue(ReadOnlySpan<byte> source) => TSelf.DecodeBasicValue(source);

    static void ICodec<T>.EncodeContextValue(Span<byte> bytes, in T value) => TSelf.EncodeBasicValue(bytes, in value);

    static int ICodec<T>.GetContextValueSize(in T value) => TSelf.GetBasicValueSize(in value);
}

public interface IPrimitiveCodec<TSelf, T> : ICodec<TSelf, T>
    where TSelf : IPrimitiveCodec<TSelf, T>
{
    static bool ICodec<T>.PeekBasicTag(ref NativeReader reader) => reader.PeekTag(TSelf.TagNumber);

    static int ICodec<T>.GetContextLength(in T value) => TSelf.GetBasicLength(in value);
}

public interface IConstructedCodec<TSelf, T> : ICodec<TSelf, T>
    where TSelf : IConstructedCodec<TSelf, T>
{
    static ApplicationTagNumber ICodec<T>.TagNumber => (ApplicationTagNumber)byte.MaxValue;

    static int ICodec<T>.GetBasicLength(in T value) => 0;
    static int ICodec<T>.GetContextLength(in T value) => 0;
}








public class MyInteger32Codec : IPrimitiveCodec<MyInteger32Codec, int>
{
    public static ApplicationTagNumber TagNumber => ApplicationTagNumber.Signed;

    public static int Decode(ref NativeReader reader)
    {
        var bytes = reader.ReadBytes(ApplicationTagNumber.Signed);
        return DecodeBasicValue(bytes);
    }

    public static int DecodeBasicValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Signed8 => NativePrimitives.ReadInteger8(source),
            AsduLength.Signed16 => NativePrimitives.ReadInteger16(source),
            AsduLength.Signed24 => NativePrimitives.ReadInteger24(source),
            AsduLength.Signed32 => NativePrimitives.ReadInteger32(source),
            _ => throw new AsduException()
        };
    }

    public static void EncodeBasicValue(Span<byte> bytes, in int value)
    {
        switch (bytes.Length)
        {
            case AsduLength.Signed8:
                NativeWriter.WriteInteger8(bytes, (sbyte)value);
                break;
            case AsduLength.Signed16:
                NativeWriter.WriteInteger16(bytes, (short)value);
                break;
            case AsduLength.Signed24:
                NativeWriter.WriteInteger24(bytes, value);
                break;
            case AsduLength.Signed32:
                NativeWriter.WriteInteger32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 32-bit integer.");
        }
    }

    public static int GetBasicLength(in int value) => AsduLength.FromInteger32(value);

    public static int GetBasicValueSize(in int value)
    {
        return AsduLength.FromInteger32(value);
    }

    public static int GetContextLength(in int value)
    {
        throw new NotImplementedException();
    }
}






public sealed class PrimitiveCodec<TCodec, TValue>
    where TCodec : IPrimitiveCodec<TCodec, TValue>
{
    public TValue Decode(ref NativeReader reader)
    {
        var bytes = reader.ReadBytes(TCodec.TagNumber);
        return TCodec.DecodeBasicValue(bytes);
    }

    public TValue Decode(ref NativeReader reader, byte tagNumber)
    {
        var bytes = reader.ReadBytes(tagNumber);
        return TCodec.DecodeContextValue(bytes);
    }

    public Optional<TValue> DecodeOptional(ref NativeReader reader)
    {
        if (reader.PeekTag(TCodec.TagNumber))
        {
            return Decode(ref reader);
        }
        return Optional<TValue>.None;
    }

    public Optional<TValue> DecodeOptional(ref NativeReader reader, byte tagNumber)
    {
        if (reader.PeekTag(tagNumber))
        {
            return Decode(ref reader, tagNumber);
        }
        return Optional<TValue>.None;
    }

    public void Encode(ref NativeWriter writer, in TValue value)
    {
        var bytes = writer.WriteBlank(TCodec.TagNumber, TCodec.GetBasicLength(in value));
        TCodec.EncodeBasicValue(bytes, in value);
    }

    public void Encode(ref NativeWriter writer, byte tagNumber, in TValue value)
    {
        var bytes = writer.WriteBlank(tagNumber, TCodec.GetContextLength(in value));
        TCodec.EncodeBasicValue(bytes, in value);
    }
}


public sealed class ConstructedCodec<TCodec, TValue>
    where TCodec : IConstructedCodec<TCodec, TValue>
{
}










public interface IMyCodec<T>
{
    static abstract bool IsPrimitive { get; }

    static abstract ApplicationTagNumber Primitive { get; }

    static abstract T ReadPrimitive(ReadOnlySpan<byte> source);

    static abstract T ReadConstructed(ref NativeReader reader);

    static abstract bool PeekTag(ref NativeReader reader);

    static abstract int GetLength(in T value);

    static abstract T WritePrimitive(ReadOnlySpan<byte> source, in T value);

    static abstract T WriteConstructed(ref NativeWriter writer, in T value);
}



public interface IMyPrimitiveCodec<T> : IMyCodec<T>
{
    static bool IMyCodec<T>.IsPrimitive => true;

    static bool IMyCodec<T>.PeekTag(ref NativeReader reader) => throw new NotImplementedException();

    static T IMyCodec<T>.ReadConstructed(ref NativeReader reader) => throw new InvalidOperationException("Primitive codecs do not support reading as constructed values.");

    static T IMyCodec<T>.WriteConstructed(ref NativeWriter writer, in T value) => throw new InvalidOperationException("Primitive codecs do not support writing as constructed values.");
}























public interface IConstructedCodec<T> : IMyCodec<T>
{
    static bool IMyCodec<T>.IsPrimitive => false;

    static ApplicationTagNumber IMyCodec<T>.Primitive => throw new InvalidOperationException("Constructed codecs do not have a primitive tag number.");
}
















public sealed class MyCodec<TCodec, TValue>
    where TCodec : IMyCodec<TValue>
{
    public TValue Decode(ref NativeReader reader)
    {
        if (TCodec.IsPrimitive)
        {
            if (typeof(TCodec) == typeof(IMyCodec<bool>))
            {
                // Special handling for boolean values, which are encoded as a single byte with value 0 or 1
                var byteValue = reader.DecodeTag(ApplicationTagNumber.Boolean);
                if (byteValue == 0)
                    return (TValue)(object)false;
                else if (byteValue == 1)
                    return (TValue)(object)true;
                else
                    throw new AsduException("Invalid boolean encoding.");
            }


            var bytes = reader.ReadBytes(TCodec.Primitive);
            return TCodec.ReadPrimitive(bytes);
        }
        return TCodec.ReadConstructed(ref reader);
    }

    public TValue Decode(ref NativeReader reader, byte tagNumber)
    {
        if (TCodec.IsPrimitive)
        {
            var bytes = reader.ReadBytes(tagNumber);
            return TCodec.ReadPrimitive(bytes);
        }
        reader.DecodeOpeningTag(tagNumber);
        var value = TCodec.ReadConstructed(ref reader);
        reader.DecodeClosingTag(tagNumber);
        return value;
    }

    public Optional<TValue> DecodeOptional(ref NativeReader reader)
    {
        if (TCodec.PeekTag(ref reader))
        {
            return Decode(ref reader);
        }
        return Optional<TValue>.None;
    }

    public Optional<TValue> DecodeOptional(ref NativeReader reader, byte tagNumber)
    {
        if (reader.PeekTag(tagNumber))
        {
            return Decode(ref reader, tagNumber);
        }
        return Optional<TValue>.None;
    }

    public void Encode(ref NativeWriter writer, in TValue value)
    {
        if (TCodec.IsPrimitive)
        {
            if (typeof(TCodec) == typeof(IMyCodec<bool>))
            {
                // Special handling for boolean values, which are encoded as a single byte with value 0 or 1
            }

            var bytes = writer.WriteBlank(TCodec.Primitive, TCodec.GetLength(in value));
            TCodec.WritePrimitive(bytes, in value);
            return;
        }
        TCodec.WriteConstructed(ref writer, in value);
    }

    public void Encode(ref NativeWriter writer, byte tagNumber, in TValue value)
    {
        if (TCodec.IsPrimitive)
        {
            var bytes = writer.WriteBlank(tagNumber, TCodec.GetLength(in value));
            TCodec.WritePrimitive(bytes, in value);
            return;
        }
        writer.WriteOpeningTag(tagNumber);
        TCodec.WriteConstructed(ref writer, in value);
        writer.WriteClosingTag(tagNumber);
    }
}
