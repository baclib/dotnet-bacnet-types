// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLifeSafetyMode as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LifeSafetyMode : ushort
{
    /// <summary>
    /// Life safety mode is off.
    /// </summary>
    Off = 0,

    /// <summary>
    /// Life safety mode is on.
    /// </summary>
    On = 1,

    /// <summary>
    /// Test mode.
    /// </summary>
    Test = 2,

    /// <summary>
    /// Manned mode.
    /// </summary>
    Manned = 3,

    /// <summary>
    /// Unmanned mode.
    /// </summary>
    Unmanned = 4,

    /// <summary>
    /// Armed mode.
    /// </summary>
    Armed = 5,

    /// <summary>
    /// Disarmed mode.
    /// </summary>
    Disarmed = 6,

    /// <summary>
    /// Prearmed mode.
    /// </summary>
    Prearmed = 7,

    /// <summary>
    /// Slow mode.
    /// </summary>
    Slow = 8,

    /// <summary>
    /// Fast mode.
    /// </summary>
    Fast = 9,

    /// <summary>
    /// Disconnected mode.
    /// </summary>
    Disconnected = 10,

    /// <summary>
    /// Enabled mode.
    /// </summary>
    Enabled = 11,

    /// <summary>
    /// Disabled mode.
    /// </summary>
    Disabled = 12,

    /// <summary>
    /// Automatic release disabled.
    /// </summary>
    AutomaticReleaseDisabled = 13,

    /// <summary>
    /// Default mode.
    /// </summary>
    Default = 14,

    /// <summary>
    /// Activated OEO alarm.
    /// </summary>
    ActivatedOeoAlarm = 15,

    /// <summary>
    /// Activated OEO evacuate.
    /// </summary>
    ActivatedOeoEvacuate = 16,

    /// <summary>
    /// Activated OEO phase 1 recall.
    /// </summary>
    ActivatedOeoPhase1Recall = 17,

    /// <summary>
    /// Activated OEO unavailable.
    /// </summary>
    ActivatedOeoUnavailable = 18,

    /// <summary>
    /// Deactivated mode.
    /// </summary>
    Deactivated = 19
}
