// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="uint"/> values.
/// </summary>
public sealed class UnsignedCodec :
    IAsduElementCodec<uint>,
    IAsduPrimitiveCodec<uint>
{
    /// <summary>
    /// Decodes a <see cref="uint"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static uint Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<UnsignedCodec, uint>(ref reader);

    /// <summary>
    /// Decodes a <see cref="uint"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static uint Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<UnsignedCodec, uint>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="uint"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static uint DecodeValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Unsigned8 => AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Unsigned16 => AsduBinaryPrimitives.ReadUnsigned16(source),
            AsduLength.Unsigned24 => AsduBinaryPrimitives.ReadUnsigned24(source),
            AsduLength.Unsigned32 => AsduBinaryPrimitives.ReadUnsigned32(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes a <see cref="uint"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in uint value)
        => AsduPrimitive.Encode<UnsignedCodec, uint>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="uint"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in uint value)
        => AsduPrimitive.Encode<UnsignedCodec, uint>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="uint"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in uint value)
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
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="uint"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in uint value)
        => AsduLength.FromUnsigned32(value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in uint value)
        => AsduPrimitive.GetEncodedLength<UnsignedCodec, uint>(value);

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in uint value, byte tagNumber)
        => AsduPrimitive.GetEncodedLength<UnsignedCodec, uint>(tagNumber, value);

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
        => ApplicationTagNumber.Unsigned;
}
