// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Defines a static codec contract for BACnet ASDU elements.
/// </summary>
/// <remarks>
/// Element codecs can represent primitive or constructed payloads and may be used
/// in untagged, context-tagged, optional, and sequence contexts.
/// </remarks>
/// <typeparam name="T">The CLR value type encoded and decoded by the codec.</typeparam>
public interface IAsduElementCodec<T>
{
    /// <summary>
    /// Decodes an element from the current reader position.
    /// </summary>
    /// <param name="reader">The reader positioned at the element start.</param>
    /// <returns>The decoded value.</returns>
    static abstract T Decode(ref AsduReader reader);

    /// <summary>
    /// Decodes an element that is expected to use the provided context tag number.
    /// </summary>
    /// <param name="reader">The reader positioned at the element start.</param>
    /// <param name="tagNumber">The expected BACnet context tag number.</param>
    /// <returns>The decoded value.</returns>
    static abstract T Decode(ref AsduReader reader, byte tagNumber);

    /// <summary>
    /// Encodes an element at the current writer position.
    /// </summary>
    /// <param name="writer">The writer to encode to.</param>
    /// <param name="value">The value to encode.</param>
    static abstract void Encode(ref AsduWriter writer, in T value);

    /// <summary>
    /// Encodes an element using the provided context tag number.
    /// </summary>
    /// <param name="writer">The writer to encode to.</param>
    /// <param name="tagNumber">The BACnet context tag number to write.</param>
    /// <param name="value">The value to encode.</param>
    static abstract void Encode(ref AsduWriter writer, byte tagNumber, in T value);

    /// <summary>
    /// Gets the total encoded length of an untagged element.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <returns>The encoded length in bytes.</returns>
    static abstract int GetEncodedLength(in T value);

    /// <summary>
    /// Gets the total encoded length of an element when encoded with a context tag.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <param name="tagNumber">The BACnet context tag number to write.</param>
    /// <returns>The encoded length in bytes.</returns>
    static abstract int GetEncodedLength(in T value, byte tagNumber);

    /// <summary>
    /// Determines whether the next bytes in the reader can be decoded by this codec.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> if the next element matches this codec; otherwise <see langword="false"/>.</returns>
    static abstract bool Matches(ref AsduReader reader);
}
