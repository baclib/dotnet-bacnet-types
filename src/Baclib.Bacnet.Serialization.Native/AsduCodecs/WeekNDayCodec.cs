// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> values.
/// </summary>
public sealed class WeekNDayCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.WeekNDay>,
    IAsduPrimitiveCodec<global::Baclib.Bacnet.Types.Application.WeekNDay>
{
    /// <summary>
    /// Decodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an octet-string primitive tag.</param>
    /// <returns>The decoded value.</returns>
    public static global::Baclib.Bacnet.Types.Application.WeekNDay Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref reader);

    /// <summary>
    /// Decodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at an octet-string primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded value.</returns>
    public static global::Baclib.Bacnet.Types.Application.WeekNDay Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the value.</param>
    /// <returns>The decoded value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not supported.</exception>
    public static global::Baclib.Bacnet.Types.Application.WeekNDay DecodeValue(ReadOnlySpan<byte> source)
    {
        if (source.Length != AsduLength.WeekNDay)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }

        var value = new global::Baclib.Bacnet.Types.Application.WeekNDay(source[0], source[1], source[2]);
        return value.IsValid ? value : throw new ArgumentOutOfRangeException(nameof(source));
    }

    /// <summary>
    /// Encodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.WeekNDay value)
        => AsduPrimitive.Encode<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.WeekNDay value)
        => AsduPrimitive.Encode<WeekNDayCodec, global::Baclib.Bacnet.Types.Application.WeekNDay>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload bytes.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in global::Baclib.Bacnet.Types.Application.WeekNDay value)
    {
        if (destination.Length != AsduLength.WeekNDay)
        {
            throw new ArgumentOutOfRangeException(nameof(destination));
        }

        destination[0] = value.Month;
        destination[1] = value.Week;
        destination[2] = value.DayOfWeek;
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="global::Baclib.Bacnet.Types.Application.WeekNDay"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in global::Baclib.Bacnet.Types.Application.WeekNDay value)
        => AsduLength.WeekNDay;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WeekNDay value)
        => AsduLength.Sum(TagNumber, GetEncodedValueLength(value));

    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.WeekNDay value, byte tagNumber)
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
        => ApplicationTagNumber.OctetString;
}
