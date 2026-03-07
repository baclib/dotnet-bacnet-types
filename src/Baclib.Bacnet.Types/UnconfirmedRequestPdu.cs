// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-Unconfirmed-Request-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UnconfirmedRequestPdu
{
    /// <summary>
    /// Identifies the type of the PDU.
    /// </summary>
    public required TPduType PduType { get; init; }
    
    /// <summary>
    /// Reserved for future use; shall be set to zero.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// Specifies the unconfirmed service being requested.
    /// </summary>
    public required UnconfirmedServiceChoice ServiceChoice { get; init; }
    
    /// <summary>
    /// The actual unconfirmed service request data.
    /// </summary>
    public required UnconfirmedServiceRequest ServiceRequest { get; init; }
    }
