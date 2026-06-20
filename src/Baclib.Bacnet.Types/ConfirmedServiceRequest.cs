// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private ConfirmedServiceRequest(Option choice, object value)
    {
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
    /// Create function for Request to acknowledge an alarm.
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
    /// Create function for Request for confirmed COV notification.
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
    /// Create function for Request for confirmed COV notification multiple.
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
    /// Create function for Request for confirmed event notification.
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
    /// Create function for Request for enrollment summary.
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
    /// Create function for Request for event information.
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
    /// Create function for Request for life safety operation.
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
    /// Create function for Request to subscribe for COV notifications.
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
    /// Create function for Request to subscribe for COV on a specific property.
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
    /// Create function for Request to subscribe for multiple COV properties.
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
    /// Create function for Request for confirmed audit notification.
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
    /// Create function for Request to read a file atomically.
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
    /// Create function for Request to write a file atomically.
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
    /// Create function for Request to add elements to a list property.
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
    /// Create function for Request to remove elements from a list property.
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
    /// Create function for Request to create an object.
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
    /// Create function for Request to delete an object.
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
    /// Create function for Request to read a property.
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
    /// Create function for Request to read multiple properties.
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
    /// Create function for Request to read a range from a list or log.
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
    /// Create function for Request to write a property.
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
    /// Create function for Request to write multiple properties.
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
    /// Create function for Request to query the audit log.
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
    /// Create function for Request to control device communications.
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
    /// Create function for Request for confirmed private transfer.
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
    /// Create function for Request for a confirmed text message.
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
    /// Create function for Request to reinitialize a device.
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
    /// Create function for Request for authentication services.
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
    /// Create function for Request to open a virtual terminal session.
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
    /// Create function for Request to close a virtual terminal session.
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
    /// Create function for Request to transfer virtual terminal data.
    /// </summary>
    public static ConfirmedServiceRequest FromVtData(VtDataRequest value)
    {
        return new ConfirmedServiceRequest(Option.VtData, value);
    }
}
