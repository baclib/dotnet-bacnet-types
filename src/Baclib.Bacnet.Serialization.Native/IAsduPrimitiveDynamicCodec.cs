// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Defines an instance-based codec contract for BACnet ASDU primitive values.
/// </summary>
/// <remarks>
/// Primitive codecs encode and decode payload bytes only. Tag header handling is
/// performed by the surrounding reader and writer operations.
/// This interface is intended for runtime-selected codecs where static abstract
/// interface members cannot be used directly.
/// </remarks>
/// <typeparam name="T">The CLR value type encoded and decoded by the codec.</typeparam>
public interface IAsduPrimitiveDynamicCodec<T>
{
    /// <summary>
    /// Decodes a primitive value from a payload span.
    /// </summary>
    /// <param name="source">The payload bytes without the ASDU tag header.</param>
    /// <returns>The decoded value.</returns>
    T DecodeValue(ReadOnlySpan<byte> source);

    /// <summary>
    /// Encodes a primitive value into a payload span.
    /// </summary>
    /// <param name="destination">The destination payload span without the ASDU tag header.</param>
    /// <param name="value">The value to encode.</param>
    void EncodeValue(Span<byte> destination, in T value);

    /// <summary>
    /// Gets the encoded payload length of a primitive value.
    /// </summary>
    /// <param name="value">The value to size.</param>
    /// <returns>The encoded payload length in bytes.</returns>
    int GetEncodedValueLength(in T value);

    /// <summary>
    /// Gets the BACnet application tag number handled by this codec.
    /// </summary>
    ApplicationTagNumber TagNumber { get; }
}
