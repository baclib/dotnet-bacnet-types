// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthenticationClient as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationClient
{
    /// <summary>
    /// Indicates whether the client has been successfully authenticated.
    /// </summary>
    public required Boolean Authenticated { get; init; }

    /// <summary>
    /// The device identifier of the client.
    /// </summary>
    public required Unsigned32 Device { get; init; }
}
