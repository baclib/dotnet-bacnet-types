// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="CharacterString"/> values.
/// </summary>
public sealed class CharacterStringCodec :
    IAsduElementCodec<CharacterString>,
    IAsduPrimitiveCodec<CharacterString>
{
    /// <summary>
    /// Decodes a <see cref="CharacterString"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a character string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static CharacterString Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<CharacterStringCodec, CharacterString>(ref reader);

    /// <summary>
    /// Decodes a <see cref="CharacterString"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a character string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static CharacterString Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<CharacterStringCodec, CharacterString>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="CharacterString"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static CharacterString DecodeValue(ReadOnlySpan<byte> source)
    {
        return new CharacterString(source);
    }

    /// <summary>
    /// Encodes a <see cref="CharacterString"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in CharacterString value)
        => Asdu.EncodePrimitive<CharacterStringCodec, CharacterString>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="CharacterString"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in CharacterString value)
        => Asdu.EncodePrimitive<CharacterStringCodec, CharacterString>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="CharacterString"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in CharacterString value)
    {
        value.CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="CharacterString"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in CharacterString value)
        => value.Length;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in CharacterString value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in CharacterString value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Determines whether the next value in the reader matches this codec's application tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref NativeReader reader)
        => reader.PeekPrimitiveTag(TagNumber);

    /// <summary>
    /// Determines whether the next value in the reader matches a specific context tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekPrimitiveTag(tagNumber);

    /// <summary>
    /// Gets the BACnet application tag number handled by this codec.
    /// </summary>
    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.CharacterString;
}
