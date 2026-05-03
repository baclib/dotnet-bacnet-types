// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Encodes a BACnet value into ASN.1 ASDU bytes using <see cref="AsduEncoder"/>.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public interface IAsn1Encoder<T>
{
    /// <summary>
    /// Gets the exact encoded size in bytes for <paramref name="value"/>.
    /// </summary>
    int GetEncodedSize(in T value);

    /// <summary>
    /// Gets the exact encoded size in bytes for <paramref name="value"/> when encoded with a context tag.
    /// </summary>
    /// <param name="contextTagNumber">The context tag number.</param>
    int GetEncodedSize(byte contextTagNumber, in T value);

    /// <summary>
    /// Writes the ASN.1 encoding of <paramref name="value"/> to <paramref name="encoder"/>.
    /// </summary>
    void Encode(ref AsduEncoder encoder, in T value);

    /// <summary>
    /// Writes the ASN.1 encoding of <paramref name="value"/> as a context-tagged value to <paramref name="encoder"/>.
    /// </summary>
    /// <param name="contextTagNumber">The context tag number.</param>
    void Encode(ref AsduEncoder encoder, byte contextTagNumber, in T value);
}
