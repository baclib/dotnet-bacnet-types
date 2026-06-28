// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnet-Confirmed-Service-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedServiceRequest
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Request to acknowledge an alarm.
        /// </summary>
        AcknowledgeAlarm,

        /// <summary>
        /// Request for confirmed COV notification.
        /// </summary>
        ConfirmedCovNotification,

        /// <summary>
        /// Request for confirmed COV notification multiple.
        /// </summary>
        ConfirmedCovNotificationMultiple,

        /// <summary>
        /// Request for confirmed event notification.
        /// </summary>
        ConfirmedEventNotification,

        /// <summary>
        /// Request for enrollment summary.
        /// </summary>
        GetEnrollmentSummary,

        /// <summary>
        /// Request for event information.
        /// </summary>
        GetEventInformation,

        /// <summary>
        /// Request for life safety operation.
        /// </summary>
        LifeSafetyOperation,

        /// <summary>
        /// Request to subscribe for COV notifications.
        /// </summary>
        SubscribeCov,

        /// <summary>
        /// Request to subscribe for COV on a specific property.
        /// </summary>
        SubscribeCovProperty,

        /// <summary>
        /// Request to subscribe for multiple COV properties.
        /// </summary>
        SubscribeCovPropertyMultiple,

        /// <summary>
        /// Request for confirmed audit notification.
        /// </summary>
        ConfirmedAuditNotification,

        /// <summary>
        /// Request to read a file atomically.
        /// </summary>
        AtomicReadFile,

        /// <summary>
        /// Request to write a file atomically.
        /// </summary>
        AtomicWriteFile,

        /// <summary>
        /// Request to add elements to a list property.
        /// </summary>
        AddListElement,

        /// <summary>
        /// Request to remove elements from a list property.
        /// </summary>
        RemoveListElement,

        /// <summary>
        /// Request to create an object.
        /// </summary>
        CreateObject,

        /// <summary>
        /// Request to delete an object.
        /// </summary>
        DeleteObject,

        /// <summary>
        /// Request to read a property.
        /// </summary>
        ReadProperty,

        /// <summary>
        /// Request to read multiple properties.
        /// </summary>
        ReadPropertyMultiple,

        /// <summary>
        /// Request to read a range from a list or log.
        /// </summary>
        ReadRange,

        /// <summary>
        /// Request to write a property.
        /// </summary>
        WriteProperty,

        /// <summary>
        /// Request to write multiple properties.
        /// </summary>
        WritePropertyMultiple,

        /// <summary>
        /// Request to query the audit log.
        /// </summary>
        AuditLogQuery,

        /// <summary>
        /// Request to control device communications.
        /// </summary>
        DeviceCommunicationControl,

        /// <summary>
        /// Request for confirmed private transfer.
        /// </summary>
        ConfirmedPrivateTransfer,

        /// <summary>
        /// Request for a confirmed text message.
        /// </summary>
        ConfirmedTextMessage,

        /// <summary>
        /// Request to reinitialize a device.
        /// </summary>
        ReinitializeDevice,

        /// <summary>
        /// Request for authentication services.
        /// </summary>
        AuthRequest,

        /// <summary>
        /// Request to open a virtual terminal session.
        /// </summary>
        VtOpen,

        /// <summary>
        /// Request to close a virtual terminal session.
        /// </summary>
        VtClose,

        /// <summary>
        /// Request to transfer virtual terminal data.
        /// </summary>
        VtData
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private ConfirmedServiceRequest(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Request to acknowledge an alarm.
    /// </summary>
    public AcknowledgeAlarmRequest AcknowledgeAlarm
    {
        get
        {
            if (Choice != Option.AcknowledgeAlarm)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AcknowledgeAlarm)}.");
            }
            return (AcknowledgeAlarmRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AcknowledgeAlarm"/>.
    /// </summary>
    public bool TryGetAcknowledgeAlarm(out AcknowledgeAlarmRequest value)
    {
        if (Choice == Option.AcknowledgeAlarm)
        {
            value = (AcknowledgeAlarmRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AcknowledgeAlarm"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAcknowledgeAlarm(AcknowledgeAlarmRequest value)
    {
        return new ConfirmedServiceRequest(Option.AcknowledgeAlarm, value);
    }

    /// <summary>
    /// Request for confirmed COV notification.
    /// </summary>
    public ConfirmedCovNotificationRequest ConfirmedCovNotification
    {
        get
        {
            if (Choice != Option.ConfirmedCovNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedCovNotification)}.");
            }
            return (ConfirmedCovNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedCovNotification"/>.
    /// </summary>
    public bool TryGetConfirmedCovNotification(out ConfirmedCovNotificationRequest value)
    {
        if (Choice == Option.ConfirmedCovNotification)
        {
            value = (ConfirmedCovNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedCovNotification"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedCovNotification(ConfirmedCovNotificationRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedCovNotification, value);
    }

    /// <summary>
    /// Request for confirmed COV notification multiple.
    /// </summary>
    public ConfirmedCovNotificationMultipleRequest ConfirmedCovNotificationMultiple
    {
        get
        {
            if (Choice != Option.ConfirmedCovNotificationMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedCovNotificationMultiple)}.");
            }
            return (ConfirmedCovNotificationMultipleRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedCovNotificationMultiple"/>.
    /// </summary>
    public bool TryGetConfirmedCovNotificationMultiple(out ConfirmedCovNotificationMultipleRequest value)
    {
        if (Choice == Option.ConfirmedCovNotificationMultiple)
        {
            value = (ConfirmedCovNotificationMultipleRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedCovNotificationMultiple"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedCovNotificationMultiple(ConfirmedCovNotificationMultipleRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedCovNotificationMultiple, value);
    }

    /// <summary>
    /// Request for confirmed event notification.
    /// </summary>
    public ConfirmedEventNotificationRequest ConfirmedEventNotification
    {
        get
        {
            if (Choice != Option.ConfirmedEventNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedEventNotification)}.");
            }
            return (ConfirmedEventNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedEventNotification"/>.
    /// </summary>
    public bool TryGetConfirmedEventNotification(out ConfirmedEventNotificationRequest value)
    {
        if (Choice == Option.ConfirmedEventNotification)
        {
            value = (ConfirmedEventNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedEventNotification"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedEventNotification(ConfirmedEventNotificationRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedEventNotification, value);
    }

    /// <summary>
    /// Request for enrollment summary.
    /// </summary>
    public GetEnrollmentSummaryRequest GetEnrollmentSummary
    {
        get
        {
            if (Choice != Option.GetEnrollmentSummary)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.GetEnrollmentSummary)}.");
            }
            return (GetEnrollmentSummaryRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.GetEnrollmentSummary"/>.
    /// </summary>
    public bool TryGetGetEnrollmentSummary(out GetEnrollmentSummaryRequest value)
    {
        if (Choice == Option.GetEnrollmentSummary)
        {
            value = (GetEnrollmentSummaryRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.GetEnrollmentSummary"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromGetEnrollmentSummary(GetEnrollmentSummaryRequest value)
    {
        return new ConfirmedServiceRequest(Option.GetEnrollmentSummary, value);
    }

    /// <summary>
    /// Request for event information.
    /// </summary>
    public GetEventInformationRequest GetEventInformation
    {
        get
        {
            if (Choice != Option.GetEventInformation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.GetEventInformation)}.");
            }
            return (GetEventInformationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.GetEventInformation"/>.
    /// </summary>
    public bool TryGetGetEventInformation(out GetEventInformationRequest value)
    {
        if (Choice == Option.GetEventInformation)
        {
            value = (GetEventInformationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.GetEventInformation"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromGetEventInformation(GetEventInformationRequest value)
    {
        return new ConfirmedServiceRequest(Option.GetEventInformation, value);
    }

    /// <summary>
    /// Request for life safety operation.
    /// </summary>
    public LifeSafetyOperationRequest LifeSafetyOperation
    {
        get
        {
            if (Choice != Option.LifeSafetyOperation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LifeSafetyOperation)}.");
            }
            return (LifeSafetyOperationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.LifeSafetyOperation"/>.
    /// </summary>
    public bool TryGetLifeSafetyOperation(out LifeSafetyOperationRequest value)
    {
        if (Choice == Option.LifeSafetyOperation)
        {
            value = (LifeSafetyOperationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.LifeSafetyOperation"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromLifeSafetyOperation(LifeSafetyOperationRequest value)
    {
        return new ConfirmedServiceRequest(Option.LifeSafetyOperation, value);
    }

    /// <summary>
    /// Request to subscribe for COV notifications.
    /// </summary>
    public SubscribeCovRequest SubscribeCov
    {
        get
        {
            if (Choice != Option.SubscribeCov)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SubscribeCov)}.");
            }
            return (SubscribeCovRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.SubscribeCov"/>.
    /// </summary>
    public bool TryGetSubscribeCov(out SubscribeCovRequest value)
    {
        if (Choice == Option.SubscribeCov)
        {
            value = (SubscribeCovRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.SubscribeCov"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromSubscribeCov(SubscribeCovRequest value)
    {
        return new ConfirmedServiceRequest(Option.SubscribeCov, value);
    }

    /// <summary>
    /// Request to subscribe for COV on a specific property.
    /// </summary>
    public SubscribeCovPropertyRequest SubscribeCovProperty
    {
        get
        {
            if (Choice != Option.SubscribeCovProperty)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SubscribeCovProperty)}.");
            }
            return (SubscribeCovPropertyRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.SubscribeCovProperty"/>.
    /// </summary>
    public bool TryGetSubscribeCovProperty(out SubscribeCovPropertyRequest value)
    {
        if (Choice == Option.SubscribeCovProperty)
        {
            value = (SubscribeCovPropertyRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.SubscribeCovProperty"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromSubscribeCovProperty(SubscribeCovPropertyRequest value)
    {
        return new ConfirmedServiceRequest(Option.SubscribeCovProperty, value);
    }

    /// <summary>
    /// Request to subscribe for multiple COV properties.
    /// </summary>
    public SubscribeCovPropertyMultipleRequest SubscribeCovPropertyMultiple
    {
        get
        {
            if (Choice != Option.SubscribeCovPropertyMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SubscribeCovPropertyMultiple)}.");
            }
            return (SubscribeCovPropertyMultipleRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.SubscribeCovPropertyMultiple"/>.
    /// </summary>
    public bool TryGetSubscribeCovPropertyMultiple(out SubscribeCovPropertyMultipleRequest value)
    {
        if (Choice == Option.SubscribeCovPropertyMultiple)
        {
            value = (SubscribeCovPropertyMultipleRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.SubscribeCovPropertyMultiple"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromSubscribeCovPropertyMultiple(SubscribeCovPropertyMultipleRequest value)
    {
        return new ConfirmedServiceRequest(Option.SubscribeCovPropertyMultiple, value);
    }

    /// <summary>
    /// Request for confirmed audit notification.
    /// </summary>
    public ConfirmedAuditNotificationRequest ConfirmedAuditNotification
    {
        get
        {
            if (Choice != Option.ConfirmedAuditNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedAuditNotification)}.");
            }
            return (ConfirmedAuditNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedAuditNotification"/>.
    /// </summary>
    public bool TryGetConfirmedAuditNotification(out ConfirmedAuditNotificationRequest value)
    {
        if (Choice == Option.ConfirmedAuditNotification)
        {
            value = (ConfirmedAuditNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedAuditNotification"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedAuditNotification(ConfirmedAuditNotificationRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedAuditNotification, value);
    }

    /// <summary>
    /// Request to read a file atomically.
    /// </summary>
    public AtomicReadFileRequest AtomicReadFile
    {
        get
        {
            if (Choice != Option.AtomicReadFile)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AtomicReadFile)}.");
            }
            return (AtomicReadFileRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AtomicReadFile"/>.
    /// </summary>
    public bool TryGetAtomicReadFile(out AtomicReadFileRequest value)
    {
        if (Choice == Option.AtomicReadFile)
        {
            value = (AtomicReadFileRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AtomicReadFile"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAtomicReadFile(AtomicReadFileRequest value)
    {
        return new ConfirmedServiceRequest(Option.AtomicReadFile, value);
    }

    /// <summary>
    /// Request to write a file atomically.
    /// </summary>
    public AtomicWriteFileRequest AtomicWriteFile
    {
        get
        {
            if (Choice != Option.AtomicWriteFile)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AtomicWriteFile)}.");
            }
            return (AtomicWriteFileRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AtomicWriteFile"/>.
    /// </summary>
    public bool TryGetAtomicWriteFile(out AtomicWriteFileRequest value)
    {
        if (Choice == Option.AtomicWriteFile)
        {
            value = (AtomicWriteFileRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AtomicWriteFile"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAtomicWriteFile(AtomicWriteFileRequest value)
    {
        return new ConfirmedServiceRequest(Option.AtomicWriteFile, value);
    }

    /// <summary>
    /// Request to add elements to a list property.
    /// </summary>
    public AddListElementRequest AddListElement
    {
        get
        {
            if (Choice != Option.AddListElement)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AddListElement)}.");
            }
            return (AddListElementRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AddListElement"/>.
    /// </summary>
    public bool TryGetAddListElement(out AddListElementRequest value)
    {
        if (Choice == Option.AddListElement)
        {
            value = (AddListElementRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AddListElement"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAddListElement(AddListElementRequest value)
    {
        return new ConfirmedServiceRequest(Option.AddListElement, value);
    }

    /// <summary>
    /// Request to remove elements from a list property.
    /// </summary>
    public RemoveListElementRequest RemoveListElement
    {
        get
        {
            if (Choice != Option.RemoveListElement)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RemoveListElement)}.");
            }
            return (RemoveListElementRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.RemoveListElement"/>.
    /// </summary>
    public bool TryGetRemoveListElement(out RemoveListElementRequest value)
    {
        if (Choice == Option.RemoveListElement)
        {
            value = (RemoveListElementRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.RemoveListElement"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromRemoveListElement(RemoveListElementRequest value)
    {
        return new ConfirmedServiceRequest(Option.RemoveListElement, value);
    }

    /// <summary>
    /// Request to create an object.
    /// </summary>
    public CreateObjectRequest CreateObject
    {
        get
        {
            if (Choice != Option.CreateObject)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CreateObject)}.");
            }
            return (CreateObjectRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.CreateObject"/>.
    /// </summary>
    public bool TryGetCreateObject(out CreateObjectRequest value)
    {
        if (Choice == Option.CreateObject)
        {
            value = (CreateObjectRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.CreateObject"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromCreateObject(CreateObjectRequest value)
    {
        return new ConfirmedServiceRequest(Option.CreateObject, value);
    }

    /// <summary>
    /// Request to delete an object.
    /// </summary>
    public DeleteObjectRequest DeleteObject
    {
        get
        {
            if (Choice != Option.DeleteObject)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DeleteObject)}.");
            }
            return (DeleteObjectRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.DeleteObject"/>.
    /// </summary>
    public bool TryGetDeleteObject(out DeleteObjectRequest value)
    {
        if (Choice == Option.DeleteObject)
        {
            value = (DeleteObjectRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.DeleteObject"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromDeleteObject(DeleteObjectRequest value)
    {
        return new ConfirmedServiceRequest(Option.DeleteObject, value);
    }

    /// <summary>
    /// Request to read a property.
    /// </summary>
    public ReadPropertyRequest ReadProperty
    {
        get
        {
            if (Choice != Option.ReadProperty)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadProperty)}.");
            }
            return (ReadPropertyRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ReadProperty"/>.
    /// </summary>
    public bool TryGetReadProperty(out ReadPropertyRequest value)
    {
        if (Choice == Option.ReadProperty)
        {
            value = (ReadPropertyRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadProperty"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromReadProperty(ReadPropertyRequest value)
    {
        return new ConfirmedServiceRequest(Option.ReadProperty, value);
    }

    /// <summary>
    /// Request to read multiple properties.
    /// </summary>
    public ReadPropertyMultipleRequest ReadPropertyMultiple
    {
        get
        {
            if (Choice != Option.ReadPropertyMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadPropertyMultiple)}.");
            }
            return (ReadPropertyMultipleRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ReadPropertyMultiple"/>.
    /// </summary>
    public bool TryGetReadPropertyMultiple(out ReadPropertyMultipleRequest value)
    {
        if (Choice == Option.ReadPropertyMultiple)
        {
            value = (ReadPropertyMultipleRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadPropertyMultiple"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromReadPropertyMultiple(ReadPropertyMultipleRequest value)
    {
        return new ConfirmedServiceRequest(Option.ReadPropertyMultiple, value);
    }

    /// <summary>
    /// Request to read a range from a list or log.
    /// </summary>
    public ReadRangeRequest ReadRange
    {
        get
        {
            if (Choice != Option.ReadRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadRange)}.");
            }
            return (ReadRangeRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ReadRange"/>.
    /// </summary>
    public bool TryGetReadRange(out ReadRangeRequest value)
    {
        if (Choice == Option.ReadRange)
        {
            value = (ReadRangeRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadRange"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromReadRange(ReadRangeRequest value)
    {
        return new ConfirmedServiceRequest(Option.ReadRange, value);
    }

    /// <summary>
    /// Request to write a property.
    /// </summary>
    public WritePropertyRequest WriteProperty
    {
        get
        {
            if (Choice != Option.WriteProperty)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WriteProperty)}.");
            }
            return (WritePropertyRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WriteProperty"/>.
    /// </summary>
    public bool TryGetWriteProperty(out WritePropertyRequest value)
    {
        if (Choice == Option.WriteProperty)
        {
            value = (WritePropertyRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WriteProperty"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromWriteProperty(WritePropertyRequest value)
    {
        return new ConfirmedServiceRequest(Option.WriteProperty, value);
    }

    /// <summary>
    /// Request to write multiple properties.
    /// </summary>
    public WritePropertyMultipleRequest WritePropertyMultiple
    {
        get
        {
            if (Choice != Option.WritePropertyMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WritePropertyMultiple)}.");
            }
            return (WritePropertyMultipleRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WritePropertyMultiple"/>.
    /// </summary>
    public bool TryGetWritePropertyMultiple(out WritePropertyMultipleRequest value)
    {
        if (Choice == Option.WritePropertyMultiple)
        {
            value = (WritePropertyMultipleRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WritePropertyMultiple"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromWritePropertyMultiple(WritePropertyMultipleRequest value)
    {
        return new ConfirmedServiceRequest(Option.WritePropertyMultiple, value);
    }

    /// <summary>
    /// Request to query the audit log.
    /// </summary>
    public AuditLogQueryRequest AuditLogQuery
    {
        get
        {
            if (Choice != Option.AuditLogQuery)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuditLogQuery)}.");
            }
            return (AuditLogQueryRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AuditLogQuery"/>.
    /// </summary>
    public bool TryGetAuditLogQuery(out AuditLogQueryRequest value)
    {
        if (Choice == Option.AuditLogQuery)
        {
            value = (AuditLogQueryRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AuditLogQuery"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAuditLogQuery(AuditLogQueryRequest value)
    {
        return new ConfirmedServiceRequest(Option.AuditLogQuery, value);
    }

    /// <summary>
    /// Request to control device communications.
    /// </summary>
    public DeviceCommunicationControlRequest DeviceCommunicationControl
    {
        get
        {
            if (Choice != Option.DeviceCommunicationControl)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DeviceCommunicationControl)}.");
            }
            return (DeviceCommunicationControlRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.DeviceCommunicationControl"/>.
    /// </summary>
    public bool TryGetDeviceCommunicationControl(out DeviceCommunicationControlRequest value)
    {
        if (Choice == Option.DeviceCommunicationControl)
        {
            value = (DeviceCommunicationControlRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.DeviceCommunicationControl"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromDeviceCommunicationControl(DeviceCommunicationControlRequest value)
    {
        return new ConfirmedServiceRequest(Option.DeviceCommunicationControl, value);
    }

    /// <summary>
    /// Request for confirmed private transfer.
    /// </summary>
    public ConfirmedPrivateTransferRequest ConfirmedPrivateTransfer
    {
        get
        {
            if (Choice != Option.ConfirmedPrivateTransfer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedPrivateTransfer)}.");
            }
            return (ConfirmedPrivateTransferRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedPrivateTransfer"/>.
    /// </summary>
    public bool TryGetConfirmedPrivateTransfer(out ConfirmedPrivateTransferRequest value)
    {
        if (Choice == Option.ConfirmedPrivateTransfer)
        {
            value = (ConfirmedPrivateTransferRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedPrivateTransfer"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedPrivateTransfer(ConfirmedPrivateTransferRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedPrivateTransfer, value);
    }

    /// <summary>
    /// Request for a confirmed text message.
    /// </summary>
    public ConfirmedTextMessageRequest ConfirmedTextMessage
    {
        get
        {
            if (Choice != Option.ConfirmedTextMessage)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedTextMessage)}.");
            }
            return (ConfirmedTextMessageRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedTextMessage"/>.
    /// </summary>
    public bool TryGetConfirmedTextMessage(out ConfirmedTextMessageRequest value)
    {
        if (Choice == Option.ConfirmedTextMessage)
        {
            value = (ConfirmedTextMessageRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedTextMessage"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromConfirmedTextMessage(ConfirmedTextMessageRequest value)
    {
        return new ConfirmedServiceRequest(Option.ConfirmedTextMessage, value);
    }

    /// <summary>
    /// Request to reinitialize a device.
    /// </summary>
    public ReinitializeDeviceRequest ReinitializeDevice
    {
        get
        {
            if (Choice != Option.ReinitializeDevice)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReinitializeDevice)}.");
            }
            return (ReinitializeDeviceRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ReinitializeDevice"/>.
    /// </summary>
    public bool TryGetReinitializeDevice(out ReinitializeDeviceRequest value)
    {
        if (Choice == Option.ReinitializeDevice)
        {
            value = (ReinitializeDeviceRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReinitializeDevice"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromReinitializeDevice(ReinitializeDeviceRequest value)
    {
        return new ConfirmedServiceRequest(Option.ReinitializeDevice, value);
    }

    /// <summary>
    /// Request for authentication services.
    /// </summary>
    public AuthRequestRequest AuthRequest
    {
        get
        {
            if (Choice != Option.AuthRequest)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuthRequest)}.");
            }
            return (AuthRequestRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.AuthRequest"/>.
    /// </summary>
    public bool TryGetAuthRequest(out AuthRequestRequest value)
    {
        if (Choice == Option.AuthRequest)
        {
            value = (AuthRequestRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AuthRequest"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromAuthRequest(AuthRequestRequest value)
    {
        return new ConfirmedServiceRequest(Option.AuthRequest, value);
    }

    /// <summary>
    /// Request to open a virtual terminal session.
    /// </summary>
    public VtOpenRequest VtOpen
    {
        get
        {
            if (Choice != Option.VtOpen)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.VtOpen)}.");
            }
            return (VtOpenRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.VtOpen"/>.
    /// </summary>
    public bool TryGetVtOpen(out VtOpenRequest value)
    {
        if (Choice == Option.VtOpen)
        {
            value = (VtOpenRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.VtOpen"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromVtOpen(VtOpenRequest value)
    {
        return new ConfirmedServiceRequest(Option.VtOpen, value);
    }

    /// <summary>
    /// Request to close a virtual terminal session.
    /// </summary>
    public VtCloseRequest VtClose
    {
        get
        {
            if (Choice != Option.VtClose)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.VtClose)}.");
            }
            return (VtCloseRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.VtClose"/>.
    /// </summary>
    public bool TryGetVtClose(out VtCloseRequest value)
    {
        if (Choice == Option.VtClose)
        {
            value = (VtCloseRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.VtClose"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromVtClose(VtCloseRequest value)
    {
        return new ConfirmedServiceRequest(Option.VtClose, value);
    }

    /// <summary>
    /// Request to transfer virtual terminal data.
    /// </summary>
    public VtDataRequest VtData
    {
        get
        {
            if (Choice != Option.VtData)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.VtData)}.");
            }
            return (VtDataRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.VtData"/>.
    /// </summary>
    public bool TryGetVtData(out VtDataRequest value)
    {
        if (Choice == Option.VtData)
        {
            value = (VtDataRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.VtData"/> option.
    /// </summary>
    public static ConfirmedServiceRequest FromVtData(VtDataRequest value)
    {
        return new ConfirmedServiceRequest(Option.VtData, value);
    }
}
