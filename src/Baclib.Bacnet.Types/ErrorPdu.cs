// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-Error-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ErrorPdu
{
    /// <summary>
    /// The PDU type identifier (5 for BACnet-Error-PDU).
    /// </summary>
    public required TPduType PduType { get; init; }
    
    /// <summary>
    /// Reserved field, must be zero.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// The invoke ID from the original confirmed service request that caused this error.
    /// </summary>
    public required TOriginalInvokeId OriginalInvokeId { get; init; }
    
    /// <summary>
    /// The confirmed service type that resulted in the error.
    /// </summary>
    public required ConfirmedServiceChoice ErrorChoice { get; init; }
    
    /// <summary>
    /// The error information containing error class and error code.
    /// </summary>
    public required Error Error { get; init; }
    }
