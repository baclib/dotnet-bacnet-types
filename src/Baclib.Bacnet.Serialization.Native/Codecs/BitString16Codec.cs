// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class BitString16Codec : INativeCodec<BitString16>
{
    private BitString16Codec()
    {
    }

    public static readonly BitString16Codec Instance = new();

    public int GetEncodedSize(in BitString16 value) => AsduLength.Sum(ApplicationTagNumber.BitString, AsduLength.BitString16);

    public int GetEncodedSize(byte tagNumber, in BitString16 value) => AsduLength.Sum(tagNumber, AsduLength.BitString16);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in BitString16 value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.BitString16);
        var unusedBits = (byte)(16 - value.Count);
        AsduEncoder.WriteBitStringFromFlags16(bytes, value.Flags, unusedBits);
    }

    public void Encode(ref AsduEncoder encoder, in BitString16 value) => Encode(ref encoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in BitString16 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static BitString16 Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString16)
            : decoder.Decode(tagNumber, AsduLength.BitString16);
        var unusedBits = bytes[0];
        var count = (byte)(16 - unusedBits);
        var flags = NativePrimitives.ReadBitFlags16(bytes);
        return new BitString16(flags, count);
    }

    public BitString16 Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public BitString16 Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<BitString16> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
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

    public Optional<BitString16> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public Optional<BitString16> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

