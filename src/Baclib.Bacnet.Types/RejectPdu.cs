// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-Reject-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class RejectPdu
{
    /// <summary>
    /// The type of the protocol data unit (PDU).
    /// </summary>
    public required TPduType PduType { get; init; }
    
    /// <summary>
    /// Reserved for future use.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// The invoke ID of the original request being rejected.
    /// </summary>
    public required TOriginalInvokeId OriginalInvokeId { get; init; }
    
    /// <summary>
    /// The reason for rejecting the request.
    /// </summary>
    public required RejectReason RejectReason { get; init; }
    }
