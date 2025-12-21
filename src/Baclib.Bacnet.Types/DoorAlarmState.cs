// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetDoorAlarmState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum DoorAlarmState : ushort
{
    /// <summary>
    /// Door is in normal state.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Door is in alarm state.
    /// </summary>
    Alarm = 1,

    /// <summary>
    /// Door has been open too long.
    /// </summary>
    DoorOpenTooLong = 2,

    /// <summary>
    /// Door was forced open.
    /// </summary>
    ForcedOpen = 3,

    /// <summary>
    /// Door tamper detected.
    /// </summary>
    Tamper = 4,

    /// <summary>
    /// Door fault detected.
    /// </summary>
    DoorFault = 5,

    /// <summary>
    /// Door is in lockdown state.
    /// </summary>
    LockDown = 6,

    /// <summary>
    /// Door is in free access state.
    /// </summary>
    FreeAccess = 7,

    /// <summary>
    /// Door is open for egress.
    /// </summary>
    EgressOpen = 8
}
