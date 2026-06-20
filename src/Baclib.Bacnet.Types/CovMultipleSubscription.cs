// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetCOVMultipleSubscription as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CovMultipleSubscription
{
    /// <summary>
    /// The recipient process that will receive COV notifications.
    /// </summary>
    public required RecipientProcess Recipient { get; init; }
    
    /// <summary>
    /// Indicates whether confirmed notifications should be issued to the recipient.
    /// </summary>
    public required Boolean IssueConfirmedNotifications { get; init; }
    
    /// <summary>
    /// The remaining time in seconds before this subscription expires.
    /// </summary>
    public required Unsigned TimeRemaining { get; init; }
    
    /// <summary>
    /// The maximum time in seconds that notifications may be delayed for batching.
    /// </summary>
    public required Unsigned MaxNotificationDelay { get; init; }
    
    /// <summary>
    /// A list of object and property specifications for COV monitoring.
    /// </summary>
    public required TListOfCovSubscriptionSpecifications ListOfCovSubscriptionSpecifications { get; init; }
    }
