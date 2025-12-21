// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLiftFault as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LiftFault : ushort
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
    /// Governor and safety gear fault detected.
    /// </summary>
    GovernorAndSafetyGearFault = 2,

    /// <summary>
    /// Lift shaft device fault detected.
    /// </summary>
    LiftShaftDeviceFault = 3,

    /// <summary>
    /// Power supply fault detected.
    /// </summary>
    PowerSupplyFault = 4,

    /// <summary>
    /// Safety interlock fault detected.
    /// </summary>
    SafetyInterlockFault = 5,

    /// <summary>
    /// Door closing fault detected.
    /// </summary>
    DoorClosingFault = 6,

    /// <summary>
    /// Door opening fault detected.
    /// </summary>
    DoorOpeningFault = 7,

    /// <summary>
    /// Car stopped outside landing zone.
    /// </summary>
    CarStoppedOutsideLandingZone = 8,

    /// <summary>
    /// Call button stuck.
    /// </summary>
    CallButtonStuck = 9,

    /// <summary>
    /// Start failure detected.
    /// </summary>
    StartFailure = 10,

    /// <summary>
    /// Controller supply fault detected.
    /// </summary>
    ControllerSupplyFault = 11,

    /// <summary>
    /// Self-test failure detected.
    /// </summary>
    SelfTestFailure = 12,

    /// <summary>
    /// Runtime limit exceeded.
    /// </summary>
    RuntimeLimitExceeded = 13,

    /// <summary>
    /// Position lost.
    /// </summary>
    PositionLost = 14,

    /// <summary>
    /// Drive temperature exceeded.
    /// </summary>
    DriveTemperatureExceeded = 15,

    /// <summary>
    /// Load measurement fault detected.
    /// </summary>
    LoadMeasurementFault = 16
}
