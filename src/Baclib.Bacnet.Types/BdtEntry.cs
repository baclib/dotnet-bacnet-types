// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetBDTEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class BdtEntry
{
    /// <summary>
    /// The IP address and UDP port of the BBMD (BACnet Broadcast Management Device).
    /// </summary>
    public required HostNPort BbmdAddress { get; init; }
    
    /// <summary>
    /// Optional broadcast mask for the BDT entry.
    /// </summary>
    public OctetString? BroadcastMask { get; init; }
}
