// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetTimerState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
/// <remarks>
/// This enumeration defines the possible states of a BACnet Timer object.
/// </remarks>
public enum TimerState : byte
{
    /// <summary>
    /// Indicates that the timer is idle and not currently running.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// Indicates that the timer is currently running and counting down.
    /// </summary>
    Running = 1,

    /// <summary>
    /// Indicates that the timer has expired and completed its countdown.
    /// </summary>
    Expired = 2
}
