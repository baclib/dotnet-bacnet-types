// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// High-level entry point for ASN.1 encode/decode operations.
/// </summary>
public static class Asn1Serializer
{
    public static byte[] Encode<T>(in T value)
    {
        IAsn1Codec<T> codec = Asn1CodecRegistry.Get<T>();
        int size = codec.GetEncodedSize(in value);

        var encoder = new AsduEncoder(size);
        codec.Encode(ref encoder, in value);
        return encoder.Buffer;
    }

    public static byte[] Encode(object value)
    {
        ArgumentNullException.ThrowIfNull(value);

        IAsn1CodecUntyped codec = Asn1CodecRegistry.Get(value.GetType());
        int size = codec.GetEncodedSize(value);

        var encoder = new AsduEncoder(size);
        codec.EncodeObject(ref encoder, value);
        return encoder.Buffer;
    }

    public static T Decode<T>(ReadOnlySpan<byte> data)
    {
        IAsn1Codec<T> codec = Asn1CodecRegistry.Get<T>();

        var decoder = new AsduDecoder(data);
        T value = codec.Decode(ref decoder);
        EnsureFullyConsumed(decoder);
        return value;
    }

    public static object Decode(ReadOnlySpan<byte> data, Type targetType)
    {
        ArgumentNullException.ThrowIfNull(targetType);

        IAsn1CodecUntyped codec = Asn1CodecRegistry.Get(targetType);

        var decoder = new AsduDecoder(data);
        object value = codec.DecodeObject(ref decoder);
        EnsureFullyConsumed(decoder);
        return value;
    }

    public static bool TryDecode<T>(ReadOnlySpan<byte> data, out T value)
    {
        /*
        IAsn1Codec<T> codec = Asn1CodecRegistry.Get<T>();

        var decoder = new AsduDecoder(data);
        if (!codec.TryDecode(ref decoder, out value!))
        {
            value = default!;
            return false;
        }

        return decoder.End;
        */
        value = default!;
        return false; // TODO: Implement TryDecode
    }

    private static void EnsureFullyConsumed(AsduDecoder decoder)
    {
        if (!decoder.End)
        {
            throw new AsduException("Decoded value did not consume the full input span.");
        }
    }
}
