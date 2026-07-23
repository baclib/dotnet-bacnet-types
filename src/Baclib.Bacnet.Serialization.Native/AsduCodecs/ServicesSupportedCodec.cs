// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="ServicesSupported"/> values.
/// </summary>
public sealed class ServicesSupportedCodec :
    IAsduElementCodec<ServicesSupported>,
    IAsduPrimitiveCodec<ServicesSupported>
{
    /// <summary>
    /// Decodes a <see cref="ServicesSupported"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="ServicesSupported"/> primitive tag.</param>
    /// <returns>The decoded <see cref="ServicesSupported"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static ServicesSupported Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<ServicesSupportedCodec, ServicesSupported>(ref reader);

    /// <summary>
    /// Decodes a <see cref="ServicesSupported"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="ServicesSupported"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="ServicesSupported"/> value.</returns>
    public static ServicesSupported Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<ServicesSupportedCodec, ServicesSupported>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="ServicesSupported"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="ServicesSupported"/> value.</param>
    /// <returns>The decoded <see cref="ServicesSupported"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static ServicesSupported DecodeValue(ReadOnlySpan<byte> source)
    {
        var bitString = new BitString(source);
        return new ServicesSupported(bitString.Flags, (ushort)bitString.Length);
    }

    /// <summary>
    /// Encodes a <see cref="ServicesSupported"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in ServicesSupported value)
        => AsduPrimitive.Encode<ServicesSupportedCodec, ServicesSupported>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="ServicesSupported"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in ServicesSupported value)
        => AsduPrimitive.Encode<ServicesSupportedCodec, ServicesSupported>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="ServicesSupported"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in ServicesSupported value)
    {
        new BitString(value.Flags, (ushort)value.Length).CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="ServicesSupported"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in ServicesSupported value)
        => 1 + (value.Length + 7) / 8;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in ServicesSupported value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in ServicesSupported value, byte tagNumber)
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
        => ApplicationTagNumber.BitString;

}
