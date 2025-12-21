// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetRestartReason as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum RestartReason : byte
{
    /// <summary>
    /// Restart reason is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Coldstart restart reason.
    /// </summary>
    Coldstart = 1,

    /// <summary>
    /// Warmstart restart reason.
    /// </summary>
    Warmstart = 2,

    /// <summary>
    /// Detected power lost restart reason.
    /// </summary>
    DetectedPowerLost = 3,

    /// <summary>
    /// Detected powered off restart reason.
    /// </summary>
    DetectedPoweredOff = 4,

    /// <summary>
    /// Hardware watchdog restart reason.
    /// </summary>
    HardwareWatchdog = 5,

    /// <summary>
    /// Software watchdog restart reason.
    /// </summary>
    SoftwareWatchdog = 6,

    /// <summary>
    /// Suspended restart reason.
    /// </summary>
    Suspended = 7,

    /// <summary>
    /// Activate changes restart reason.
    /// </summary>
    ActivateChanges = 8
}
