// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class Unsigned8Codec : NativeCodecBase<byte>
{
    private Unsigned8Codec() : base(ApplicationTagNumber.Unsigned)
    {
    }

    public static readonly Unsigned8Codec Instance = new();

    protected override int CalculateValueSize(in byte value) => AsduLength.FromUnsigned8(value);

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in byte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Unsigned8);
        NativeWriter.WriteUnsigned8(bytes, value);
    }

    protected override byte DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Unsigned8)
            throw new AsduException();
        return NativePrimitives.ReadUnsigned8(bytes);
    }

    protected override Optional<byte> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Unsigned8)
                throw new AsduException();
            return NativePrimitives.ReadUnsigned8(bytes);
        }
        return default;
    }
}

