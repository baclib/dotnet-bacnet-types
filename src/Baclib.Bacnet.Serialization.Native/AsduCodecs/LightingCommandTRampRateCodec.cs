// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

//using T = Baclib.Bacnet.Types.Application;

using Action = Baclib.Bacnet.Types.Application.Action;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Provides BACnet ASDU primitive decoding and encoding for <see cref="LightingCommand.TRampRate"/> values.
/// </summary>
public sealed class LightingCommandTRampRateCodec :
    IAsduElementCodec<LightingCommand.TRampRate>,
    IAsduPrimitiveCodec<LightingCommand.TRampRate>
{
    /// <summary>
    /// Decodes a <see cref="LightingCommand.TRampRate"/> value from the current reader position using the application tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="LightingCommand.TRampRate"/> primitive tag.</param>
    /// <returns>The decoded <see cref="LightingCommand.TRampRate"/> value.</returns>
    /// <exception cref="FormatException">Thrown when the encoded value is not valid.</exception>
    public static LightingCommand.TRampRate Decode(ref AsduReader reader)
        => AsduPrimitive.Decode<LightingCommandTRampRateCodec, LightingCommand.TRampRate>(ref reader);

    /// <summary>
    /// Decodes a <see cref="LightingCommand.TRampRate"/> value from the current reader position using a specific context tag.
    /// </summary>
    /// <param name="reader">The reader positioned at a <see cref="LightingCommand.TRampRate"/> primitive tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The decoded <see cref="LightingCommand.TRampRate"/> value.</returns>
    public static LightingCommand.TRampRate Decode(ref AsduReader reader, byte tagNumber)
        => AsduPrimitive.Decode<LightingCommandTRampRateCodec, LightingCommand.TRampRate>(ref reader, tagNumber);

    /// <summary>
    /// Decodes a <see cref="LightingCommand.TRampRate"/> value from raw encoded bytes.
    /// </summary>
    /// <param name="source">The source payload bytes for the <see cref="LightingCommand.TRampRate"/> value.</param>
    /// <returns>The decoded <see cref="LightingCommand.TRampRate"/> value.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="source"/> length is not 1.</exception>
    /// <exception cref="FormatException">Thrown when the encoded value is not 0 or 1.</exception>
    public static LightingCommand.TRampRate DecodeValue(ReadOnlySpan<byte> source)
    {
        if (source.Length != AsduLength.Real)
        {
            throw new ArgumentOutOfRangeException(nameof(source));
        }

        return (LightingCommand.TRampRate)AsduBinaryPrimitives.ReadReal(source);
    }

    /// <summary>
    /// Encodes a <see cref="LightingCommand.TRampRate"/> value using the application tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, in LightingCommand.TRampRate value)
        => AsduPrimitive.Encode<LightingCommandTRampRateCodec, LightingCommand.TRampRate>(ref writer, value);

    /// <summary>
    /// Encodes a <see cref="LightingCommand.TRampRate"/> value using a specific context tag.
    /// </summary>
    /// <param name="writer">The writer receiving the encoded value.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The value to encode.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in LightingCommand.TRampRate value)
        => AsduPrimitive.Encode<LightingCommandTRampRateCodec, LightingCommand.TRampRate>(ref writer, tagNumber, value);

    /// <summary>
    /// Encodes a <see cref="LightingCommand.TRampRate"/> value into an already allocated payload span.
    /// </summary>
    /// <param name="destination">The destination payload span.</param>
    /// <param name="value">The value to encode.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="destination"/> length is not supported.</exception>
    public static void EncodeValue(Span<byte> destination, in LightingCommand.TRampRate value)
    {
        if (destination.Length != AsduLength.Real)
        {
            throw new ArgumentOutOfRangeException(nameof(destination));
        }

        throw new NotImplementedException("Encoding of Real values is not implemented yet.");
    }

    /// <summary>
    /// Gets the encoded payload length for a <see cref="LightingCommand.TRampRate"/> value.
    /// </summary>
    /// <param name="value">The value whose payload length is requested.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    public static int GetEncodedValueLength(in LightingCommand.TRampRate value)
        => AsduLength.Real;

    /// <summary>
    /// Gets the total encoded length including the application tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in LightingCommand.TRampRate value)
        => AsduLength.FromTagAndData(TagNumber, GetEncodedValueLength(value));


    /// <summary>
    /// Gets the total encoded length including a specific context tag.
    /// </summary>
    /// <param name="value">The value whose total encoded length is requested.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <returns>The total encoded length in bytes.</returns>
    public static int GetEncodedLength(in LightingCommand.TRampRate value, byte tagNumber)
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
        => ApplicationTagNumber.Real;

}
