// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence GetEnrollmentSummary-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class GetEnrollmentSummaryRequest
{
    /// <summary>
    /// Filter for event acknowledgment status.
    /// </summary>
    public required TAcknowledgmentFilter AcknowledgmentFilter { get; init; }
    
    /// <summary>
    /// Optional filter to match a specific event recipient process.
    /// </summary>
    public Optional<RecipientProcess> EnrollmentFilter { get; init; }

    /// <summary>
    /// Optional filter for event state.
    /// </summary>
    public Optional<TEventStateFilter> EventStateFilter { get; init; }

    /// <summary>
    /// Optional filter to match a specific event type.
    /// </summary>
    public Optional<EventType> EventTypeFilter { get; init; }

    /// <summary>
    /// Optional filter to include events within a priority range.
    /// </summary>
    public Optional<TPriorityFilter> PriorityFilter { get; init; }

    /// <summary>
    /// Optional filter to match a specific notification class.
    /// </summary>
    public Optional<Unsigned> NotificationClassFilter { get; init; }
}
