// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1.Codecs;

public sealed class CharacterStringAsn1Codec : Asn1Codec<CharacterString>
{
    private CharacterStringAsn1Codec()
    {
    }

    public static readonly CharacterStringAsn1Codec Instance = new();

    public override int GetEncodedSize(in CharacterString value) => AsduLength.Sum(ApplicationTagNumber.CharacterString, value.ToBytes().Length);

    public override int GetEncodedSize(byte tagNumber, in CharacterString value) => AsduLength.Sum(tagNumber, value.ToBytes().Length);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in CharacterString value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, value.ToBytes().Length);
        AsduEncoder.WriteCharacterString(bytes, value);
    }

    public override void Encode(ref AsduEncoder encoder, in CharacterString value) => Encode(ref encoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application, in value);

    public override void Encode(ref AsduEncoder encoder, byte tagNumber, in CharacterString value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static CharacterString Decode(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return new CharacterString(bytes);
    }

    public override CharacterString Decode(ref AsduDecoder decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application);

    public override CharacterString Decode(ref AsduDecoder decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<CharacterString> DecodeOptional(ref AsduDecoder decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return new CharacterString(bytes);
        }

        return default;
    }

    public override Optional<CharacterString> DecodeOptional(ref AsduDecoder decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application);

    public override Optional<CharacterString> DecodeOptional(ref AsduDecoder decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}
