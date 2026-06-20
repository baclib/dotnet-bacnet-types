// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetLightingInProgress as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum LightingInProgress : byte
{
    /// <summary>
    /// No lighting operation in progress.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// Fade operation is active.
    /// </summary>
    FadeActive = 1,

    /// <summary>
    /// Ramp operation is active.
    /// </summary>
    RampActive = 2,

    /// <summary>
    /// Lighting is not controlled.
    /// </summary>
    NotControlled = 3,

    /// <summary>
    /// Other lighting operation in progress.
    /// </summary>
    Other = 4,

    /// <summary>
    /// Trim operation is active.
    /// </summary>
    TrimActive = 5
}
