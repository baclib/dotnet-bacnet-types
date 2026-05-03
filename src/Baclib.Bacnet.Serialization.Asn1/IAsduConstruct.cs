// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: BSD-2-Clause
namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Defines the contract for BACnet constructs that can be serialized and deserialized using ASDU encoding.
/// </summary>
/// <typeparam name="T">The type implementing this interface (self-referential).</typeparam>
/// <remarks>
/// Types implementing this interface can be automatically encoded and decoded from BACnet ASDU format.
/// This interface uses the static abstract member pattern to provide type-safe deserialization.
/// </remarks>
public interface IAsduConstruct<T> where T : IAsduConstruct<T>
{
    /// <summary>
    /// Deserializes an instance of <typeparamref name="T"/> from the specified ASDU reader.
    /// </summary>
    /// <param name="decoder">The reader containing the encoded ASDU data.</param>
    /// <returns>The deserialized instance.</returns>
    static abstract T Deserialize(AsduDecoder decoder);

    /// <summary>
    /// Gets the size in bytes that this construct will occupy when serialized to ASDU format.
    /// </summary>
    /// <returns>The total size in bytes.</returns>
    int GetAsduSize();

    /// <summary>
    /// Serializes this construct to the specified ASDU writer.
    /// </summary>
    /// <param name="encoder">The writer to receive the encoded ASDU data.</param>
    void Serialize(ref AsduEncoder encoder);
}