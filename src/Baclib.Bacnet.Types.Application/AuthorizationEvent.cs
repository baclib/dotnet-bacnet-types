// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthorizationEvent as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationEvent
{
    /// <summary>
    /// The date and time when the authorization event occurred.
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// The network address of the client requesting authorization.
    /// </summary>
    public required Address Address { get; init; }

    /// <summary>
    /// Information about the authenticated client.
    /// </summary>
    public Optional<AuthenticationClient> Client { get; init; }

    /// <summary>
    /// The access token presented for authorization.
    /// </summary>
    public Optional<AccessToken> Token { get; init; }

    /// <summary>
    /// The authorization decision that was made.
    /// </summary>
    public required AuthorizationDecision Decision { get; init; }

    /// <summary>
    /// Additional details about the authorization decision.
    /// </summary>
    public Optional<CharacterString> DecisionDetails { get; init; }
}
