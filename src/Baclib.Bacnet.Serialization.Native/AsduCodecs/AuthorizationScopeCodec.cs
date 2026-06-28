// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuthorizationScopeCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuthorizationScope>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuthorizationScope>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag(AuthorizationScopeTStandardCodec.TagNumber);
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationScope Decode(ref NativeReader reader)
    {
        var _standard = Asdu.DecodePrimitive<AuthorizationScopeTStandardCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope.TStandard>(ref reader);
        var _extended = reader.PeekOpeningTag(0) ? Asdu.DecodeSequenceOf<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 0) : Optional<SequenceOf<global::Baclib.Bacnet.Types.Application.CharacterString>>.None;

        return new global::Baclib.Bacnet.Types.Application.AuthorizationScope
        {
            Standard = _standard,
            Extended = _extended
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuthorizationScope Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuthorizationScope value)
    {
        Asdu.EncodePrimitive<AuthorizationScopeTStandardCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope.TStandard>(ref writer, value.Standard);
        if (value.Extended.HasValue)
        {
            writer.WriteOpeningTag(0);
            foreach (var item in value.Extended.Value)
            {
                Asdu.EncodeElement<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 0, item);
            }
            writer.WriteClosingTag(0);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuthorizationScope value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationScope value)
    {
        return Asdu.GetEncodedLength<AuthorizationScopeTStandardCodec, global::Baclib.Bacnet.Types.Application.AuthorizationScope.TStandard>(value.Standard) + (value.Extended.HasValue ? (AsduLength.FromTagNumber((byte)0) + (value.Extended.Value.Items.Sum(static item => Asdu.GetElementLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(0, item))) + AsduLength.FromTagNumber((byte)0)) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuthorizationScope value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
