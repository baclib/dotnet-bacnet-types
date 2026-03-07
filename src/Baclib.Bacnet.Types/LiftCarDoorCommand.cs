// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLiftCarDoorCommand as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum LiftCarDoorCommand : byte
{
    /// <summary>
    /// No door command.
    /// </summary>
    None = 0,

    /// <summary>
    /// Open the lift car door.
    /// </summary>
    Open = 1,

    /// <summary>
    /// Close the lift car door.
    /// </summary>
    Close = 2
}
