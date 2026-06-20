// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString8Codec : INativeCodec<BitString8>
{
    private BitString8Codec()
    {
    }

    public static readonly BitString8Codec Instance = new();

    public int GetEncodedSize(in BitString8 value) => AsduLength.Sum(ApplicationTagNumber.BitString, AsduLength.BitString8);

    public int GetEncodedSize(byte tagNumber, in BitString8 value) => AsduLength.Sum(tagNumber, AsduLength.BitString8);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in BitString8 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString8);
        var unusedBits = (byte)(8 - value.Count);
        AsduEncoder.WriteBitStringFromFlags8(bytes, value.Flags, unusedBits);
    }

    public void Encode(ref AsduEncoder encoder, in BitString8 value) => Encode(ref encoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in BitString8 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static BitString8 Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString8)
            : decoder.Decode(tagNumber, AsduLength.BitString8);
        var unusedBits = bytes[0];
        var count = (byte)(8 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags8(bytes);
        return new BitString8(flags, count);
    }

    public BitString8 Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public BitString8 Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<BitString8> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
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

    public Optional<BitString8> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public Optional<BitString8> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

