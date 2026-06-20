// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthenticationPolicy as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationPolicy
{
    /// <summary>
    /// A list of credential data inputs required by this policy.
    /// </summary>
    public required TPolicy Policy { get; init; }
    
    /// <summary>
    /// Indicates whether the order of credential presentation must be enforced.
    /// </summary>
    public required Boolean OrderEnforced { get; init; }
    
    /// <summary>
    /// The timeout period in seconds for completing the authentication process.
    /// </summary>
    public required Unsigned Timeout { get; init; }
    }
