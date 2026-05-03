// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Decodes a BACnet value from ASN.1 ASDU bytes using <see cref="AsduDecoder"/>.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public interface IAsn1Decoder<T>
{
    /// <summary>
    /// Decodes a value from the current reader position.
    /// </summary>
    T Decode(ref AsduDecoder decoder);

    /// <summary>
    /// Decodes a context-tagged value from the current reader position.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    T Decode(ref AsduDecoder decoder, byte tagNumber);

    /// <summary>
    /// Decodes an optional value of type T from the specified decoder.
    /// </summary>
    /// <param name="decoder">A reference to the AsduDecoder instance used to read the encoded data.</param>
    /// <returns>An Optional<T> representing the decoded value. If the encoded data does not contain a value, the Optional<T>
    /// will be empty.</returns>
    Optional<T> DecodeOptional(ref AsduDecoder decoder);

    /// <summary>
    /// Decodes an optional value of type T from the specified decoder using the given tag number.
    /// </summary>
    /// <param name="decoder">A reference to the AsduDecoder instance used to read the encoded data.</param>
    /// <param name="tagNumber">The tag number that identifies the optional value to decode.</param>
    /// <returns>An Optional<T> containing the decoded value if present; otherwise, an empty Optional<T>.</returns>
    Optional<T> DecodeOptional(ref AsduDecoder decoder, byte tagNumber);
}
