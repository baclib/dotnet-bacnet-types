// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLockStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LockStatus : byte
{
    /// <summary>
    /// Lock is engaged.
    /// </summary>
    Locked = 0,

    /// <summary>
    /// Lock is disengaged.
    /// </summary>
    Unlocked = 1,

    /// <summary>
    /// Lock fault detected.
    /// </summary>
    LockFault = 2,

    /// <summary>
    /// Lock status is unused.
    /// </summary>
    Unused = 3,

    /// <summary>
    /// Lock status is unknown.
    /// </summary>
    Unknown = 4
}
