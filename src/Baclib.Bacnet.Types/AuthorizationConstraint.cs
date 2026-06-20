// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthorizationConstraint as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthorizationConstraint
{
    /// <summary>
    /// The required network origin of the client.
    /// </summary>
    public required TOrigin Origin { get; init; }
    
    /// <summary>
    /// The required authentication method for the client.
    /// </summary>
    public required TAuthentication Authentication { get; init; }
    }
