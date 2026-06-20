// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetEventNotificationSubscription as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class EventNotificationSubscription
{
    /// <summary>
    /// The recipient to receive event notifications.
    /// </summary>
    public required Recipient Recipient { get; init; }
    
    /// <summary>
    /// A unique identifier for the subscribing process.
    /// </summary>
    public required Unsigned32 ProcessIdentifier { get; init; }
    
    /// <summary>
    /// Indicates whether confirmed event notifications should be issued to the recipient.
    /// </summary>
    public required Boolean IssueConfirmedNotifications { get; init; }
    
    /// <summary>
    /// The remaining time in seconds before this subscription expires.
    /// </summary>
    public required Unsigned TimeRemaining { get; init; }
    }
