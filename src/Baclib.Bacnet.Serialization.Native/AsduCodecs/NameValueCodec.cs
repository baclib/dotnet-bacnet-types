// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NameValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.NameValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.NameValue>
{
    public static bool Matches(ref NativeReader reader)
    {
        return reader.PeekTag((byte)0);
    }

    public static global::Baclib.Bacnet.Types.Application.NameValue Decode(ref NativeReader reader)
    {
        var _name = Asdu.DecodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref reader, 0);
        var _value = Asdu.DecodeOptional<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref reader);

        return new global::Baclib.Bacnet.Types.Application.NameValue
        {
            Name = _name,
            Value = _value
        };
    }

    public static global::Baclib.Bacnet.Types.Application.NameValue Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.NameValue value)
    {
        Asdu.EncodePrimitive<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(ref writer, 0, value.Name);
        if (value.Value.HasValue)
        {
            Asdu.EncodePrimitive<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(ref writer, value.Value.Value);
        }
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.NameValue value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NameValue value)
    {
        return Asdu.GetPrimitiveLength<CharacterStringCodec, global::Baclib.Bacnet.Types.Application.CharacterString>(0, value.Name) + (value.Value.HasValue ? Asdu.GetEncodedLength<AnyCodec, global::Baclib.Bacnet.Types.Application.Any>(value.Value.Value) : 0);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.NameValue value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag((byte)tagNumber);
}
