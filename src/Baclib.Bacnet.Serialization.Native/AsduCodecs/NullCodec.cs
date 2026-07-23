// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="Null"/> values.
/// </summary>
public sealed class NullCodec :
    IAsduElementCodec<Null>,
    IAsduPrimitiveCodec<Null>
{
    /// <summary>
    /// Decodes a <see cref="Null"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="Null"/> primitive tag.</param>
    /// <returns>The decoded <see cref="Null"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static Null Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<NullCodec, Null>(ref reader);

    /// <summary>
    /// Decodes a <see cref="Null"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="Null"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="Null"/> value.</returns>
    public static Null Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<NullCodec, Null>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="Null"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="Null"/> value.</param>
    /// <returns>The decoded <see cref="Null"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static Null DecodeValue(ReadOnlySpan<byte> source)
    {
        if (source.Length != AsduLength.Null)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }

    return Null.Value;
    }

    /// <summary>
    /// Encodes a <see cref="Null"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in Null value)
        => AsduPrimitive.Encode<NullCodec, Null>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="Null"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in Null value)
        => AsduPrimitive.Encode<NullCodec, Null>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="Null"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in Null value)
    {
        if (destination.Length != AsduLength.Null)
        {
            throw new ArgumentOutOfRangeException(nameof(destination));
        }

        // No contents to encode
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="Null"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in Null value)
        => AsduLength.Null;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in Null value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in Null value, byte tagNumber)
        => AsduLength.FromTagAndData(tagNumber, GetEncodedValueLength(value));

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
        => ApplicationTagNumber.Null;

}
