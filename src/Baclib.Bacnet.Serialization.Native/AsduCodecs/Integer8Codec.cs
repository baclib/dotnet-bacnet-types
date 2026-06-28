// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="sbyte"/> values.
/// </summary>
public sealed class Integer8Codec :
    IAsduElementCodec<sbyte>,
    IAsduPrimitiveCodec<sbyte>
{
    /// <summary>
    /// Decodes a <see cref="sbyte"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static sbyte Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<Integer8Codec, sbyte>(ref reader);

    /// <summary>
    /// Decodes a <see cref="sbyte"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static sbyte Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<Integer8Codec, sbyte>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="sbyte"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static sbyte DecodeValue(ReadOnlySpan<byte> source)
    { // infdo
        return source.Length switch
        {
            AsduLength.Signed8 => AsduBinaryPrimitives.ReadInteger8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="sbyte"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in sbyte value)
        => Asdu.EncodePrimitive<Integer8Codec, sbyte>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="sbyte"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in sbyte value)
        => Asdu.EncodePrimitive<Integer8Codec, sbyte>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="sbyte"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in sbyte value)
    {
        switch (destination.Length)
        {
            case AsduLength.Signed8:
                AsduBinaryPrimitives.WriteInteger8(destination, (sbyte)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="sbyte"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in sbyte value)
        => AsduLength.FromInteger8(value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in sbyte value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in sbyte value, byte tagNumber)
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
        => ApplicationTagNumber.Signed;
}
