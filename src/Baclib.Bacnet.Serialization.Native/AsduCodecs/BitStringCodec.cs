// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="T.BitString"/> values.
/// </summary>
public sealed class BitStringCodec :
    IAsduElementCodec<T.BitString>,
    IAsduPrimitiveCodec<T.BitString>
{
    /// <summary>
    /// Decodes a <see cref="T.BitString"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static T.BitString Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<BitStringCodec, T.BitString>(ref reader);

    /// <summary>
    /// Decodes a <see cref="T.BitString"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static T.BitString Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<BitStringCodec, T.BitString>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="T.BitString"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    public static T.BitString DecodeValue(ReadOnlySpan<byte> source)
    {
        var bitString = new BitString(source);
        return new T.BitString(bitString.Flags, (ushort)bitString.Length);
    }

    /// <summary>
    /// Encodes a <see cref="T.BitString"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in T.BitString value)
        => AsduPrimitive.Encode<BitStringCodec, T.BitString>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="T.BitString"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.BitString value)
        => AsduPrimitive.Encode<BitStringCodec, T.BitString>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="T.BitString"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    public static void EncodeValue(Span<byte> destination, in T.BitString value)
    {
        int bitCount = value.Length;
        ArgumentOutOfRangeException.ThrowIfNegative(bitCount, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, ushort.MaxValue, nameof(value));
        var bitString = new BitString(value.Flags, checked((ushort)bitCount));
        bitString.CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="T.BitString"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in T.BitString value)
        => 1 + ((value.Length + 7) / 8);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in T.BitString value)
        => AsduPrimitive.GetEncodedLength<BitStringCodec, T.BitString>(value);

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in T.BitString value, byte tagNumber)
        => AsduPrimitive.GetEncodedLength<BitStringCodec, T.BitString>(tagNumber, value);

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
        => ApplicationTagNumber.BitString;

}
