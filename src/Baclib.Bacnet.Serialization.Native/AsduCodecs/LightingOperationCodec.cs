// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="LightingOperation"/> values.
/// </summary>
public sealed class LightingOperationCodec :
    IAsduElementCodec<LightingOperation>,
    IAsduPrimitiveCodec<LightingOperation>
{
    /// <summary>
    /// Decodes a <see cref="LightingOperation"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="LightingOperation"/> primitive tag.</param>
    /// <returns>The decoded <see cref="LightingOperation"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static LightingOperation Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingOperationCodec, LightingOperation>(ref reader);

    /// <summary>
    /// Decodes a <see cref="LightingOperation"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="LightingOperation"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="LightingOperation"/> value.</returns>
    public static LightingOperation Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingOperationCodec, LightingOperation>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="LightingOperation"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="LightingOperation"/> value.</param>
    /// <returns>The decoded <see cref="LightingOperation"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static LightingOperation DecodeValue(ReadOnlySpan<byte> source)
    {
        var value = AsduBinaryPrimitives.ReadUnsigned16(source);
        return (LightingOperation)value;
    }

    /// <summary>
    /// Encodes a <see cref="LightingOperation"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in LightingOperation value)
        => AsduPrimitive.Encode<LightingOperationCodec, LightingOperation>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="LightingOperation"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in LightingOperation value)
        => AsduPrimitive.Encode<LightingOperationCodec, LightingOperation>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="LightingOperation"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in LightingOperation value)
    {
        switch (destination.Length)
        {
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="LightingOperation"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in LightingOperation value)
        => AsduLength.FromUnsigned16((ushort)value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in LightingOperation value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in LightingOperation value, byte tagNumber)
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
        => ApplicationTagNumber.Enumerated;

}
