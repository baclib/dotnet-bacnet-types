// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuthorizationServer as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationServer
{
    /// <summary>
    /// The identifier of the authorization server.
    /// </summary>
    public required Unsigned32 AuthServer { get; init; }
    
    /// <summary>
    /// The first cryptographic signing key used to verify tokens from this server.
    /// </summary>
    public Optional<OctetString> SigningKey1 { get; init; }

    /// <summary>
    /// The second cryptographic signing key, allowing for key rotation.
    /// </summary>
    public Optional<OctetString> SigningKey2 { get; init; }
}
