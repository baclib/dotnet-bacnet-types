// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthorizationPosture as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthorizationPosture : byte
{
    /// <summary>
    /// Open authorization posture.
    /// </summary>
    Open = 0,

    /// <summary>
    /// Proprietary authorization posture.
    /// </summary>
    Proprietary = 1,

    /// <summary>
    /// Configured authorization posture.
    /// </summary>
    Configured = 2,

    /// <summary>
    /// Partially misconfigured authorization posture.
    /// </summary>
    MisconfiguredPartial = 3,

    /// <summary>
    /// Totally misconfigured authorization posture.
    /// </summary>
    MisconfiguredTotal = 4
}
