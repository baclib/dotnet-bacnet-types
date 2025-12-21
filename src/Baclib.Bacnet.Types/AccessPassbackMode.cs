// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessPassbackMode as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessPassbackMode : byte
{
    /// <summary>
    /// Passback is not enforced.
    /// </summary>
    PassbackOff = 0,

    /// <summary>
    /// Hard passback enforcement.
    /// </summary>
    HardPassback = 1,

    /// <summary>
    /// Soft passback enforcement.
    /// </summary>
    SoftPassback = 2
}
