// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="T.LoggingType"/> values.
/// </summary>
public sealed class LoggingTypeCodec :
    IAsduElementCodec<T.LoggingType>,
    IAsduPrimitiveCodec<T.LoggingType>
{
    /// <summary>
    /// Decodes an <see cref="T.LoggingType"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an enumerated primitive tag.</param>
    /// <returns>The decoded enumerated value.</returns>
    public static T.LoggingType Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LoggingTypeCodec, T.LoggingType>(ref reader);

    /// <summary>
    /// Decodes an <see cref="T.LoggingType"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an enumerated primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded enumerated value.</returns>
    public static T.LoggingType Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LoggingTypeCodec, T.LoggingType>(ref reader, tagNumber);

    /// <summary>
    /// Decodes an <see cref="T.LoggingType"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the enumerated value.</param>
    /// <returns>The decoded enumerated value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static T.LoggingType DecodeValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Enumerated8 => (T.LoggingType)AsduBinaryPrimitives.ReadUnsigned8(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes an <see cref="T.LoggingType"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in T.LoggingType value)
        => AsduPrimitive.Encode<LoggingTypeCodec, T.LoggingType>(ref writer, value);

    /// <summary>
    /// Encodes an <see cref="T.LoggingType"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.LoggingType value)
        => AsduPrimitive.Encode<LoggingTypeCodec, T.LoggingType>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes an <see cref="T.LoggingType"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in T.LoggingType value)
    {
        switch (destination.Length)
        {
            case AsduLength.Enumerated8:
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for an <see cref="T.LoggingType"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in T.LoggingType value)
        => AsduLength.FromUnsigned8((byte)value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in T.LoggingType value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in T.LoggingType value, byte tagNumber)
        => AsduLength.Sum(tagNumber, GetEncodedValueLength(value));

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
        => ApplicationTagNumber.Enumerated;
}
