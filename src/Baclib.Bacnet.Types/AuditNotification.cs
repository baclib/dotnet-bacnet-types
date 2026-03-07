// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuditNotification as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuditNotification
{
    /// <summary>
    /// The timestamp from the source device.
    /// </summary>
    public TimeStamp? SourceTimestamp { get; init; }

    /// <summary>
    /// The timestamp from the target device.
    /// </summary>
    public TimeStamp? TargetTimestamp { get; init; }

    /// <summary>
    /// The device that initiated the operation.
    /// </summary>
    public required Recipient SourceDevice { get; init; }
    
    /// <summary>
    /// The object on the source device that initiated the operation.
    /// </summary>
    public ObjectIdentifier? SourceObject { get; init; }

    /// <summary>
    /// The type of operation that was performed.
    /// </summary>
    public required AuditOperation Operation { get; init; }
    
    /// <summary>
    /// Optional comment from the source device.
    /// </summary>
    public CharacterString? SourceComment { get; init; }

    /// <summary>
    /// Optional comment from the target device.
    /// </summary>
    public CharacterString? TargetComment { get; init; }

    /// <summary>
    /// The invoke ID of the related service request.
    /// </summary>
    public Unsigned8? InvokeId { get; init; }

    /// <summary>
    /// The user ID on the source device.
    /// </summary>
    public Unsigned16? SourceUserId { get; init; }

    /// <summary>
    /// The user role on the source device.
    /// </summary>
    public Unsigned8? SourceUserRole { get; init; }

    /// <summary>
    /// The device that was the target of the operation.
    /// </summary>
    public required Recipient TargetDevice { get; init; }
    
    /// <summary>
    /// The object on the target device that was affected.
    /// </summary>
    public ObjectIdentifier? TargetObject { get; init; }

    /// <summary>
    /// The property on the target object that was affected.
    /// </summary>
    public PropertyReference? TargetProperty { get; init; }

    /// <summary>
    /// The priority level used for the operation (1-16).
    /// </summary>
    public TTargetPriority? TargetPriority { get; init; }

    /// <summary>
    /// The value that was written or requested.
    /// </summary>
    public Any? TargetValue { get; init; }

    /// <summary>
    /// The current or resulting value.
    /// </summary>
    public Any? CurrentValue { get; init; }

    /// <summary>
    /// Error information if the operation failed.
    /// </summary>
    public Error? Result { get; init; }
}
