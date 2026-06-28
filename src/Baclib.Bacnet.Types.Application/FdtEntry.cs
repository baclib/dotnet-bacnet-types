// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetFDTEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class FdtEntry
{
    /// <summary>
    /// The BACnet/IP address of the foreign device.
    /// </summary>
    public required OctetString BacnetipAddress { get; init; }

    /// <summary>
    /// The configured time-to-live value in seconds for this FDT entry.
    /// </summary>
    public required Unsigned16 TimeToLive { get; init; }

    /// <summary>
    /// The remaining time in seconds before this FDT entry expires.
    /// </summary>
    public required Unsigned16 RemainingTimeToLive { get; init; }
}
