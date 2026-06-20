// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString64Codec : INativeCodec<BitString64>
{
    private BitString64Codec()
    {
    }

    public static readonly BitString64Codec Instance = new();

    public int GetEncodedSize(in BitString64 value) => AsduLength.Sum(ApplicationTagNumber.BitString, AsduLength.BitString64);

    public int GetEncodedSize(byte tagNumber, in BitString64 value) => AsduLength.Sum(tagNumber, AsduLength.BitString64);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in BitString64 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString64);
        var unusedBits = (byte)(64 - value.Count);
        AsduEncoder.WriteBitStringFromFlags64(bytes, value.Flags, unusedBits);
    }

    public void Encode(ref AsduEncoder encoder, in BitString64 value) => Encode(ref encoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in BitString64 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static BitString64 Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString64)
            : decoder.Decode(tagNumber, AsduLength.BitString64);
        var unusedBits = bytes[0];
        var count = (byte)(64 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags64(bytes);
        return new BitString64(flags, count);
    }

    public BitString64 Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public BitString64 Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<BitString64> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
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

    public Optional<BitString64> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public Optional<BitString64> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

