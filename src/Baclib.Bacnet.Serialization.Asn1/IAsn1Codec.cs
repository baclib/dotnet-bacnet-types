// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Combines ASN.1 encoding and decoding for a specific BACnet value type.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public interface IAsn1Codec<T> : IAsn1Encoder<T>, IAsn1Decoder<T>
{
}

/// <summary>
/// Runtime type-based codec abstraction used by serializer and registry lookup.
/// </summary>
public interface IAsn1CodecUntyped
{
    /// <summary>
    /// Gets the runtime target type handled by this codec.
    /// </summary>
    Type TargetType { get; }

    /// <summary>
    /// Gets the exact encoded size in bytes for <paramref name="value"/>.
    /// </summary>
    int GetEncodedSize(object value);

    /// <summary>
    /// Writes the ASN.1 encoding of <paramref name="value"/> to <paramref name="encoder"/>.
    /// </summary>
    void EncodeObject(ref AsduEncoder encoder, object value);

    /// <summary>
    /// Decodes a value from the current reader position.
    /// </summary>
    object DecodeObject(ref AsduDecoder decoder);
}

/// <summary>
/// Base adapter that exposes a strongly typed codec as untyped runtime codec.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public abstract class Asn1CodecBase<T> : IAsn1Codec<T>, IAsn1CodecUntyped
{
    public Type TargetType => typeof(T);

    public abstract int GetEncodedSize(in T value);

    public virtual int GetEncodedSize(byte contextTagNumber, in T value)
    {
        return AsduLength.FromTagNumber(contextTagNumber) + GetEncodedSize(in value);
    }

    int IAsn1CodecUntyped.GetEncodedSize(object value)
    {
        if (value is not T typed)
        {
            throw new ArgumentException($"Value must be of type {typeof(T).FullName}.", nameof(value));
        }

        return GetEncodedSize(in typed);
    }

    public abstract void Encode(ref AsduEncoder encoder, in T value);

    public virtual void Encode(ref AsduEncoder encoder, byte contextTagNumber, in T value)
    {
        throw new NotSupportedException($"Context-tagged encoding is not implemented for codec {GetType().FullName}.");
    }

    public abstract T Decode(ref AsduDecoder decoder);

    public virtual T Decode(ref AsduDecoder decoder, byte contextTagNumber)
    {
        throw new NotSupportedException($"Context-tagged decoding is not implemented for codec {GetType().FullName}.");
    }

    public abstract Optional<T> DecodeOptional(ref AsduDecoder decoder);

    public abstract Optional<T> DecodeOptional(ref AsduDecoder decoder, byte contextTagNumber);

    void IAsn1CodecUntyped.EncodeObject(ref AsduEncoder encoder, object value)
    {
        if (value is not T typed)
        {
            throw new ArgumentException($"Value must be of type {typeof(T).FullName}.", nameof(value));
        }

        Encode(ref encoder, in typed);
    }

    object IAsn1CodecUntyped.DecodeObject(ref AsduDecoder decoder)
    {
        return Decode(ref decoder)!;
    }
}
