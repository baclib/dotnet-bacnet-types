// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnet-Confirmed-Service-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedServiceAck
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Acknowledgment for Get Alarm Summary.
        /// </summary>
        GetAlarmSummary,

        /// <summary>
        /// Acknowledgment for Get Enrollment Summary.
        /// </summary>
        GetEnrollmentSummary,

        /// <summary>
        /// Acknowledgment for Get Event Information.
        /// </summary>
        GetEventInformation,

        /// <summary>
        /// Acknowledgment for Atomic Read File.
        /// </summary>
        AtomicReadFile,

        /// <summary>
        /// Acknowledgment for Atomic Write File.
        /// </summary>
        AtomicWriteFile,

        /// <summary>
        /// Acknowledgment for Create Object.
        /// </summary>
        CreateObject,

        /// <summary>
        /// Acknowledgment for Read Property.
        /// </summary>
        ReadProperty,

        /// <summary>
        /// Acknowledgment for Read Property Multiple.
        /// </summary>
        ReadPropertyMultiple,

        /// <summary>
        /// Acknowledgment for Read Range.
        /// </summary>
        ReadRange,

        /// <summary>
        /// Acknowledgment for Audit Log Query.
        /// </summary>
        AuditLogQuery,

        /// <summary>
        /// Acknowledgment for Confirmed Private Transfer.
        /// </summary>
        ConfirmedPrivateTransfer,

        /// <summary>
        /// Acknowledgment for Authentication Request.
        /// </summary>
        AuthRequest,

        /// <summary>
        /// Acknowledgment for VT Open.
        /// </summary>
        VtOpen,

        /// <summary>
        /// Acknowledgment for VT Data.
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

    private ConfirmedServiceAck(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Acknowledgment for Get Alarm Summary.
    /// </summary>
    public GetAlarmSummaryAck GetAlarmSummary
    {
        get
        {
            if (Choice != Option.GetAlarmSummary)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.GetAlarmSummary)}.");
            }
            return (GetAlarmSummaryAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Get Alarm Summary.
    /// </summary>
    public static ConfirmedServiceAck FromGetAlarmSummary(GetAlarmSummaryAck value)
    {
        return new ConfirmedServiceAck(Option.GetAlarmSummary, value);
    }

    /// <summary>
    /// Acknowledgment for Get Enrollment Summary.
    /// </summary>
    public GetEnrollmentSummaryAck GetEnrollmentSummary
    {
        get
        {
            if (Choice != Option.GetEnrollmentSummary)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.GetEnrollmentSummary)}.");
            }
            return (GetEnrollmentSummaryAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Get Enrollment Summary.
    /// </summary>
    public static ConfirmedServiceAck FromGetEnrollmentSummary(GetEnrollmentSummaryAck value)
    {
        return new ConfirmedServiceAck(Option.GetEnrollmentSummary, value);
    }

    /// <summary>
    /// Acknowledgment for Get Event Information.
    /// </summary>
    public GetEventInformationAck GetEventInformation
    {
        get
        {
            if (Choice != Option.GetEventInformation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.GetEventInformation)}.");
            }
            return (GetEventInformationAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Get Event Information.
    /// </summary>
    public static ConfirmedServiceAck FromGetEventInformation(GetEventInformationAck value)
    {
        return new ConfirmedServiceAck(Option.GetEventInformation, value);
    }

    /// <summary>
    /// Acknowledgment for Atomic Read File.
    /// </summary>
    public AtomicReadFileAck AtomicReadFile
    {
        get
        {
            if (Choice != Option.AtomicReadFile)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AtomicReadFile)}.");
            }
            return (AtomicReadFileAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Atomic Read File.
    /// </summary>
    public static ConfirmedServiceAck FromAtomicReadFile(AtomicReadFileAck value)
    {
        return new ConfirmedServiceAck(Option.AtomicReadFile, value);
    }

    /// <summary>
    /// Acknowledgment for Atomic Write File.
    /// </summary>
    public AtomicWriteFileAck AtomicWriteFile
    {
        get
        {
            if (Choice != Option.AtomicWriteFile)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AtomicWriteFile)}.");
            }
            return (AtomicWriteFileAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Atomic Write File.
    /// </summary>
    public static ConfirmedServiceAck FromAtomicWriteFile(AtomicWriteFileAck value)
    {
        return new ConfirmedServiceAck(Option.AtomicWriteFile, value);
    }

    /// <summary>
    /// Acknowledgment for Create Object.
    /// </summary>
    public CreateObjectAck CreateObject
    {
        get
        {
            if (Choice != Option.CreateObject)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.CreateObject)}.");
            }
            return (CreateObjectAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Create Object.
    /// </summary>
    public static ConfirmedServiceAck FromCreateObject(CreateObjectAck value)
    {
        return new ConfirmedServiceAck(Option.CreateObject, value);
    }

    /// <summary>
    /// Acknowledgment for Read Property.
    /// </summary>
    public ReadPropertyAck ReadProperty
    {
        get
        {
            if (Choice != Option.ReadProperty)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadProperty)}.");
            }
            return (ReadPropertyAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Read Property.
    /// </summary>
    public static ConfirmedServiceAck FromReadProperty(ReadPropertyAck value)
    {
        return new ConfirmedServiceAck(Option.ReadProperty, value);
    }

    /// <summary>
    /// Acknowledgment for Read Property Multiple.
    /// </summary>
    public ReadPropertyMultipleAck ReadPropertyMultiple
    {
        get
        {
            if (Choice != Option.ReadPropertyMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadPropertyMultiple)}.");
            }
            return (ReadPropertyMultipleAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Read Property Multiple.
    /// </summary>
    public static ConfirmedServiceAck FromReadPropertyMultiple(ReadPropertyMultipleAck value)
    {
        return new ConfirmedServiceAck(Option.ReadPropertyMultiple, value);
    }

    /// <summary>
    /// Acknowledgment for Read Range.
    /// </summary>
    public ReadRangeAck ReadRange
    {
        get
        {
            if (Choice != Option.ReadRange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReadRange)}.");
            }
            return (ReadRangeAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Read Range.
    /// </summary>
    public static ConfirmedServiceAck FromReadRange(ReadRangeAck value)
    {
        return new ConfirmedServiceAck(Option.ReadRange, value);
    }

    /// <summary>
    /// Acknowledgment for Audit Log Query.
    /// </summary>
    public AuditLogQueryAck AuditLogQuery
    {
        get
        {
            if (Choice != Option.AuditLogQuery)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuditLogQuery)}.");
            }
            return (AuditLogQueryAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Audit Log Query.
    /// </summary>
    public static ConfirmedServiceAck FromAuditLogQuery(AuditLogQueryAck value)
    {
        return new ConfirmedServiceAck(Option.AuditLogQuery, value);
    }

    /// <summary>
    /// Acknowledgment for Confirmed Private Transfer.
    /// </summary>
    public ConfirmedPrivateTransferAck ConfirmedPrivateTransfer
    {
        get
        {
            if (Choice != Option.ConfirmedPrivateTransfer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedPrivateTransfer)}.");
            }
            return (ConfirmedPrivateTransferAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Confirmed Private Transfer.
    /// </summary>
    public static ConfirmedServiceAck FromConfirmedPrivateTransfer(ConfirmedPrivateTransferAck value)
    {
        return new ConfirmedServiceAck(Option.ConfirmedPrivateTransfer, value);
    }

    /// <summary>
    /// Acknowledgment for Authentication Request.
    /// </summary>
    public AuthRequestAck AuthRequest
    {
        get
        {
            if (Choice != Option.AuthRequest)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuthRequest)}.");
            }
            return (AuthRequestAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for Authentication Request.
    /// </summary>
    public static ConfirmedServiceAck FromAuthRequest(AuthRequestAck value)
    {
        return new ConfirmedServiceAck(Option.AuthRequest, value);
    }

    /// <summary>
    /// Acknowledgment for VT Open.
    /// </summary>
    public VtOpenAck VtOpen
    {
        get
        {
            if (Choice != Option.VtOpen)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.VtOpen)}.");
            }
            return (VtOpenAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for VT Open.
    /// </summary>
    public static ConfirmedServiceAck FromVtOpen(VtOpenAck value)
    {
        return new ConfirmedServiceAck(Option.VtOpen, value);
    }

    /// <summary>
    /// Acknowledgment for VT Data.
    /// </summary>
    public VtDataAck VtData
    {
        get
        {
            if (Choice != Option.VtData)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.VtData)}.");
            }
            return (VtDataAck)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Acknowledgment for VT Data.
    /// </summary>
    public static ConfirmedServiceAck FromVtData(VtDataAck value)
    {
        return new ConfirmedServiceAck(Option.VtData, value);
    }
}
