// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString32Codec : INativeCodec<BitString32>
{
    private BitString32Codec()
    {
    }

    public static readonly BitString32Codec Instance = new();

    public int GetEncodedSize(in BitString32 value) => AsduLength.Sum(ApplicationTagNumber.BitString, AsduLength.BitString32);

    public int GetEncodedSize(byte tagNumber, in BitString32 value) => AsduLength.Sum(tagNumber, AsduLength.BitString32);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in BitString32 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString32);
        var unusedBits = (byte)(32 - value.Count);
        AsduEncoder.WriteBitStringFromFlags32(bytes, value.Flags, unusedBits);
    }

    public void Encode(ref AsduEncoder encoder, in BitString32 value) => Encode(ref encoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in BitString32 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static BitString32 Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString32)
            : decoder.Decode(tagNumber, AsduLength.BitString32);
        var unusedBits = bytes[0];
        var count = (byte)(32 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags32(bytes);
        return new BitString32(flags, count);
    }

    public BitString32 Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public BitString32 Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<BitString32> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
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

    public Optional<BitString32> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public Optional<BitString32> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

