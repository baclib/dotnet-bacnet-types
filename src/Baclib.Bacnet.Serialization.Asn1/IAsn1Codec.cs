// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Combines ASN.1 encoding and decoding for a specific BACnet value type.
/// </summary>
/// <typeparam name="T">BACnet value type.</typeparam>
public interface IAsn1Codec<T> : IAsn1Encoder<T>, IAsn1Decoder<T>
{
}
