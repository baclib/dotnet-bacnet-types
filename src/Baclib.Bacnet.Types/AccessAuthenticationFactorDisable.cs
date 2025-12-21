// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessAuthenticationFactorDisable as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessAuthenticationFactorDisable : ushort
{
    /// <summary>
    /// Specifies that no disablement is present.
    /// </summary>
    None = 0,

    /// <summary>
    /// Specifies that the authentication factor is disabled.
    /// </summary>
    Disabled = 1,

    /// <summary>
    /// Specifies that the authentication factor is disabled due to being lost.
    /// </summary>
    DisabledLost = 2,

    /// <summary>
    /// Specifies that the authentication factor is disabled due to being stolen.
    /// </summary>
    DisabledStolen = 3,

    /// <summary>
    /// Specifies that the authentication factor is disabled due to being damaged.
    /// </summary>
    DisabledDamaged = 4,

    /// <summary>
    /// Specifies that the authentication factor is disabled due to being destroyed.
    /// </summary>
    DisabledDestroyed = 5
}
