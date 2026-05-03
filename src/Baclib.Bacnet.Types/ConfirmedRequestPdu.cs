// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-Confirmed-Request-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedRequestPdu
{
    /// <summary>
    /// The PDU type identifier (0 for BACnet-Confirmed-Request-PDU).
    /// </summary>
    public required TPduType PduType { get; init; }
    
    /// <summary>
    /// Indicates whether this is a segmented message.
    /// </summary>
    public required Boolean SegmentedMessage { get; init; }
    
    /// <summary>
    /// Indicates whether more segments follow this one.
    /// </summary>
    public required Boolean MoreFollows { get; init; }
    
    /// <summary>
    /// Indicates whether the sender can accept a segmented response.
    /// </summary>
    public required Boolean SegmentedResponseAccepted { get; init; }
    
    /// <summary>
    /// Reserved field, must be zero.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// The maximum number of segments the sender can accept in a response.
    /// </summary>
    public required TMaxSegmentsAccepted MaxSegmentsAccepted { get; init; }
    
    /// <summary>
    /// The maximum APDU length the sender can accept.
    /// </summary>
    public required TMaxApduLengthAccepted MaxApduLengthAccepted { get; init; }
    
    /// <summary>
    /// The invoke ID for matching requests with responses.
    /// </summary>
    public required TInvokeId InvokeId { get; init; }
    
    /// <summary>
    /// The sequence number for segmented messages. Optional.
    /// </summary>
    public Optional<TSequenceNumber> SequenceNumber { get; init; }

    /// <summary>
    /// The proposed window size for segmented messages. Optional.
    /// </summary>
    public Optional<TProposedWindowSize> ProposedWindowSize { get; init; }

    /// <summary>
    /// The confirmed service being requested.
    /// </summary>
    public required ConfirmedServiceChoice ServiceChoice { get; init; }
    
    /// <summary>
    /// The service request parameters. Optional.
    /// </summary>
    public Optional<ConfirmedServiceRequest> ServiceRequest { get; init; }
}
