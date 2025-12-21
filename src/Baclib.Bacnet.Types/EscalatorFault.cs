// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetEscalatorFault as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum EscalatorFault : ushort
{
    /// <summary>
    /// Controller fault detected.
    /// </summary>
    ControllerFault = 0,

    /// <summary>
    /// Drive and motor fault detected.
    /// </summary>
    DriveAndMotorFault = 1,

    /// <summary>
    /// Mechanical component fault detected.
    /// </summary>
    MechanicalComponentFault = 2,

    /// <summary>
    /// Overspeed fault detected.
    /// </summary>
    OverspeedFault = 3,

    /// <summary>
    /// Power supply fault detected.
    /// </summary>
    PowerSupplyFault = 4,

    /// <summary>
    /// Safety device fault detected.
    /// </summary>
    SafetyDeviceFault = 5,

    /// <summary>
    /// Controller supply fault detected.
    /// </summary>
    ControllerSupplyFault = 6,

    /// <summary>
    /// Drive temperature exceeded.
    /// </summary>
    DriveTemperatureExceeded = 7,

    /// <summary>
    /// Comb plate fault detected.
    /// </summary>
    CombPlateFault = 8
}
