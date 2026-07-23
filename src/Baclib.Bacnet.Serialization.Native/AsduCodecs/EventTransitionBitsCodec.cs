// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="EventTransitionBits"/> values.
/// </summary>
public sealed class EventTransitionBitsCodec :
    IAsduElementCodec<EventTransitionBits>,
    IAsduPrimitiveCodec<EventTransitionBits>
{
    /// <summary>
    /// Decodes a <see cref="EventTransitionBits"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="EventTransitionBits"/> primitive tag.</param>
    /// <returns>The decoded <see cref="EventTransitionBits"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static EventTransitionBits Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<EventTransitionBitsCodec, EventTransitionBits>(ref reader);

    /// <summary>
    /// Decodes a <see cref="EventTransitionBits"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="EventTransitionBits"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="EventTransitionBits"/> value.</returns>
    public static EventTransitionBits Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<EventTransitionBitsCodec, EventTransitionBits>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="EventTransitionBits"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="EventTransitionBits"/> value.</param>
    /// <returns>The decoded <see cref="EventTransitionBits"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static EventTransitionBits DecodeValue(ReadOnlySpan<byte> source)
    {
        var bitString = new BitString(source);
        if (bitString.Length != EventTransitionBits.FixedLength)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }
        var flags = ReadFlags(bitString.Flags);
        return new EventTransitionBits(flags);
    }

    /// <summary>
    /// Encodes a <see cref="EventTransitionBits"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in EventTransitionBits value)
        => AsduPrimitive.Encode<EventTransitionBitsCodec, EventTransitionBits>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="EventTransitionBits"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in EventTransitionBits value)
        => AsduPrimitive.Encode<EventTransitionBitsCodec, EventTransitionBits>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="EventTransitionBits"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in EventTransitionBits value)
    {
        var flagsBytes = WriteFlags(value.Flags, value.Length);
        new BitString(flagsBytes, (ushort)value.Length).CopyTo(destination);
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="EventTransitionBits"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in EventTransitionBits value)
        => 1 + (value.Length + 7) / 8;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in EventTransitionBits value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in EventTransitionBits value, byte tagNumber)
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


    private static byte ReadFlags(ReadOnlySpan<byte> source)
    {
        int bytesToRead = Math.Min(source.Length, 1);
        ulong flags = 0;

        for (int i = 0; i < bytesToRead; i++)
        {
            flags |= (ulong)source[i] << (i * 8);
        }

        return (byte)flags;
    }

    private static byte[] WriteFlags(byte value, int bitCount)
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
