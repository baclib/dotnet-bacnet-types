// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ConfirmedPrivateTransfer-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedPrivateTransferError
{
    /// <summary>
    /// The error class and code describing the failure.
    /// </summary>
    public required Error ErrorType { get; init; }
    
    /// <summary>
    /// The vendor identification code.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }
    
    /// <summary>
    /// The vendor-specific service number that failed.
    /// </summary>
    public required Unsigned ServiceNumber { get; init; }
    
    /// <summary>
    /// Optional vendor-specific error parameters.
    /// </summary>
    public Optional<Any> ErrorParameters { get; init; }
}
