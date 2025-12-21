// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetProgramState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ProgramState : byte
{
    /// <summary>
    /// Program is idle.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// Program is loading.
    /// </summary>
    Loading = 1,

    /// <summary>
    /// Program is running.
    /// </summary>
    Running = 2,

    /// <summary>
    /// Program is waiting.
    /// </summary>
    Waiting = 3,

    /// <summary>
    /// Program is halted.
    /// </summary>
    Halted = 4,

    /// <summary>
    /// Program is unloading.
    /// </summary>
    Unloading = 5
}
