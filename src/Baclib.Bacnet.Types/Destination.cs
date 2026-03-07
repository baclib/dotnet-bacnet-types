// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetDestination as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Destination
{
    /// <summary>
    /// Specifies the days of the week when notifications are valid.
    /// </summary>
    public required DaysOfWeek ValidDays { get; init; }
    
    /// <summary>
    /// The start time of the period during which notifications may be sent.
    /// </summary>
    public required Time FromTime { get; init; }
    
    /// <summary>
    /// The end time of the period during which notifications may be sent.
    /// </summary>
    public required Time ToTime { get; init; }
    
    /// <summary>
    /// The recipient of the notification, which may be a device or an address.
    /// </summary>
    public required Recipient Recipient { get; init; }
    
    /// <summary>
    /// The process identifier for the recipient, used to distinguish between multiple processes on the same device.
    /// </summary>
    public required Unsigned32 ProcessIdentifier { get; init; }
    
    /// <summary>
    /// Indicates whether confirmed notifications should be issued (true) or unconfirmed (false).
    /// </summary>
    public required Boolean IssueConfirmedNotifications { get; init; }
    
    /// <summary>
    /// Specifies which event transitions (to-offnormal, to-fault, to-normal) will trigger notifications.
    /// </summary>
    public required EventTransitionBits Transitions { get; init; }
    }
