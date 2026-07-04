// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Defines a static codec contract for BACnet ASDU primitives.
/// </summary>
/// <remarks>
/// Primitive codecs only decode and encode the data bytes of a primitive value.
/// Tag header handling is performed by the surrounding reader and writer operations.
/// </remarks>
/// <typeparam name="T">The CLR value type encoded and decoded by the codec.</typeparam>
public interface IAsduPrimitiveCodec<T>
{
    /// <summary>
    /// Decodes a primitive value from a data span.
    /// </summary>
    /// <param name="source">The data bytes without the ASDU tag header.</param>
    /// <returns>The decoded value.</returns>
    static abstract T DecodeValue(ReadOnlySpan<byte> source);

    /// <summary>
    /// Encodes a primitive value into a data span.
    /// </summary>
    /// <param name="destination">The destination data span without the ASDU tag header.</param>
    /// <param name="value">The value to encode.</param>
    static abstract void EncodeValue(Span<byte> destination, in T value);

    /// <summary>
    /// Gets the encoded data length of a primitive value.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <returns>The encoded data length in bytes.</returns>
    static abstract int GetEncodedValueLength(in T value);

    /// <summary>
    /// Gets the BACnet application tag number handled by this codec.
    /// </summary>
    static abstract ApplicationTagNumber TagNumber { get; }
}
