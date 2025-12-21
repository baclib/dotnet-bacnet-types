// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessZoneOccupancyState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessZoneOccupancyState : ushort
{
    /// <summary>
    /// Zone occupancy is normal.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Zone occupancy is below the lower limit.
    /// </summary>
    BelowLowerLimit = 1,

    /// <summary>
    /// Zone occupancy is at the lower limit.
    /// </summary>
    AtLowerLimit = 2,

    /// <summary>
    /// Zone occupancy is at the upper limit.
    /// </summary>
    AtUpperLimit = 3,

    /// <summary>
    /// Zone occupancy is above the upper limit.
    /// </summary>
    AboveUpperLimit = 4,

    /// <summary>
    /// Zone occupancy is disabled.
    /// </summary>
    Disabled = 5,

    /// <summary>
    /// Zone occupancy is not supported.
    /// </summary>
    NotSupported = 6
}
