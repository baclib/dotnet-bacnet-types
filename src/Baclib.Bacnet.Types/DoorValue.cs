// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetDoorValue as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum DoorValue : byte
{
    /// <summary>
    /// Lock the door.
    /// </summary>
    Lock = 0,

    /// <summary>
    /// Unlock the door.
    /// </summary>
    Unlock = 1,

    /// <summary>
    /// Pulse unlock the door.
    /// </summary>
    PulseUnlock = 2,

    /// <summary>
    /// Extended pulse unlock the door.
    /// </summary>
    ExtendedPulseUnlock = 3
}
