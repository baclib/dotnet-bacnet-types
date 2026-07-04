// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Defines an instance-based codec contract for BACnet ASDU elements.
/// </summary>
/// <remarks>
/// Element codecs can represent primitive or constructed payloads and may be used
/// in untagged, context-tagged, optional, and sequence contexts.
/// This interface is intended for runtime-selected codecs where static abstract
/// interface members cannot be used directly.
/// </remarks>
/// <typeparam name="T">The CLR value type encoded and decoded by the codec.</typeparam>
public interface IAsduElementDynamicCodec<T>
{
    /// <summary>
    /// Decodes an element from the current reader position.
    /// </summary>
    /// <param name="reader">The reader positioned at the element start.</param>
    /// <returns>The decoded value.</returns>
    T Decode(ref AsduReader reader);

    /// <summary>
    /// Encodes an element at the current writer position.
    /// </summary>
    /// <param name="writer">The writer to encode to.</param>
    /// <param name="value">The value to encode.</param>
    void Encode(ref AsduWriter writer, in T value);

    /// <summary>
    /// Gets the total encoded length of an untagged element.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <returns>The encoded length in bytes.</returns>
    int GetLength(in T value);

    /// <summary>
    /// Determines whether the next bytes in the reader can be decoded by this codec.
    /// </summary>
    /// <param name="reader">The reader to inspect.</param>
    /// <returns><see langword="true"/> if the next element matches this codec; otherwise <see langword="false"/>.</returns>
    bool Matches(ref AsduReader reader);
}
