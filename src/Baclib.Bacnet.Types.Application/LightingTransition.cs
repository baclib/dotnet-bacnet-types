// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetLightingTransition as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum LightingTransition : byte
{
    /// <summary>
    /// No lighting transition.
    /// </summary>
    None = 0,

    /// <summary>
    /// Fade transition.
    /// </summary>
    Fade = 1,

    /// <summary>
    /// Ramp transition.
    /// </summary>
    Ramp = 2
}
