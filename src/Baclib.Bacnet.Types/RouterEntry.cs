// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetRouterEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class RouterEntry
{
    /// <summary>
    /// The BACnet network number for the router entry.
    /// </summary>
    public required Unsigned16 NetworkNumber { get; init; }
    
    /// <summary>
    /// The MAC address associated with the router entry.
    /// </summary>
    public required OctetString MacAddress { get; init; }
    
    /// <summary>
    /// The current status of the router entry.
    /// </summary>
    public required TStatus Status { get; init; }
    
    /// <summary>
    /// Optional performance index for the router entry.
    /// </summary>
    public Optional<Unsigned8> PerformanceIndex { get; init; }
}
