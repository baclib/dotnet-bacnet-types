// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString16Codec : NativeCodecBase<BitString16>
{
    private BitString16Codec() : base(ApplicationTagNumber.BitString)
    {
    }

    public static readonly BitString16Codec Instance = new();

    protected override int CalculateValueSize(in BitString16 value) => AsduLength.BitString16;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in BitString16 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString16);
        var unusedBits = (byte)(16 - value.Count);
        NativeWriter.WriteBitStringFromFlags16(bytes, value.Flags, unusedBits);
    }

    protected override BitString16 DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString16)
            : decoder.Decode(tagNumber, AsduLength.BitString16);
        var unusedBits = bytes[0];
        var count = (byte)(16 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags16(bytes);
        return new BitString16(flags, count);
    }

    protected override Optional<BitString16> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.BitString16);
        if (!bytes.IsEmpty)
        {
            var unusedBits = bytes[0];
            var count = (byte)(16 - unusedBits);
            var flags = NativePrimitives.ReadBitFlags16(bytes);
            return new BitString16(flags, count);
        }
        return default;
    }
}

