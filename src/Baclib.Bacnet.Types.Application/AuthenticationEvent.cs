// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthenticationEvent as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationEvent
{
    /// <summary>
    /// The date and time when the authentication event occurred.
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// Information about the peer device involved in the authentication.
    /// </summary>
    public required AuthenticationPeer Peer { get; init; }

    /// <summary>
    /// Information about the client being authenticated.
    /// </summary>
    public required AuthenticationClient Client { get; init; }

    /// <summary>
    /// The authentication decision that was made.
    /// </summary>
    public required AuthenticationDecision Decision { get; init; }

    /// <summary>
    /// Additional details about the authentication decision.
    /// </summary>
    public Optional<CharacterString> DecisionDetails { get; init; }
}
