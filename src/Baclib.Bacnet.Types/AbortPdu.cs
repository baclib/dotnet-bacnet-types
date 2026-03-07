// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-Abort-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AbortPdu
{
    /// <summary>
    /// Identifies the type of the PDU, which shall be always 7.
    /// </summary>
    public required TPduType PduType { get; init; }
    
    /// <summary>
    /// Reserved for future use; shall be set to zero.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// Indicates whether the abort was initiated by the server (true) or client (false).
    /// </summary>
    public required Boolean Server { get; init; }
    
    /// <summary>
    /// The invoke ID of the original request being aborted.
    /// </summary>
    public required TOriginalInvokeId OriginalInvokeId { get; init; }
    
    /// <summary>
    /// Specifies the reason for aborting the transaction.
    /// </summary>
    public required AbortReason AbortReason { get; init; }
    }
