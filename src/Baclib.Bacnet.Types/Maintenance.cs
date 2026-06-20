// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetMaintenance as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum Maintenance : ushort
{
    /// <summary>
    /// No maintenance required.
    /// </summary>
    None = 0,

    /// <summary>
    /// Periodic test required.
    /// </summary>
    PeriodicTest = 1,

    /// <summary>
    /// Service needed while operational.
    /// </summary>
    NeedServiceOperational = 2,

    /// <summary>
    /// Service needed while inoperative.
    /// </summary>
    NeedServiceInoperative = 3
}
