// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationScopeDescriptionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(CharacterStringCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription Decode(ref NativeReader reader)
    {
        var _name = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);
        var _description = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription
        {
            Name = _name,
            Description = _description
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription value)
    {
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.Name);
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, value.Description);
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription value)
    {
        return Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.Name) + Asdu.GetEncodedLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(value.Description);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationScopeDescription value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
