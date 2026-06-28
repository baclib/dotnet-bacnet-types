// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="T.ObjectTypesSupported"/> values.
/// </summary>
public sealed class ObjectTypesSupportedCodec :
    IAsduElementCodec<T.ObjectTypesSupported>,
    IAsduPrimitiveCodec<T.ObjectTypesSupported>
{
    /// <summary>
    /// Decodes a <see cref="T.ObjectTypesSupported"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static T.ObjectTypesSupported Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<ObjectTypesSupportedCodec, T.ObjectTypesSupported>(ref reader);

    /// <summary>
    /// Decodes a <see cref="T.ObjectTypesSupported"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static T.ObjectTypesSupported Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<ObjectTypesSupportedCodec, T.ObjectTypesSupported>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="T.ObjectTypesSupported"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    public static T.ObjectTypesSupported DecodeValue(ReadOnlySpan<byte> source)
    {
        var bitString = new BitString(source);
        return new T.ObjectTypesSupported(bitString.Flags, (ushort)bitString.Length);
    }

    /// <summary>
    /// Encodes a <see cref="T.ObjectTypesSupported"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in T.ObjectTypesSupported value)
        => Asdu.EncodePrimitive<ObjectTypesSupportedCodec, T.ObjectTypesSupported>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="T.ObjectTypesSupported"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in T.ObjectTypesSupported value)
        => Asdu.EncodePrimitive<ObjectTypesSupportedCodec, T.ObjectTypesSupported>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="T.ObjectTypesSupported"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    public static void EncodeValue(Span<byte> destination, in T.ObjectTypesSupported value)
    {
        int bitCount = value.Length;
        ArgumentOutOfRangeException.ThrowIfNegative(bitCount, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, ushort.MaxValue, nameof(value));
        var bitString = new BitString(value.Flags, checked((ushort)bitCount));
        bitString.CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="T.ObjectTypesSupported"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in T.ObjectTypesSupported value)
        => 1 + ((value.Length + 7) / 8);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.ObjectTypesSupported value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.ObjectTypesSupported value, byte tagNumber)
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
        => ApplicationTagNumber.BitString;

}
