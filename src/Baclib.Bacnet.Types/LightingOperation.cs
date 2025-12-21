// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLightingOperation as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LightingOperation : ushort
{
    /// <summary>
    /// No lighting operation.
    /// </summary>
    None = 0,

    /// <summary>
    /// Fade to a value.
    /// </summary>
    FadeTo = 1,

    /// <summary>
    /// Ramp to a value.
    /// </summary>
    RampTo = 2,

    /// <summary>
    /// Step up.
    /// </summary>
    StepUp = 3,

    /// <summary>
    /// Step down.
    /// </summary>
    StepDown = 4,

    /// <summary>
    /// Step on.
    /// </summary>
    StepOn = 5,

    /// <summary>
    /// Step off.
    /// </summary>
    StepOff = 6,

    /// <summary>
    /// Warn.
    /// </summary>
    Warn = 7,

    /// <summary>
    /// Warn off.
    /// </summary>
    WarnOff = 8,

    /// <summary>
    /// Warn relinquish.
    /// </summary>
    WarnRelinquish = 9,

    /// <summary>
    /// Stop operation.
    /// </summary>
    Stop = 10,

    /// <summary>
    /// Restore on.
    /// </summary>
    RestoreOn = 11,

    /// <summary>
    /// Default on.
    /// </summary>
    DefaultOn = 12,

    /// <summary>
    /// Toggle restore.
    /// </summary>
    ToggleRestore = 13,

    /// <summary>
    /// Toggle default.
    /// </summary>
    ToggleDefault = 14
}
