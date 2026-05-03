// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-ComplexACK-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ComplexAckPdu
{
    /// <summary>
    /// The PDU type identifier (3 for BACnet-ComplexACK-PDU).
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
    /// Reserved field, must be zero.
    /// </summary>
    public required TReserved Reserved { get; init; }
    
    /// <summary>
    /// The invoke ID matching the original request.
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
    /// The confirmed service being acknowledged.
    /// </summary>
    public required ConfirmedServiceChoice ServiceAckChoice { get; init; }
    
    /// <summary>
    /// The service acknowledgment data.
    /// </summary>
    public required ConfirmedServiceAck ServiceAck { get; init; }
    }
