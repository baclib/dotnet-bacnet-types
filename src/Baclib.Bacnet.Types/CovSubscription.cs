// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetCOVSubscription as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CovSubscription
{
    /// <summary>
    /// The recipient process that will receive COV notifications.
    /// </summary>
    public required RecipientProcess Recipient { get; init; }
    
    /// <summary>
    /// Reference to the property being monitored for changes.
    /// </summary>
    public required ObjectPropertyReference MonitoredPropertyReference { get; init; }
    
    /// <summary>
    /// Indicates whether confirmed notifications should be issued to the recipient.
    /// </summary>
    public required Boolean IssueConfirmedNotifications { get; init; }
    
    /// <summary>
    /// The remaining time in seconds before this subscription expires.
    /// </summary>
    public required Unsigned TimeRemaining { get; init; }
    
    /// <summary>
    /// The minimum change in value required to trigger a notification. Optional.
    /// </summary>
    public Optional<float> CovIncrement { get; init; }
}
