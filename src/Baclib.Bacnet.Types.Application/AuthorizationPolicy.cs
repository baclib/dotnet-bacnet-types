// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthorizationPolicy as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationPolicy
{
    /// <summary>
    /// The policy is not valid before this date and time.
    /// </summary>
    public Optional<DateTime> NotBefore { get; init; }

    /// <summary>
    /// The policy is not valid after this date and time.
    /// </summary>
    public Optional<DateTime> NotAfter { get; init; }

    /// <summary>
    /// A list of client identifiers to which this policy applies.
    /// </summary>
    public required SequenceOf<Unsigned32> Clients { get; init; }

    /// <summary>
    /// Constraints on the origin and authentication method for this policy.
    /// </summary>
    public required AuthorizationConstraint Constraint { get; init; }

    /// <summary>
    /// The scope of access granted by this policy.
    /// </summary>
    public required AuthorizationScope Scope { get; init; }
}
