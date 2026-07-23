// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="Date"/> values.
/// </summary>
public sealed class DateCodec :
    IAsduElementCodec<Date>,
    IAsduPrimitiveCodec<Date>
{
    /// <summary>
    /// Decodes a <see cref="Date"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="Date"/> primitive tag.</param>
    /// <returns>The decoded <see cref="Date"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static Date Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<DateCodec, Date>(ref reader);

    /// <summary>
    /// Decodes a <see cref="Date"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="Date"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="Date"/> value.</returns>
    public static Date Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<DateCodec, Date>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="Date"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="Date"/> value.</param>
    /// <returns>The decoded <see cref="Date"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static Date DecodeValue(ReadOnlySpan<byte> source)
    {
        if (source.Length != AsduLength.Date)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }

        var year = source[0];
        var month = source[1];
        var day = source[2];
        var dayOfWeek = source[3];

        return new Date(year, month, day, dayOfWeek);
    }

    /// <summary>
    /// Encodes a <see cref="Date"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in Date value)
        => AsduPrimitive.Encode<DateCodec, Date>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="Date"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in Date value)
        => AsduPrimitive.Encode<DateCodec, Date>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="Date"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in Date value)
    {
        if (destination.Length != AsduLength.Date)
        {
            throw new ArgumentOutOfRangeException(nameof(destination));
        }

        destination[0] = value.Year;
        destination[1] = value.Month;
        destination[2] = value.Day;
        destination[3] = value.DayOfWeek;
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="Date"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in Date value)
        => AsduLength.Date;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in Date value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in Date value, byte tagNumber)
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
        => ApplicationTagNumber.DatePattern;

}
