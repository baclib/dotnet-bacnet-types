// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthorizationScopeDescription as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationScopeDescription
{
    /// <summary>
    /// The name of the authorization scope.
    /// </summary>
    public required CharacterString Name { get; init; }

    /// <summary>
    /// A textual description of what this authorization scope allows.
    /// </summary>
    public required CharacterString Description { get; init; }
}
