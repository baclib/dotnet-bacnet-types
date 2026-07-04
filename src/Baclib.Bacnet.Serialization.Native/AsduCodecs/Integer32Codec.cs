// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="int"/> values.
/// </summary>
public sealed class Integer32Codec :
    IAsduElementCodec<int>,
    IAsduPrimitiveCodec<int>
{
    /// <summary>
    /// Decodes a <see cref="int"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static int Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<Integer32Codec, int>(ref reader);

    /// <summary>
    /// Decodes a <see cref="int"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static int Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<Integer32Codec, int>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="int"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static int DecodeValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Signed8 => AsduBinaryPrimitives.ReadInteger8(source),
            AsduLength.Signed16 => AsduBinaryPrimitives.ReadInteger16(source),
            AsduLength.Signed24 => AsduBinaryPrimitives.ReadInteger24(source),
            AsduLength.Signed32 => AsduBinaryPrimitives.ReadInteger32(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="int"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in int value)
        => AsduPrimitive.Encode<Integer32Codec, int>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="int"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in int value)
        => AsduPrimitive.Encode<Integer32Codec, int>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="int"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in int value)
    {
        switch (destination.Length)
        {
            case AsduLength.Signed8:
                AsduBinaryPrimitives.WriteInteger8(destination, (sbyte)value);
                break;
            case AsduLength.Signed16:
                AsduBinaryPrimitives.WriteInteger16(destination, (short)value);
                break;
            case AsduLength.Signed24:
                AsduBinaryPrimitives.WriteInteger24(destination, (int)value);
                break;
            case AsduLength.Signed32:
                AsduBinaryPrimitives.WriteInteger32(destination, (int)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in int value)
        => AsduLength.FromInteger32(value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in int value)
        => AsduPrimitive.GetEncodedLength<Integer32Codec, int>(value);

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in int value, byte tagNumber)
        => AsduPrimitive.GetEncodedLength<Integer32Codec, int>(tagNumber, value);

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
