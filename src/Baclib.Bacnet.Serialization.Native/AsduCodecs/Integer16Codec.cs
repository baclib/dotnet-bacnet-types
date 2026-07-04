// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="short"/> values.
/// </summary>
public sealed class Integer16Codec :
    IAsduElementCodec<short>,
    IAsduPrimitiveCodec<short>
{
    /// <summary>
    /// Decodes a <see cref="short"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static short Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<Integer16Codec, short>(ref reader);

    /// <summary>
    /// Decodes a <see cref="short"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static short Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<Integer16Codec, short>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="short"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static short DecodeValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Signed8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Signed16 => AsduBinaryPrimitives.ReadInteger16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="short"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in short value)
        => AsduPrimitive.Encode<Integer16Codec, short>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="short"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in short value)
        => AsduPrimitive.Encode<Integer16Codec, short>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="short"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in short value)
    {
        switch (destination.Length)
        {
            case AsduLength.Signed8:
                AsduBinaryPrimitives.WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Signed16:
                AsduBinaryPrimitives.WriteInteger16(destination, (short)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="short"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in short value)
        => AsduLength.FromInteger16(value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in short value)
        => AsduPrimitive.GetEncodedLength<Integer16Codec, short>(value);

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in short value, byte tagNumber)
        => AsduPrimitive.GetEncodedLength<Integer16Codec, short>(tagNumber, value);

    /// <summary>
    /// Determines whether the next value in the reader matches this codec's application tag.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> when the next tag matches; otherwise, <see langword="false"/>.</returns>
    public static bool Matches(ref AsduReader reader)
        => reader.PeekApplicationTag(TagNumber);

    /// <summary>
    /// Gets the BACnet application tag number handled by this codec.
    /// </summary>
    public static ApplicationTagNumber TagNumber
        => ApplicationTagNumber.Signed;
}
