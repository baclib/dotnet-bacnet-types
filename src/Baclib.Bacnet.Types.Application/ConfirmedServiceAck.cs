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

    private readonly object _choiceValue;

    private ConfirmedServiceAck(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
    /// Tries to get the value when the active choice is <see cref="Option.GetAlarmSummary"/>.
    /// </summary>
    public bool TryGetGetAlarmSummary(out GetAlarmSummaryAck value)
    {
        if (Choice == Option.GetAlarmSummary)
        {
            value = (GetAlarmSummaryAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.GetAlarmSummary"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.GetEnrollmentSummary"/>.
    /// </summary>
    public bool TryGetGetEnrollmentSummary(out GetEnrollmentSummaryAck value)
    {
        if (Choice == Option.GetEnrollmentSummary)
        {
            value = (GetEnrollmentSummaryAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.GetEnrollmentSummary"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.GetEventInformation"/>.
    /// </summary>
    public bool TryGetGetEventInformation(out GetEventInformationAck value)
    {
        if (Choice == Option.GetEventInformation)
        {
            value = (GetEventInformationAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.GetEventInformation"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.AtomicReadFile"/>.
    /// </summary>
    public bool TryGetAtomicReadFile(out AtomicReadFileAck value)
    {
        if (Choice == Option.AtomicReadFile)
        {
            value = (AtomicReadFileAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AtomicReadFile"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.AtomicWriteFile"/>.
    /// </summary>
    public bool TryGetAtomicWriteFile(out AtomicWriteFileAck value)
    {
        if (Choice == Option.AtomicWriteFile)
        {
            value = (AtomicWriteFileAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AtomicWriteFile"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.CreateObject"/>.
    /// </summary>
    public bool TryGetCreateObject(out CreateObjectAck value)
    {
        if (Choice == Option.CreateObject)
        {
            value = (CreateObjectAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.CreateObject"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.ReadProperty"/>.
    /// </summary>
    public bool TryGetReadProperty(out ReadPropertyAck value)
    {
        if (Choice == Option.ReadProperty)
        {
            value = (ReadPropertyAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadProperty"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.ReadPropertyMultiple"/>.
    /// </summary>
    public bool TryGetReadPropertyMultiple(out ReadPropertyMultipleAck value)
    {
        if (Choice == Option.ReadPropertyMultiple)
        {
            value = (ReadPropertyMultipleAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadPropertyMultiple"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.ReadRange"/>.
    /// </summary>
    public bool TryGetReadRange(out ReadRangeAck value)
    {
        if (Choice == Option.ReadRange)
        {
            value = (ReadRangeAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ReadRange"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.AuditLogQuery"/>.
    /// </summary>
    public bool TryGetAuditLogQuery(out AuditLogQueryAck value)
    {
        if (Choice == Option.AuditLogQuery)
        {
            value = (AuditLogQueryAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AuditLogQuery"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.ConfirmedPrivateTransfer"/>.
    /// </summary>
    public bool TryGetConfirmedPrivateTransfer(out ConfirmedPrivateTransferAck value)
    {
        if (Choice == Option.ConfirmedPrivateTransfer)
        {
            value = (ConfirmedPrivateTransferAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ConfirmedPrivateTransfer"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.AuthRequest"/>.
    /// </summary>
    public bool TryGetAuthRequest(out AuthRequestAck value)
    {
        if (Choice == Option.AuthRequest)
        {
            value = (AuthRequestAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.AuthRequest"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.VtOpen"/>.
    /// </summary>
    public bool TryGetVtOpen(out VtOpenAck value)
    {
        if (Choice == Option.VtOpen)
        {
            value = (VtOpenAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.VtOpen"/> option.
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
    /// Tries to get the value when the active choice is <see cref="Option.VtData"/>.
    /// </summary>
    public bool TryGetVtData(out VtDataAck value)
    {
        if (Choice == Option.VtData)
        {
            value = (VtDataAck)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.VtData"/> option.
    /// </summary>
    public static ConfirmedServiceAck FromVtData(VtDataAck value)
    {
        return new ConfirmedServiceAck(Option.VtData, value);
    }
}
