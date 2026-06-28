// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="T.AuditOperationFlags"/> values.
/// </summary>
public sealed class AuditOperationFlagsCodec :
    IAsduElementCodec<T.AuditOperationFlags>,
    IAsduPrimitiveCodec<T.AuditOperationFlags>
{
    /// <summary>
    /// Decodes a <see cref="T.AuditOperationFlags"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static T.AuditOperationFlags Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<AuditOperationFlagsCodec, T.AuditOperationFlags>(ref reader);

    /// <summary>
    /// Decodes a <see cref="T.AuditOperationFlags"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a bit string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static T.AuditOperationFlags Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<AuditOperationFlagsCodec, T.AuditOperationFlags>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="T.AuditOperationFlags"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    public static T.AuditOperationFlags DecodeValue(ReadOnlySpan<byte> source)
    {
        var bitString = new BitString(source);
        var flags = ReadFlags(bitString.Flags);
        return new T.AuditOperationFlags(flags, (byte)bitString.Length);
    }

    /// <summary>
    /// Encodes a <see cref="T.AuditOperationFlags"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in T.AuditOperationFlags value)
        => Asdu.EncodePrimitive<AuditOperationFlagsCodec, T.AuditOperationFlags>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="T.AuditOperationFlags"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in T.AuditOperationFlags value)
        => Asdu.EncodePrimitive<AuditOperationFlagsCodec, T.AuditOperationFlags>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="T.AuditOperationFlags"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    public static void EncodeValue(Span<byte> destination, in T.AuditOperationFlags value)
    {
        int bitCount = value.Length;
        ArgumentOutOfRangeException.ThrowIfNegative(bitCount, nameof(value));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(bitCount, ushort.MaxValue, nameof(value));
        var flagsBytes = WriteFlags(value.Flags, bitCount);
        var bitString = new BitString(flagsBytes, checked((ushort)bitCount));
        bitString.CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="T.AuditOperationFlags"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in T.AuditOperationFlags value)
        => 1 + ((value.Length + 7) / 8);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.AuditOperationFlags value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.AuditOperationFlags value, byte tagNumber)
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

    private static ulong ReadFlags(ReadOnlySpan<byte> source)
    {
        int bytesToRead = Math.Min(source.Length, 8);
        ulong flags = 0;

        for (int i = 0; i < bytesToRead; i++)
        {
            flags |= (ulong)source[i] << (i * 8);
        }

        return (ulong)flags;
    }

    private static byte[] WriteFlags(ulong value, int bitCount)
    {
        int byteCount = (bitCount + 7) / 8;
        var flags = new byte[byteCount];
        ulong source = value;

        for (int i = 0; i < byteCount; i++)
        {
            flags[i] = (byte)(source >> (i * 8));
        }

        return flags;
    }

}
