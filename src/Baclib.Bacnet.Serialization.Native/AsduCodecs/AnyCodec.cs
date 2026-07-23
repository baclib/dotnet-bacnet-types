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
    {
        if (value.IsEncoded)
        {
            writer.WriteAny(value.RawData);
            return;
        }

        if (value.TryGetValue<T.AnyPrimitive>(out var primitive))
        {
            AnyPrimitiveCodec.Encode(ref writer, primitive);
            return;
        }

        throw new NotSupportedException(
            $"An Any holding a materialized value of type '{value.ValueType}' cannot be encoded. " +
            "Wrap it as an AnyPrimitive or provide pre-encoded bytes via Any.FromEncoded.");
    }

    /// <summary>
    /// Encodes an <see cref="T.Any"/> enclosed in the specified context tag.
    /// </summary>
    public static void Encode(ref AsduWriter writer, byte tagNumber, in T.Any value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value)
    {
        if (value.IsEncoded)
        {
            return value.RawData.Length;
        }

        if (value.TryGetValue<T.AnyPrimitive>(out var primitive))
        {
            return AnyPrimitiveCodec.GetEncodedLength(primitive);
        }

        throw new NotSupportedException(
            $"An Any holding a materialized value of type '{value.ValueType}' cannot be sized. " +
            "Wrap it as an AnyPrimitive or provide pre-encoded bytes via Any.FromEncoded.");
    }

    /// <inheritdoc/>
    public static int GetEncodedLength(in T.Any value, byte tagNumber)
        => 2 * AsduLength.FromTagNumber(tagNumber) + GetEncodedLength(value);
}
