// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetDoorSecuredStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum DoorSecuredStatus : byte
{
    /// <summary>
    /// Door is secured.
    /// </summary>
    Secured = 0,

    /// <summary>
    /// Door is unsecured.
    /// </summary>
    Unsecured = 1,

    /// <summary>
    /// Door secured status is unknown.
    /// </summary>
    Unknown = 2
}
