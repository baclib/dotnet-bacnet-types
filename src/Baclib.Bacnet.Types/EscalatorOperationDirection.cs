// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetEscalatorOperationDirection as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum EscalatorOperationDirection : ushort
{
    /// <summary>
    /// Escalator direction is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Escalator is stopped.
    /// </summary>
    Stopped = 1,

    /// <summary>
    /// Escalator is moving up at rated speed.
    /// </summary>
    UpRatedSpeed = 2,

    /// <summary>
    /// Escalator is moving up at reduced speed.
    /// </summary>
    UpReducedSpeed = 3,

    /// <summary>
    /// Escalator is moving down at rated speed.
    /// </summary>
    DownRatedSpeed = 4,

    /// <summary>
    /// Escalator is moving down at reduced speed.
    /// </summary>
    DownReducedSpeed = 5
}
