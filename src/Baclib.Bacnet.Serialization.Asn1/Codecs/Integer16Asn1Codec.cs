// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class Integer16Asn1Codec : Asn1Codec<short>
{
    private Integer16Asn1Codec()
    {
    }

    public static readonly Integer16Asn1Codec Instance = new();

    public override int GetEncodedSize(in short value) => AsduLength.Sum(ApplicationTagNumber.Signed, AsduLength.FromInteger16(value));

    public override int GetEncodedSize(byte tagNumber, in short value) => AsduLength.Sum(tagNumber, AsduLength.FromInteger16(value));

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in short value)
    {
        var length = AsduLength.FromInteger16(value);
        var bytes = encoder.Encode(tagClass, tagNumber, length);
        if (length == AsduLength.Signed8)
        {
            AsduEncoder.WriteInteger8(bytes, (sbyte)value);
            return;
        }

        AsduEncoder.WriteInteger16(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in short value) => Encode(ref encoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in short value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static short ReadInteger16(ref ReadOnlySpan<byte> bytes)
    {
        return bytes.Length switch
        {
            AsduLength.Signed8 => AsduDecoder.ReadSigned8(bytes),
            AsduLength.Signed16 => AsduDecoder.ReadSigned16(bytes),
            _ => throw new AsduException()
        };
    }

    private static short Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return ReadInteger16(ref bytes);
    }

    public override short Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override short Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<short> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return ReadInteger16(ref bytes);
        }
        return default;
    }

    public override Optional<short> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.Signed, AsduTagClass.Application);

    public override Optional<short> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
