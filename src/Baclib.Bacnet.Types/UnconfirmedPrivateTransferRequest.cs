// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence UnconfirmedPrivateTransfer-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UnconfirmedPrivateTransferRequest
{
    /// <summary>
    /// The vendor identifier for the proprietary service.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }
    
    /// <summary>
    /// The service number identifying the proprietary service.
    /// </summary>
    public required Unsigned ServiceNumber { get; init; }
    
    /// <summary>
    /// Optional parameters for the proprietary service.
    /// </summary>
    public Optional<Any> ServiceParameters { get; init; }
}
