// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLiftCarMode as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LiftCarMode : ushort
{
    /// <summary>
    /// Mode is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Normal mode.
    /// </summary>
    Normal = 1,

    /// <summary>
    /// VIP mode.
    /// </summary>
    Vip = 2,

    /// <summary>
    /// Homing mode.
    /// </summary>
    Homing = 3,

    /// <summary>
    /// Parking mode.
    /// </summary>
    Parking = 4,

    /// <summary>
    /// Attendant control mode.
    /// </summary>
    AttendantControl = 5,

    /// <summary>
    /// Firefighter control mode.
    /// </summary>
    FirefighterControl = 6,

    /// <summary>
    /// Emergency power mode.
    /// </summary>
    EmergencyPower = 7,

    /// <summary>
    /// Inspection mode.
    /// </summary>
    Inspection = 8,

    /// <summary>
    /// Cabinet recall mode.
    /// </summary>
    CabinetRecall = 9,

    /// <summary>
    /// Earthquake operation mode.
    /// </summary>
    EarthquakeOperation = 10,

    /// <summary>
    /// Fire operation mode.
    /// </summary>
    FireOperation = 11,

    /// <summary>
    /// Out of service mode.
    /// </summary>
    OutOfService = 12,

    /// <summary>
    /// Occupant evacuation mode.
    /// </summary>
    OccupantEvacuation = 13
}
