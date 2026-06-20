// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetAuthorizationMode as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum AuthorizationMode : ushort
{
    /// <summary>
    /// Authorization mode: authorize.
    /// </summary>
    Authorize = 0,

    /// <summary>
    /// Authorization mode: grant active.
    /// </summary>
    GrantActive = 1,

    /// <summary>
    /// Authorization mode: deny all.
    /// </summary>
    DenyAll = 2,

    /// <summary>
    /// Authorization mode: verification required.
    /// </summary>
    VerificationRequired = 3,

    /// <summary>
    /// Authorization mode: authorization delayed.
    /// </summary>
    AuthorizationDelayed = 4,

    /// <summary>
    /// Authorization mode: none.
    /// </summary>
    None = 5
}
