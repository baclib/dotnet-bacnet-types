// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence UnconfirmedCOVNotificationMultiple-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UnconfirmedCovNotificationMultipleRequest
{
    /// <summary>
    /// The process identifier of the subscriber.
    /// </summary>
    public required Unsigned32 SubscriberProcessIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the device initiating the notification.
    /// </summary>
    public required ObjectIdentifier InitiatingDeviceIdentifier { get; init; }
    
    /// <summary>
    /// The time remaining for the subscription, in seconds.
    /// </summary>
    public required Unsigned TimeRemaining { get; init; }
    
    /// <summary>
    /// The timestamp of the notification. Optional.
    /// </summary>
    public DateTime? Timestamp { get; init; }

    /// <summary>
    /// A list of COV notifications for monitored objects.
    /// </summary>
    public required TListOfCovNotifications ListOfCovNotifications { get; init; }
    }
