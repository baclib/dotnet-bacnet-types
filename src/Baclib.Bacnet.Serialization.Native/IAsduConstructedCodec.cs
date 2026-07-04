// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Defines a static codec contract for BACnet ASDU constructed values.
/// </summary>
/// <remarks>
/// Constructed codecs operate on constructed contents. Opening and closing tags
/// are handled by the caller when applicable.
/// </remarks>
/// <typeparam name="T">The CLR value type encoded and decoded by the codec.</typeparam>
public interface IAsduConstructedCodec<T>
{
    /// <summary>
    /// Decodes constructed contents from the current reader position.
    /// </summary>
    /// <param name="reader">The reader positioned at constructed contents.</param>
    /// <returns>The decoded value.</returns>
    static abstract T Decode(ref AsduReader reader);

    /// <summary>
    /// Encodes constructed contents at the current writer position.
    /// </summary>
    /// <param name="writer">The writer to encode to.</param>
    /// <param name="value">The value to encode.</param>
    static abstract void Encode(ref AsduWriter writer, in T value);

    /// <summary>
    /// Gets the encoded length of constructed contents.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <returns>The encoded length in bytes.</returns>
    static abstract int GetEncodedLength(in T value);

    /// <summary>
    /// Determines whether the next bytes in the reader can be decoded by this codec.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> if the next element matches this codec; otherwise <see langword="false"/>.</returns>
    static abstract bool Matches(ref AsduReader reader);
}
