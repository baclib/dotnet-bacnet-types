// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Unsigned32Asn1Codec : Asn1Codec<uint>
{
    private Unsigned32Asn1Codec()
    {
    }

    public static readonly Unsigned32Asn1Codec Instance = new();

    public override int GetEncodedSize(in uint value) => AsduLength.Sum(ApplicationTagNumber.Unsigned, AsduLength.FromUnsigned32(value));

    public override int GetEncodedSize(byte tagNumber, in uint value) => AsduLength.Sum(tagNumber, AsduLength.FromUnsigned32(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in uint value)
    {
        var length = AsduLength.FromUnsigned32(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        switch (length)
        {
            case 1:
                AsduEncoder.WriteUnsigned8(bytes, (byte)value);
                break;
            case 2:
                AsduEncoder.WriteUnsigned16(bytes, (ushort)value);
                break;
            case 3:
                AsduEncoder.WriteUnsigned24(bytes, value);
                break;
            case 4:
                AsduEncoder.WriteUnsigned32(bytes, value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    public override void Encode(ref AsduEncoder encoder, in uint value) => Encode(ref encoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in uint value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static uint ReadUnsigned32(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Unsigned8 => AsduDecoder.ReadUnsigned8(bytes),
            AsduLength.Unsigned16 => AsduDecoder.ReadUnsigned16(bytes),
            AsduLength.Unsigned24 => AsduDecoder.ReadUnsigned24(bytes),
            AsduLength.Unsigned32 => AsduDecoder.ReadUnsigned32(bytes),
            _ => throw new AsduException()
        };
    }

    private static uint Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadUnsigned32(ref bytes);
    }

    public override uint Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override uint Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<uint> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadUnsigned32(ref bytes);
        }
        return default;
    }

    public override Optional<uint> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Unsigned, AsduTagClass.Application);

    public override Optional<uint> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
