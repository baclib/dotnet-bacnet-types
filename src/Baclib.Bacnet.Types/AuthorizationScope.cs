// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuthorizationScope as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationScope
{
    /// <summary>
    /// Standard bit flags defining the scope of access.
    /// </summary>
    public required TStandard Standard { get; init; }
    
    /// <summary>
    /// Optional list of extended scope identifiers for vendor-specific or custom access scopes.
    /// </summary>
    public Optional<TExtended> Extended { get; init; }
}
