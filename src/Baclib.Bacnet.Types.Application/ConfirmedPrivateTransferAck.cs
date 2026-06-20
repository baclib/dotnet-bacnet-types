// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ConfirmedPrivateTransfer-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedPrivateTransferAck
{
    /// <summary>
    /// The vendor identification code.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }
    
    /// <summary>
    /// The vendor-specific service number.
    /// </summary>
    public required Unsigned ServiceNumber { get; init; }
    
    /// <summary>
    /// Optional vendor-specific result data.
    /// </summary>
    public Optional<Any> ResultBlock { get; init; }
}
