// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="T.AccessCredentialDisable"/> values.
/// </summary>
public sealed class AccessCredentialDisableCodec :
    IAsduElementCodec<T.AccessCredentialDisable>,
    IAsduPrimitiveCodec<T.AccessCredentialDisable>
{
    /// <summary>
    /// Decodes an <see cref="T.AccessCredentialDisable"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an enumerated primitive tag.</param>
    /// <returns>The decoded enumerated value.</returns>
    public static T.AccessCredentialDisable Decode(ref NativeReader reader)
        => Asdu.DecodePrimitive<AccessCredentialDisableCodec, T.AccessCredentialDisable>(ref reader);

    /// <summary>
    /// Decodes an <see cref="T.AccessCredentialDisable"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an enumerated primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded enumerated value.</returns>
    public static T.AccessCredentialDisable Decode(ref NativeReader reader, byte tagNumber)
        => Asdu.DecodePrimitive<AccessCredentialDisableCodec, T.AccessCredentialDisable>(ref reader, tagNumber);

    /// <summary>
    /// Decodes an <see cref="T.AccessCredentialDisable"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the enumerated value.</param>
    /// <returns>The decoded enumerated value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static T.AccessCredentialDisable DecodeValue(ReadOnlySpan<byte> source)
    {
        return source.Length switch
        {
            AsduLength.Enumerated8 => (T.AccessCredentialDisable)AsduBinaryPrimitives.ReadUnsigned8(source),
            AsduLength.Enumerated16 => (T.AccessCredentialDisable)AsduBinaryPrimitives.ReadUnsigned16(source),
            _ => throw new ArgumentOutOfRangeException(nameof(source))
        };
    }

    /// <summary>
    /// Encodes an <see cref="T.AccessCredentialDisable"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, in T.AccessCredentialDisable value)
        => Asdu.EncodePrimitive<AccessCredentialDisableCodec, T.AccessCredentialDisable>(ref writer, value);

    /// <summary>
    /// Encodes an <see cref="T.AccessCredentialDisable"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref NativeWriter writer, byte tagNumber, in T.AccessCredentialDisable value)
        => Asdu.EncodePrimitive<AccessCredentialDisableCodec, T.AccessCredentialDisable>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes an <see cref="T.AccessCredentialDisable"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in T.AccessCredentialDisable value)
    {
        switch (destination.Length)
        {
            case AsduLength.Enumerated8:
                AsduBinaryPrimitives.WriteUnsigned8(destination, (byte)value);
                break;
            case AsduLength.Enumerated16:
                AsduBinaryPrimitives.WriteUnsigned16(destination, (ushort)value);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(destination));
        }
    }

    /// <summary>
    /// Gets the encoded payload length for an <see cref="T.AccessCredentialDisable"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in T.AccessCredentialDisable value)
        => AsduLength.FromUnsigned16((ushort)value);

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.AccessCredentialDisable value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetLength(in T.AccessCredentialDisable value, byte tagNumber)
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
        => ApplicationTagNumber.Enumerated;
}
