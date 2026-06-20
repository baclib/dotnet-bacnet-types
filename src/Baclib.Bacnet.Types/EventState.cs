// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetEventState as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum EventState : ushort
{
    /// <summary>
    /// Event is in normal state.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Event is in fault state.
    /// </summary>
    Fault = 1,

    /// <summary>
    /// Event is in offnormal state.
    /// </summary>
    Offnormal = 2,

    /// <summary>
    /// Event is in high limit state.
    /// </summary>
    HighLimit = 3,

    /// <summary>
    /// Event is in low limit state.
    /// </summary>
    LowLimit = 4,

    /// <summary>
    /// Event is in life safety alarm state.
    /// </summary>
    LifeSafetyAlarm = 5
}
