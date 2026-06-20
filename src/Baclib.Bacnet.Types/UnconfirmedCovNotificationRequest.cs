// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence UnconfirmedCOVNotification-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UnconfirmedCovNotificationRequest
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
    /// The identifier of the monitored object.
    /// </summary>
    public required ObjectIdentifier MonitoredObjectIdentifier { get; init; }
    
    /// <summary>
    /// The time remaining for the subscription, in seconds.
    /// </summary>
    public required Unsigned TimeRemaining { get; init; }
    
    /// <summary>
    /// A list of property values that have changed for the monitored object.
    /// </summary>
    public required TListOfValues ListOfValues { get; init; }
    }
