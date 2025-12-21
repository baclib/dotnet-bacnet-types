// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetEscalatorMode as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum EscalatorMode : ushort
{
    /// <summary>
    /// Escalator mode is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Escalator is stopped.
    /// </summary>
    Stop = 1,

    /// <summary>
    /// Escalator is moving up.
    /// </summary>
    Up = 2,

    /// <summary>
    /// Escalator is moving down.
    /// </summary>
    Down = 3,

    /// <summary>
    /// Escalator is in inspection mode.
    /// </summary>
    Inspection = 4,

    /// <summary>
    /// Escalator is out of service.
    /// </summary>
    OutOfService = 5
}
