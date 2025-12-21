// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetColorOperation as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ColorOperation : byte
{
    /// <summary>
    /// No color operation.
    /// </summary>
    None = 0,

    /// <summary>
    /// Fade to a specific color.
    /// </summary>
    FadeToColor = 1,

    /// <summary>
    /// Fade to a specific correlated color temperature (CCT).
    /// </summary>
    FadeToCct = 2,

    /// <summary>
    /// Ramp to a specific correlated color temperature (CCT).
    /// </summary>
    RampToCct = 3,

    /// <summary>
    /// Step up the correlated color temperature (CCT).
    /// </summary>
    StepUpCct = 4,

    /// <summary>
    /// Step down the correlated color temperature (CCT).
    /// </summary>
    StepDownCct = 5,

    /// <summary>
    /// Stop the color operation.
    /// </summary>
    Stop = 6
}
