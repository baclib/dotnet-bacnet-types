// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAcknowledgeAlarmInfo as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AcknowledgeAlarmInfo
{
    /// <summary>
    /// The event state that was acknowledged.
    /// </summary>
    public required EventState EventStateAcknowledged { get; init; }
    
    /// <summary>
    /// The timestamp of the acknowledged event.
    /// </summary>
    public required TimeStamp Timestamp { get; init; }
    }
