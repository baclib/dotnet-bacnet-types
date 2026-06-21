// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Formats.Asn1;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

/// <summary>
/// Abstract base class for native codecs that eliminates boilerplate code.
/// Handles the standard encode/decode patterns with application and context tags.
/// </summary>
/// <typeparam name="T">The BACnet value type being encoded/decoded.</typeparam>
public abstract class NativeCodecBase<T> : INativeCodec<T>
{
    private readonly ApplicationTagNumber? applicationTag;

    protected NativeCodecBase()
    {
    }

    protected NativeCodecBase(ApplicationTagNumber applicationTag)
    {
        this.applicationTag = applicationTag;
    }

    /// <summary>
    /// Gets a value indicating whether the codec supports the BACnet application-tagged form.
    /// </summary>
    public bool IsApplicationTagged => applicationTag.HasValue;

    /// <summary>
    /// Gets the ApplicationTagNumber for this codec's type.
    /// </summary>
    protected virtual ApplicationTagNumber ApplicationTag => applicationTag ?? throw CreateApplicationTagNotSupportedException();

    /// <summary>
    /// Calculates the encoded size of the value (tag and length overhead handled by base class).
    /// </summary>
    protected abstract int CalculateValueSize(in T value);

    /// <summary>
    /// Encodes the value bytes (excluding tag/length wrapper).
    /// </summary>
    protected abstract void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in T value);

    /// <summary>
    /// Decodes the value from the reader.
    /// </summary>
    protected abstract T DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass);

    /// <summary>
    /// Attempts to decode an optional value. Returns default if not present.
    /// </summary>
    protected abstract Optional<T> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass);

    // Public interface methods - standard boilerplate handled here

    public virtual int GetEncodedSize(in T value)
        => AsduLength.Sum((byte)ApplicationTag, CalculateValueSize(in value));

    public virtual int GetEncodedSize(byte tagNumber, in T value)
        => AsduLength.Sum(tagNumber, CalculateValueSize(in value));

    public virtual void Encode(ref NativeWriter encoder, in T value)
        => EncodeValueBytes(ref encoder, (byte)ApplicationTag, AsduTagClass.Application, in value);

    public virtual void Encode(ref NativeWriter encoder, byte tagNumber, in T value)
        => EncodeValueBytes(ref encoder, tagNumber, AsduTagClass.Context, in value);

    public virtual T Decode(ref NativeReader decoder)
        => DecodeValueBytes(ref decoder, (byte)ApplicationTag, AsduTagClass.Application);

    public virtual T Decode(ref NativeReader decoder, byte tagNumber)
        => DecodeValueBytes(ref decoder, tagNumber, AsduTagClass.Context);

    public virtual Optional<T> DecodeOptional(ref NativeReader decoder)
        => DecodeValueBytesOptional(ref decoder, (byte)ApplicationTag, AsduTagClass.Application);

    public virtual Optional<T> DecodeOptional(ref NativeReader decoder, byte tagNumber)
        => DecodeValueBytesOptional(ref decoder, tagNumber, AsduTagClass.Context);







    protected InvalidOperationException CreateApplicationTagNotSupportedException()
        => new($"{GetType().Name} does not support BACnet application-tagged encoding.");

    protected virtual bool HasStartPattern(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }


    protected virtual T DecodeValue(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    protected virtual T DecodeValue(ref NativeReader reader, byte tagNumber)
    {
        throw new NotImplementedException();
    }

    protected virtual Optional<T> DecodeOptionalValue(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    protected virtual Optional<T> DecodeOptionalValue(ref NativeReader reader, byte tagNumber)
    {
        throw new NotImplementedException();
    }

    protected virtual void EncodeValue(ref NativeWriter writer, in T value)
    {
        throw new NotImplementedException();
    }

    protected virtual void EncodeValue(ref NativeWriter writer, byte tagNumber, in T value)
    {
        throw new NotImplementedException();
    }
}











public abstract class MyBooleanCodec : ICodec<bool>
{
    public static bool DecodeContextValue(NativeReader reader) => throw new NotImplementedException();

    public static bool DecodeValue(NativeReader reader) => throw new NotImplementedException();

    public static void EncodeContextValue(NativeWriter writer, in bool value) => throw new NotImplementedException();

    public static void EncodeValue(NativeWriter writer, in bool value) => throw new NotImplementedException();

    public static int GetContextValueSize(in bool value)
    {
        throw new NotImplementedException();
    }

    public static int GetBasicValueSize(in bool value)
    {
        throw new NotImplementedException();
    }

    public static bool DecodeBasicValue(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public static bool DecodeContextValue(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public static void EncodeBasicValue(ref NativeWriter writer, in bool value)
    {
        throw new NotImplementedException();
    }

    public static void EncodeContextValue(ref NativeWriter writer, in bool value)
    {
        throw new NotImplementedException();
    }
}





public abstract class MyUnsignedCodec : ICodec<MyUnsignedCodec, bool>
{
    public static bool DecodeBasicValue(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public static bool DecodeValue(NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public static void EncodeBasicValue(ref NativeWriter writer, in bool value)
    {
        throw new NotImplementedException();
    }

    public static void EncodeValue(NativeWriter writer, in bool value)
    {
        throw new NotImplementedException();
    }

    public static int GetBasicValueSize(in bool value)
    {
        throw new NotImplementedException();
    }
}




public class MyCodecS<T> where T : ICodec<T>
{
    public T Process(NativeReader reader)
    {
        return T.DecodeContextValue(ref reader);
    }
}