// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-SimpleACK-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SimpleAckPdu
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
    /// The invoke ID of the original request being acknowledged.
    /// </summary>
    public required TInvokeId InvokeId { get; init; }
    
    /// <summary>
    /// The service choice being acknowledged.
    /// </summary>
    public required ConfirmedServiceChoice ServiceAckChoice { get; init; }
    }
