// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ReadRange-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReadRangeAck
{
    /// <summary>
    /// The identifier of the object being read.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The property identifier specifying the property being read.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }
    
    /// <summary>
    /// Optional array index for the property.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// Flags indicating the position and availability of items in the result set.
    /// </summary>
    public required ResultFlags ResultFlags { get; init; }
    
    /// <summary>
    /// The number of items returned in the result.
    /// </summary>
    public required Unsigned ItemCount { get; init; }
    
    /// <summary>
    /// The data items returned in the result.
    /// </summary>
    public required TItemData ItemData { get; init; }
    
    /// <summary>
    /// Optional sequence number of the first item in the result.
    /// </summary>
    public Optional<Unsigned32> FirstSequenceNumber { get; init; }
}
