// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence AcknowledgeAlarm-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AcknowledgeAlarmRequest
{
    /// <summary>
    /// The identifier of the process acknowledging the alarm.
    /// </summary>
    public required Unsigned32 AcknowledgingProcessIdentifier { get; init; }
    
    /// <summary>
    /// The object identifier of the event being acknowledged.
    /// </summary>
    public required ObjectIdentifier EventObjectIdentifier { get; init; }
    
    /// <summary>
    /// The event state being acknowledged.
    /// </summary>
    public required EventState EventStateAcknowledged { get; init; }
    
    /// <summary>
    /// The timestamp of the event being acknowledged.
    /// </summary>
    public required TimeStamp Timestamp { get; init; }
    
    /// <summary>
    /// A text string identifying the source of the acknowledgment.
    /// </summary>
    public required CharacterString AcknowledgmentSource { get; init; }
    
    /// <summary>
    /// The timestamp when the acknowledgment was made.
    /// </summary>
    public required TimeStamp TimeOfAcknowledgment { get; init; }
    }
