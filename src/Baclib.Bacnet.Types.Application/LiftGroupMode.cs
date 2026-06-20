// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetLiftGroupMode as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum LiftGroupMode : byte
{
    /// <summary>
    /// Group mode is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Normal group mode.
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Down peak group mode.
    /// </summary>
    DownPeak = 2,

    /// <summary>
    /// Two-way group mode.
    /// </summary>
    TwoWay = 3,

    /// <summary>
    /// Four-way group mode.
    /// </summary>
    FourWay = 4,

    /// <summary>
    /// Emergency power group mode.
    /// </summary>
    EmergencyPower = 5,

    /// <summary>
    /// Up peak group mode.
    /// </summary>
    UpPeak = 6
}
