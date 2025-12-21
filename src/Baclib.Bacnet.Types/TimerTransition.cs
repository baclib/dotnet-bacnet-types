// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetTimerTransition as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum TimerTransition : byte
{
    /// <summary>
    /// No transition has occurred.
    /// </summary>
    None = 0,

    /// <summary>
    /// Transition from Idle state to Running state.
    /// </summary>
    IdleToRunning = 1,

    /// <summary>
    /// Transition from Running state to Idle state.
    /// </summary>
    RunningToIdle = 2,

    /// <summary>
    /// Transition from Running state to Running state (restart).
    /// </summary>
    RunningToRunning = 3,

    /// <summary>
    /// Transition from Running state to Expired state (timer elapsed).
    /// </summary>
    RunningToExpired = 4,

    /// <summary>
    /// Transition to Expired state due to forced expiration.
    /// </summary>
    ForcedToExpired = 5,

    /// <summary>
    /// Transition from Expired state to Idle state.
    /// </summary>
    ExpiredToIdle = 6,

    /// <summary>
    /// Transition from Expired state to Running state (restart after expiration).
    /// </summary>
    ExpiredToRunning = 7
}
