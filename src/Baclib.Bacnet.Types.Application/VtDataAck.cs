// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence VT-Data-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtDataAck
{
    /// <summary>
    /// Indicates if all new data was accepted (true/false).
    /// </summary>
    public required Boolean AllNewDataAccepted { get; init; }
    
    /// <summary>
    /// The number of octets accepted, if not all data was accepted. Optional.
    /// </summary>
    public Optional<Unsigned> AcceptedOctetCount { get; init; }
}
