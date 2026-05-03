// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class BitString32Asn1Codec : Asn1CodecBase<BitString32>
{
    private BitString32Asn1Codec()
    {
    }

    public static readonly BitString32Asn1Codec Instance = new();

    public override int GetEncodedSize(in BitString32 value) => AsduLength.Sum(ApplicationTagNumber.BitString, AsduLength.BitString32);

    public override int GetEncodedSize(byte tagNumber, in BitString32 value) => AsduLength.Sum(tagNumber, AsduLength.BitString32);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in BitString32 value)
    {
        var bytes = encoder.Encode(tagNumber, tagClass, AsduLength.BitString32);
        var unusedBits = (byte)(32 - value.Count);
        AsduPrimitives.WriteBitStringFromFlags32(bytes, value.Flags, unusedBits);
    }

    public override void Encode(ref AsduEncoder encoder, in BitString32 value) => Encode(ref encoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in BitString32 value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static BitString32 Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = tagClass == AsduTagClass.Application
            ? decoder.Decode(ApplicationTagNumber.BitString, AsduLength.BitString32)
            : decoder.Decode(tagNumber, AsduLength.BitString32);
        var unusedBits = bytes[0];
        var count = (byte)(32 - unusedBits);
        var flags = AsduPrimitives.ReadBitFlags32(bytes);
        return new BitString32(flags, count);
    }

    public override BitString32 Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public override BitString32 Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<BitString32> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.DecodeOptional(tagClass, tagNumber, AsduLength.BitString32);
        if (!bytes.IsEmpty)
        {
            var unusedBits = bytes[0];
            var count = (byte)(32 - unusedBits);
            var flags = AsduPrimitives.ReadBitFlags32(bytes);
            return new BitString32(flags, count);
        }

        return default;
    }

    public override Optional<BitString32> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.BitString, AsduTagClass.Application);

    public override Optional<BitString32> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
