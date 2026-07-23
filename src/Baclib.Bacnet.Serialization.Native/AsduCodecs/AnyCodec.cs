// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

/// <summary>
/// Codec for the BACnet <c>ABSTRACT-SYNTAX.&amp;Type</c> ("Any").
/// </summary>
/// <remarks>
/// An <see cref="T.Any"/> is treated primarily as raw ASDU bytes: decoding captures one or more
/// complete elements verbatim, and encoding writes raw bytes back unchanged. When an
/// <see cref="T.Any"/> instead carries a materialized value, that value must be an
/// <see cref="T.AnyPrimitive"/>, which is encoded via <see cref="AnyPrimitiveCodec"/>.
/// </remarks>
public sealed class AnyCodec : IAsduElementCodec<T.Any>
{
    /// <inheritdoc/>
    public static bool Matches(ref AsduReader reader) => !reader.End;

    /// <summary>
    /// Decodes a single complete element at the current position, capturing it as raw bytes.
    /// </summary>
    public static T.Any Decode(ref AsduReader reader)
        => T.Any.FromEncoded(reader.ReadElement());

    /// <summary>
    /// Decodes a context-tag-enclosed value, capturing its entire raw content as bytes.
    /// </summary>
    public static T.Any Decode(ref AsduReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var content = reader.ReadRawUntilClosingTag(tagNumber);
        var any = T.Any.FromEncoded(content);
        reader.ReadClosingTag(tagNumber);
        return any;
    }

    /// <summary>
    /// Encodes an <see cref="T.Any"/>, writing raw bytes verbatim or delegating a materialized
    /// <see cref="T.AnyPrimitive"/> to <see cref="AnyPrimitiveCodec"/>.
    /// </summary>
    public static void Encode(ref AsduWriter writer, in T.Any value)
        => Encode(ref writer, value, registry: null);

    /// <summary>
    /// Encodes an <see cref="T.Any"/>, using static dispatch first and an optional runtime registry as fallback.
    /// </summary>
    /// <param name="writer">The writer receiving encoded bytes.</param>
    /// <param name="value">The Any value to encode.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static void Encode(ref AsduWriter writer, in T.Any value, AnyCodecRegistry? registry)
    {
        if (value.IsEncoded)
        {
            writer.WriteAny(value.EncodedData);
            return;
        }

        if (AnyStaticDispatch.TryEncode(ref writer, value.Value))
        {
            return;
        }

        if (registry is not null && registry.TryGetByType(value.ValueType, out var codec))
        {
            codec.Encode(ref writer, value.Value);
            return;
        }

        throw new NotSupportedException($"The type '{value.ValueType}' has no registered codec.");
    }

    /// <summary>
    /// Encodes an <see cref="T.Any"/> enclosed in the specified context tag.
    /// </summary>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
        => Encode(ref writer, tagNumber, value, registry: null);

    /// <summary>
    /// Encodes an <see cref="T.Any"/> enclosed in the specified context tag.
    /// </summary>
    /// <param name="writer">The writer receiving encoded bytes.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="value">The Any value to encode.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value, AnyCodecRegistry? registry)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value, registry);
        writer.WriteClosingTag(tagNumber);
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value)
        => GetEncodedLength(value, registry: null);

    /// <summary>
    /// Gets the encoded length of an <see cref="T.Any"/>, using static dispatch first and an optional runtime registry as fallback.
    /// </summary>
    /// <param name="value">The Any value to size.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static int GetEncodedLength(in T.Any value, AnyCodecRegistry? registry)
    {
        if (value.IsEncoded)
        {
            return value.EncodedData.Length;
        }

        if (AnyStaticDispatch.TryGetEncodedLength(value.Value, out var encodedLength))
        {
            return encodedLength;
        }

        if (registry is not null && registry.TryGetByType(value.ValueType, out var codec))
        {
            return codec.GetEncodedLength(value.Value);
        }

        throw new NotSupportedException($"The type '{value.ValueType}' has no registered codec.");
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value, byte tagNumber)
        => GetEncodedLength(value, tagNumber, registry: null);

    /// <summary>
    /// Gets the encoded length of a context-tagged <see cref="T.Any"/> value.
    /// </summary>
    /// <param name="value">The Any value to size.</param>
    /// <param name="tagNumber">The context tag number.</param>
    /// <param name="registry">Optional runtime registry used when no static codec matches.</param>
    public static int GetEncodedLength(in T.Any value, byte tagNumber, AnyCodecRegistry? registry)
        => 2 * AsduLength.FromTagNumber(tagNumber) + GetEncodedLength(value, registry);
}
