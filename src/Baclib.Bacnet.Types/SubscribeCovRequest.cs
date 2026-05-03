// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence SubscribeCOV-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SubscribeCovRequest
{
    /// <summary>
    /// The process identifier of the subscriber.
    /// </summary>
    public required Unsigned32 SubscriberProcessIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the object to be monitored for changes.
    /// </summary>
    public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
    
    /// <summary>
    /// Indicates if confirmed notifications should be issued. Optional.
    /// </summary>
    public Optional<Boolean> IssueConfirmedNotifications { get; init; }

    /// <summary>
    /// The duration of the subscription, in seconds. Optional.
    /// </summary>
    public Optional<Unsigned> Lifetime { get; init; }
}
