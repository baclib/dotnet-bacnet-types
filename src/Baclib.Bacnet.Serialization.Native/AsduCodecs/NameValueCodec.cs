// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class NameValueCodec :
    IAsduElementCodec<T::NameValue>,
    IAsduConstructedCodec<T::NameValue>
{
    public static T::NameValue Decode(ref AsduReader reader)
    {
        return new T::NameValue
        {
            Name = AsduElement.Decode<CharacterStringCodec, T::CharacterString>(ref reader, 0),
            Value = AsduElement.DecodeOptional<AnyCodec, T::Any>(ref reader)
        };
    }

    public static T::NameValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<NameValueCodec, T::NameValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::NameValue value)
    {
        AsduElement.Encode<CharacterStringCodec, T::CharacterString>(ref writer, 0, value.Name);
        AsduElement.EncodeOptional<AnyCodec, T::Any>(ref writer, value.Value);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::NameValue value)
        => AsduConstructed.Encode<NameValueCodec, T::NameValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::NameValue value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<CharacterStringCodec, T::CharacterString>(0, value.Name);
        length += AsduElement.GetOptionalEncodedLength<AnyCodec, T::Any>(value.Value);
        return length;
    }

    public static int GetEncodedLength(in T::NameValue value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<NameValueCodec, T::NameValue>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
