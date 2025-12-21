// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLifeSafetyOperation as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LifeSafetyOperation : ushort
{
    /// <summary>
    /// No operation.
    /// </summary>
    None = 0,

    /// <summary>
    /// Silence operation.
    /// </summary>
    Silence = 1,

    /// <summary>
    /// Silence audible operation.
    /// </summary>
    SilenceAudible = 2,

    /// <summary>
    /// Silence visual operation.
    /// </summary>
    SilenceVisual = 3,

    /// <summary>
    /// Reset operation.
    /// </summary>
    Reset = 4,

    /// <summary>
    /// Reset alarm operation.
    /// </summary>
    ResetAlarm = 5,

    /// <summary>
    /// Reset fault operation.
    /// </summary>
    ResetFault = 6,

    /// <summary>
    /// Unsilence operation.
    /// </summary>
    Unsilence = 7,

    /// <summary>
    /// Unsilence audible operation.
    /// </summary>
    UnsilenceAudible = 8,

    /// <summary>
    /// Unsilence visual operation.
    /// </summary>
    UnsilenceVisual = 9
}
