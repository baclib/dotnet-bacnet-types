// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence SubscribeCOVPropertyMultiple-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SubscribeCovPropertyMultipleRequest
{
    /// <summary>
    /// The process identifier of the subscriber.
    /// </summary>
    public required Unsigned32 SubscriberProcessIdentifier { get; init; }

    /// <summary>
    /// Indicates if confirmed notifications should be issued.
    /// </summary>
    public required Boolean IssueConfirmedNotifications { get; init; }

    /// <summary>
    /// The duration of the subscription, in seconds. Optional.
    /// </summary>
    public Optional<Unsigned> Lifetime { get; init; }

    /// <summary>
    /// The maximum delay between notifications, in seconds. Optional.
    /// </summary>
    public Optional<Unsigned> MaxNotificationDelay { get; init; }

    /// <summary>
    /// A list of COV subscription specifications for multiple objects and properties.
    /// </summary>
    public required SequenceOf<TListOfCovSubscriptionSpecificationsItem> ListOfCovSubscriptionSpecifications { get; init; }
}
