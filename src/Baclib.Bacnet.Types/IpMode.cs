// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetIPMode as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum IpMode : byte
{
    /// <summary>
    /// Normal IP mode.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Foreign device IP mode.
    /// </summary>
    Foreign = 1,

    /// <summary>
    /// BBMD (BACnet Broadcast Management Device) IP mode.
    /// </summary>
    Bbmd = 2
}
