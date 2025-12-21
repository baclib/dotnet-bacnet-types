// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLiftCarDirection as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LiftCarDirection : ushort
{
    /// <summary>
    /// Direction is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// No direction.
    /// </summary>
    None = 1,

    /// <summary>
    /// Lift car is stopped.
    /// </summary>
    Stopped = 2,

    /// <summary>
    /// Lift car is moving up.
    /// </summary>
    Up = 3,

    /// <summary>
    /// Lift car is moving down.
    /// </summary>
    Down = 4,

    /// <summary>
    /// Lift car is moving up and down.
    /// </summary>
    UpAndDown = 5
}
