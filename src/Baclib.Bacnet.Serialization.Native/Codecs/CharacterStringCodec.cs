// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class CharacterStringCodec : INativeCodec<CharacterString>
{
    private CharacterStringCodec()
    {
    }

    public static readonly CharacterStringCodec Instance = new();

    public int GetEncodedSize(in CharacterString value) => AsduLength.Sum(ApplicationTagNumber.CharacterString, value.ToBytes().Length);

    public int GetEncodedSize(byte tagNumber, in CharacterString value) => AsduLength.Sum(tagNumber, value.ToBytes().Length);

    private static void Encode(ref AsduEncoder encoder, byte tagNumber, AsduTagClass tagClass, in CharacterString value)
    {
        var bytes = encoder.Encode(tagClass, tagNumber, value.ToBytes().Length);
        AsduEncoder.WriteCharacterString(bytes, value);
    }

    public void Encode(ref AsduEncoder encoder, in CharacterString value) => Encode(ref encoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application, in value);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in CharacterString value) => Encode(ref encoder, tagNumber, AsduTagClass.Context, in value);

    private static CharacterString Decode(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        var bytes = decoder.Decode(tagClass, tagNumber);
        return new CharacterString(bytes);
    }

    public CharacterString Decode(ref NativeReader decoder) => Decode(ref decoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application);

    public CharacterString Decode(ref NativeReader decoder, byte tagNumber) => Decode(ref decoder, tagNumber, AsduTagClass.Context);

    private static Optional<CharacterString> DecodeOptional(ref NativeReader decoder, byte tagNumber, AsduTagClass tagClass)
    {
        if (decoder.DecodeOptional(tagClass, tagNumber, out var bytes))
        {
            return new CharacterString(bytes);
        }

        return default;
    }

    public Optional<CharacterString> DecodeOptional(ref NativeReader decoder) => DecodeOptional(ref decoder, (byte)ApplicationTagNumber.CharacterString, AsduTagClass.Application);

    public Optional<CharacterString> DecodeOptional(ref NativeReader decoder, byte tagNumber) => DecodeOptional(ref decoder, tagNumber, AsduTagClass.Context);
}

