// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetColorOperationInProgress as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ColorOperationInProgress : byte
{
    /// <summary>
    /// No color operation is in progress.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// A fade operation is active.
    /// </summary>
    FadeActive = 1,

    /// <summary>
    /// A ramp operation is active.
    /// </summary>
    RampActive = 2,

    /// <summary>
    /// The color operation is not controlled.
    /// </summary>
    NotControlled = 3,

    /// <summary>
    /// Other color operation in progress.
    /// </summary>
    Other = 4
}
