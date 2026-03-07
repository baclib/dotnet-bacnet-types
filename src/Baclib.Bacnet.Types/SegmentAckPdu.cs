// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnet-SegmentACK-PDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SegmentAckPdu
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
    /// Indicates if this is a negative acknowledgment.
    /// </summary>
    public required Boolean NegativeAck { get; init; }
    
    /// <summary>
    /// Indicates if the message is from the server.
    /// </summary>
    public required Boolean Server { get; init; }
    
    /// <summary>
    /// The invoke ID of the original segmented message.
    /// </summary>
    public required TOriginalInvokeId OriginalInvokeId { get; init; }
    
    /// <summary>
    /// The sequence number of the segment being acknowledged.
    /// </summary>
    public required TSequenceNumber SequenceNumber { get; init; }
    
    /// <summary>
    /// The actual window size used for segmentation.
    /// </summary>
    public required TActualWindowSize ActualWindowSize { get; init; }
    }
