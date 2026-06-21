// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString8Codec : NativeCodecBase<BitString8>
{
    private BitString8Codec() : base(ApplicationTagNumber.BitString)
    {
    }

    public static readonly BitString8Codec Instance = new();

    protected override int CalculateValueSize(in BitString8 value) => AsduLength.BitString8;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in BitString8 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString8);
        var unusedBits = (byte)(8 - value.Count);
        NativeWriter.WriteBitStringFromFlags8(bytes, value.Flags, unusedBits);
    }

    protected override BitString8 DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString8)
            : decoder.Decode(tagNumber, AsduLength.BitString8);
        var unusedBits = bytes[0];
        var count = (byte)(8 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags8(bytes);
        return new BitString8(flags, count);
    }

    protected override Optional<BitString8> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.BitString8);
        if (!bytes.IsEmpty)
        {
            var unusedBits = bytes[0];
            var count = (byte)(8 - unusedBits);
            var flags = NativePrimitives.ReadBitFlags8(bytes);
            return new BitString8(flags, count);
        }
        return default;
    }
}

