// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLiftCarDriveStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LiftCarDriveStatus : ushort
{
    /// <summary>
    /// Drive status is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Lift car is stationary.
    /// </summary>
    Stationary = 1,

    /// <summary>
    /// Lift car is braking.
    /// </summary>
    Braking = 2,

    /// <summary>
    /// Lift car is accelerating.
    /// </summary>
    Accelerate = 3,

    /// <summary>
    /// Lift car is decelerating.
    /// </summary>
    Decelerate = 4,

    /// <summary>
    /// Lift car is at rated speed.
    /// </summary>
    RatedSpeed = 5,

    /// <summary>
    /// Single floor jump.
    /// </summary>
    SingleFloorJump = 6,

    /// <summary>
    /// Two floor jump.
    /// </summary>
    TwoFloorJump = 7,

    /// <summary>
    /// Three floor jump.
    /// </summary>
    ThreeFloorJump = 8,

    /// <summary>
    /// Multi-floor jump.
    /// </summary>
    MultiFloorJump = 9
}
