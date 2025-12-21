// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetDoorStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum DoorStatus : ushort
{
    /// <summary>
    /// Door is closed.
    /// </summary>
    Closed = 0,

    /// <summary>
    /// Door is opened.
    /// </summary>
    Opened = 1,

    /// <summary>
    /// Door status is unknown.
    /// </summary>
    Unknown = 2,

    /// <summary>
    /// Door fault detected.
    /// </summary>
    DoorFault = 3,

    /// <summary>
    /// Door status is unused.
    /// </summary>
    Unused = 4,

    /// <summary>
    /// No door status.
    /// </summary>
    None = 5,

    /// <summary>
    /// Door is closing.
    /// </summary>
    Closing = 6,

    /// <summary>
    /// Door is opening.
    /// </summary>
    Opening = 7,

    /// <summary>
    /// Door is safety locked.
    /// </summary>
    SafetyLocked = 8,

    /// <summary>
    /// Door is limited opened.
    /// </summary>
    LimitedOpened = 9
}
