// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="ulong"/> values.
/// </summary>
public sealed class Unsigned64Codec :
    IAsduElementCodec<ulong>,
    IAsduPrimitiveCodec<ulong>
{
    /// <summary>
    /// Decodes a <see cref="ulong"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static ulong Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<Unsigned64Codec, ulong>(ref reader);

    /// <summary>
    /// Decodes a <see cref="ulong"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static ulong Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<Unsigned64Codec, ulong>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="ulong"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static ulong DecodeValue(ReadOnlySpan<byte> source)
    { // infdo
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            AsduLength.Unsigned24 => AsduBinaryPrimitives.ReadUnsigned24(source),
            AsduLength.Unsigned32 => AsduBinaryPrimitives.ReadUnsigned32(source),
            AsduLength.Unsigned40 => AsduBinaryPrimitives.ReadUnsigned40(source),
            AsduLength.Unsigned48 => AsduBinaryPrimitives.ReadUnsigned48(source),
            AsduLength.Unsigned56 => AsduBinaryPrimitives.ReadUnsigned56(source),
            AsduLength.Unsigned64 => AsduBinaryPrimitives.ReadUnsigned64(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="ulong"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in ulong value)
        => Asdu.EncodePrimitive<Unsigned64Codec, ulong>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="ulong"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in ulong value)
        => Asdu.EncodePrimitive<Unsigned64Codec, ulong>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="ulong"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in ulong value)
    {
        switch (destination.Length)
        {
            case AsduLength.Unsigned8:
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            case AsduLength.Unsigned16:
                AsduBinaryPrimitives.WriteUnsigned16(destination, (ushort)value);
                break;
            case AsduLength.Unsigned24:
                AsduBinaryPrimitives.WriteUnsigned24(destination, (uint)value);
                break;
            case AsduLength.Unsigned32:
                AsduBinaryPrimitives.WriteUnsigned32(destination, (uint)value);
                break;
            case AsduLength.Unsigned40:
                AsduBinaryPrimitives.WriteUnsigned40(destination, (ulong)value);
                break;
            case AsduLength.Unsigned48:
                AsduBinaryPrimitives.WriteUnsigned48(destination, (ulong)value);
                break;
            case AsduLength.Unsigned56:
                AsduBinaryPrimitives.WriteUnsigned56(destination, (ulong)value);
                break;
            case AsduLength.Unsigned64:
                AsduBinaryPrimitives.WriteUnsigned64(destination, (ulong)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="ulong"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in ulong value)
        => AsduLength.FromUnsigned64(value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in ulong value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in ulong value, byte tagNumber)
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
        => ApplicationTagNumber.Unsigned;
}
