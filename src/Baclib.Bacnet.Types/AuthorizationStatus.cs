// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuthorizationStatus as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationStatus
{
    /// <summary>
    /// The current configuration posture of the authorization system.
    /// </summary>
    public required AuthorizationPosture Posture { get; init; }
    
    /// <summary>
    /// Error information if the authorization system is in an error state.
    /// </summary>
    public Optional<Error> Error { get; init; }

    /// <summary>
    /// Reference to the object and property that is the source of the error.
    /// </summary>
    public Optional<ObjectPropertyReference> ErrorSource { get; init; }

    /// <summary>
    /// Additional details about the error condition.
    /// </summary>
    public Optional<CharacterString> ErrorDetails { get; init; }

    /// <summary>
    /// A list of recent successful authentication events.
    /// </summary>
    public Optional<TAuthenticationSuccess> AuthenticationSuccess { get; init; }

    /// <summary>
    /// A list of recent failed authentication events.
    /// </summary>
    public Optional<TAuthenticationFailure> AuthenticationFailure { get; init; }

    /// <summary>
    /// A list of recent successful authorization events.
    /// </summary>
    public Optional<TAuthorizationSuccess> AuthorizationSuccess { get; init; }

    /// <summary>
    /// A list of recent failed authorization events.
    /// </summary>
    public Optional<TAuthorizationFailure> AuthorizationFailure { get; init; }
}
