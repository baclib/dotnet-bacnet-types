// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class ObjectIdentifierCodec : INativeCodec<ObjectIdentifier>
{
    private ObjectIdentifierCodec()
    {
    }

    public static readonly ObjectIdentifierCodec Instance = new();

    public int GetEncodedSize(in ObjectIdentifier value) => AsduLength.Sum(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);

    public int GetEncodedSize(byte tagNumber, in ObjectIdentifier value) => AsduLength.Sum(tagNumber, AsduLength.ObjectIdentifier);

    public void Encode(ref AsduEncoder encoder, in ObjectIdentifier value)
    {
        var bytes = encoder.Encode(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        AsduEncoder.WriteObjectIdentifier(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in ObjectIdentifier value)
    {
        var bytes = encoder.Encode(tagNumber, AsduLength.ObjectIdentifier);
        AsduEncoder.WriteObjectIdentifier(bytes, value);
    }

    public ObjectIdentifier Decode(ref NativeReader decoder)
    {
        var bytes = decoder.Decode(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        return NativePrimitives.ReadObjectIdentifier(bytes);
    }

    public ObjectIdentifier Decode(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.Decode(tagNumber, AsduLength.ObjectIdentifier);
        return NativePrimitives.ReadObjectIdentifier(bytes);
    }

    public Optional<ObjectIdentifier> DecodeOptional(ref NativeReader decoder)
    {
        var bytes = decoder.DecodeOptional(ApplicationTagNumber.ObjectIdentifier, AsduLength.ObjectIdentifier);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadObjectIdentifier(bytes);
        }
        return default;
    }

    public Optional<ObjectIdentifier> DecodeOptional(ref NativeReader decoder, byte tagNumber)
    {
        var bytes = decoder.DecodeOptional(tagNumber, AsduLength.ObjectIdentifier);
        if (!bytes.IsEmpty)
        {
            return NativePrimitives.ReadObjectIdentifier(bytes);
        }
        return default;
    }
}

