// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="bool"/> values.
/// </summary>
public sealed class BooleanCodec :
    IAsduElementCodec<bool>,
    IAsduPrimitiveCodec<bool>
{
    /// <summary>
    /// Decodes a <see cref="bool"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a boolean primitive tag.</param>
    /// <returns>The decoded boolean value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static bool Decode(ref NativeReader reader)
    {
        var value = reader.ReadByte();
        return value switch
        {
            0 => false,
            1 => true,
            _ => throw new FormatException()
        };
    }

    /// <summary>
    /// Decodes a <see cref="bool"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a boolean primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded boolean value.</returns>
    public static bool Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<BooleanCodec, bool>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="bool"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the boolean value.</param>
    /// <returns>The decoded boolean value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static bool DecodeValue(ReadOnlySpan<byte> source)
    {
        if (source.Length != AsduLength.Boolean)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }

        var value = source[0];
        return value switch
        {
            0 => false,
            1 => true,
            _ => throw new FormatException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="bool"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in bool value)
        => writer.WriteByte(value ? (byte)0x11 : (byte)0x10);

    /// <summary>
    /// Encodes a <see cref="bool"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in bool value)
        => Asdu.EncodePrimitive<BooleanCodec, bool>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="bool"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not 1.</exception>
    public static void EncodeValue(Span<byte> destination, in bool value)
    {
        if (destination.Length != AsduLength.Boolean)
        {
            throw new ArgumentOutOfRangeException(nameof(destination));
        }

        destination[0] = value ? (byte)1 : (byte)0;
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="bool"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in bool value)
        => AsduLength.Boolean;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in bool value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in bool value, byte tagNumber)
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
        => ApplicationTagNumber.Boolean;
}
