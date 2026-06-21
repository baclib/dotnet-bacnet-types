// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class ObjectIdentifierCodec : NativeCodecBase<ObjectIdentifier>
{
    private ObjectIdentifierCodec() : base(ApplicationTagNumber.ObjectIdentifier)
    {
    }

    public static readonly ObjectIdentifierCodec Instance = new();

    protected override int CalculateValueSize(in ObjectIdentifier value) => AsduLength.ObjectIdentifier;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in ObjectIdentifier value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.ObjectIdentifier);
        NativeWriter.WriteObjectIdentifier(bytes, value);
    }

    protected override ObjectIdentifier DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber, AsduLength.ObjectIdentifier);
        return NativePrimitives.ReadObjectIdentifier(bytes);
    }

    protected override Optional<ObjectIdentifier> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.ObjectIdentifier);
        if (!bytes.IsEmpty)
            return NativePrimitives.ReadObjectIdentifier(bytes);
        return default;
    }
}

