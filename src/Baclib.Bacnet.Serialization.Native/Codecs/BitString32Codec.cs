// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString32Codec : NativeCodecBase<BitString32>
{
    private BitString32Codec() : base(ApplicationTagNumber.BitString)
    {
    }

    public static readonly BitString32Codec Instance = new();

    protected override int CalculateValueSize(in BitString32 value) => AsduLength.BitString32;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in BitString32 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString32);
        var unusedBits = (byte)(32 - value.Count);
        NativeWriter.WriteBitStringFromFlags32(bytes, value.Flags, unusedBits);
    }

    protected override BitString32 DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString32)
            : decoder.Decode(tagNumber, AsduLength.BitString32);
        var unusedBits = bytes[0];
        var count = (byte)(32 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags32(bytes);
        return new BitString32(flags, count);
    }

    protected override Optional<BitString32> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.BitString32);
        if (!bytes.IsEmpty)
        {
            var unusedBits = bytes[0];
            var count = (byte)(32 - unusedBits);
            var flags = NativePrimitives.ReadBitFlags32(bytes);
            return new BitString32(flags, count);
        }
        return default;
    }
}

