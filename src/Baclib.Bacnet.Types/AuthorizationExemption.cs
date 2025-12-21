// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthorizationExemption as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthorizationExemption : byte
{
    /// <summary>
    /// Passback exemption.
    /// </summary>
    Passback = 0,

    /// <summary>
    /// Occupancy check exemption.
    /// </summary>
    OccupancyCheck = 1,

    /// <summary>
    /// Access rights exemption.
    /// </summary>
    AccessRights = 2,

    /// <summary>
    /// Lockout exemption.
    /// </summary>
    Lockout = 3,

    /// <summary>
    /// Deny exemption.
    /// </summary>
    Deny = 4,

    /// <summary>
    /// Verification exemption.
    /// </summary>
    Verification = 5,

    /// <summary>
    /// Authorization delay exemption.
    /// </summary>
    AuthorizationDelay = 6
}
