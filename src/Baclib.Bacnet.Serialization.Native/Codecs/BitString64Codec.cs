// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString64Codec : NativeCodecBase<BitString64>
{
    private BitString64Codec() : base(ApplicationTagNumber.BitString)
    {
    }

    public static readonly BitString64Codec Instance = new();

    protected override int CalculateValueSize(in BitString64 value) => AsduLength.BitString64;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in BitString64 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString64);
        var unusedBits = (byte)(64 - value.Count);
        NativeWriter.WriteBitStringFromFlags64(bytes, value.Flags, unusedBits);
    }

    protected override BitString64 DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString64)
            : decoder.Decode(tagNumber, AsduLength.BitString64);
        var unusedBits = bytes[0];
        var count = (byte)(64 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags64(bytes);
        return new BitString64(flags, count);
    }

    protected override Optional<BitString64> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.BitString64);
        if (!bytes.IsEmpty)
        {
            var unusedBits = bytes[0];
            var count = (byte)(64 - unusedBits);
            var flags = NativePrimitives.ReadBitFlags64(bytes);
            return new BitString64(flags, count);
        }
        return default;
    }
}

