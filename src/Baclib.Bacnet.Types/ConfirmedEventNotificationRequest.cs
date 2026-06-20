// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence ConfirmedEventNotification-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedEventNotificationRequest
{
    /// <summary>
    /// The process identifier for this notification.
    /// </summary>
    public required Unsigned32 ProcessIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the device initiating the notification.
    /// </summary>
    public required ObjectIdentifier InitiatingDeviceIdentifier { get; init; }
    
    /// <summary>
    /// The identifier of the object generating the event.
    /// </summary>
    public required ObjectIdentifier EventObjectIdentifier { get; init; }
    
    /// <summary>
    /// The timestamp when the event occurred.
    /// </summary>
    public required TimeStamp Timestamp { get; init; }
    
    /// <summary>
    /// The notification class for this event.
    /// </summary>
    public required Unsigned NotificationClass { get; init; }
    
    /// <summary>
    /// The priority of the event notification.
    /// </summary>
    public required Unsigned8 Priority { get; init; }
    
    /// <summary>
    /// The type of event being reported.
    /// </summary>
    public required EventType EventType { get; init; }
    
    /// <summary>
    /// Optional descriptive text message about the event.
    /// </summary>
    public Optional<CharacterString> MessageText { get; init; }

    /// <summary>
    /// The type of notification (alarm or event).
    /// </summary>
    public required NotifyType NotifyType { get; init; }
    
    /// <summary>
    /// Indicates whether acknowledgment is required. Optional.
    /// </summary>
    public Optional<Boolean> AckRequired { get; init; }

    /// <summary>
    /// The previous event state. Optional.
    /// </summary>
    public Optional<EventState> FromState { get; init; }

    /// <summary>
    /// The current event state.
    /// </summary>
    public required EventState ToState { get; init; }
    
    /// <summary>
    /// Optional event-specific parameter values.
    /// </summary>
    public Optional<NotificationParameters> EventValues { get; init; }
}
