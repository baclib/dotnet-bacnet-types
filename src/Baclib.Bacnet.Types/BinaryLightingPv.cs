// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetBinaryLightingPV as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum BinaryLightingPv : byte
{
    /// <summary>
    /// The value is OFF.
    /// </summary>
    Off = 0,

    /// <summary>
    /// The value is ON.
    /// </summary>
    On = 1,

    /// <summary>
    /// The value is WARN.
    /// </summary>
    Warn = 2,

    /// <summary>
    /// The value is WARN_OFF.
    /// </summary>
    WarnOff = 3,

    /// <summary>
    /// The value is WARN_RELINQUISH.
    /// </summary>
    WarnRelinquish = 4,

    /// <summary>
    /// The value is STOP.
    /// </summary>
    Stop = 5,

    /// <summary>
    /// The value is TOGGLE.
    /// </summary>
    Toggle = 6
}
