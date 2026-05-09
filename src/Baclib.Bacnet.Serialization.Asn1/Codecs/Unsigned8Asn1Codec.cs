// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Unsigned8Asn1Codec : Asn1Codec<byte>
{
    private Unsigned8Asn1Codec()
    {
    }

    public static readonly Unsigned8Asn1Codec Instance = new();

    public override int GetEncodedSize(in byte value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned8(value));

    public override int GetEncodedSize(byte tagNumber, in byte value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned8(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in byte value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, AsduLength.Unsigned8);
        AsduEncoder.WriteUnsigned8(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in byte value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in byte value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static byte Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        if (bytes.Length != AsduLength.Unsigned8)
        {
            throw new AsduException();
        }
        return AsduDecoder.ReadUnsigned8(bytes);
    }

    public override byte Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override byte Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<byte> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            if (bytes.Length != AsduLength.Unsigned8)
            {
                throw new AsduException();
            }
            return AsduDecoder.ReadUnsigned8(bytes);
        }
        return default;
    }

    public override Optional<byte> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override Optional<byte> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
