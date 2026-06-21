// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class CharacterStringCodec : NativeCodecBase<CharacterString>
{
    private CharacterStringCodec() : base(ApplicationTagNumber.CharacterString)
    {
    }

    public static readonly CharacterStringCodec Instance = new();

    protected override int CalculateValueSize(in CharacterString value) => value.ToBytes().Length;

    protected override void EncodeValueBytes(ref NativeWriter encoder, byte tagNumber, AsduTagClass tagClass, in CharacterString value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, value.ToBytes().Length);
        NativeWriter.WriteCharacterString(bytes, value);
    }

    protected override CharacterString DecodeValueBytes(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Read(tagClass, tagNumber);
        return new CharacterString(bytes);
    }

    protected override Optional<CharacterString> DecodeValueBytesOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.ReadOptional(tagClass, tagNumber, out var bytes))
            return new CharacterString(bytes);
        return default;
    }
}

