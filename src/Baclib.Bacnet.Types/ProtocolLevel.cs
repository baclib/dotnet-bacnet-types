// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetProtocolLevel as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ProtocolLevel : byte
{
    /// <summary>
    /// Physical protocol level.
    /// </summary>
    Physical = 0,

    /// <summary>
    /// Protocol level.
    /// </summary>
    Protocol = 1,

    /// <summary>
    /// BACnet application protocol level.
    /// </summary>
    BacnetApplication = 2,

    /// <summary>
    /// Non-BACnet application protocol level.
    /// </summary>
    NonBacnetApplication = 3
}
