// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice BACnetPropertyStates as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class PropertyStates
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A boolean property state (true/false).
        /// </summary>
        BooleanValue,

        /// <summary>
        /// A binary present value property state.
        /// </summary>
        BinaryValue,

        /// <summary>
        /// The type of event for the property.
        /// </summary>
        EventType,

        /// <summary>
        /// The polarity state of the property.
        /// </summary>
        Polarity,

        /// <summary>
        /// A program change request state.
        /// </summary>
        ProgramChange,

        /// <summary>
        /// The state of a program.
        /// </summary>
        ProgramState,

        /// <summary>
        /// The reason for a program halt.
        /// </summary>
        ReasonForHalt,

        /// <summary>
        /// The reliability state of the property.
        /// </summary>
        Reliability,

        /// <summary>
        /// The event state of the property.
        /// </summary>
        State,

        /// <summary>
        /// The system status of the device.
        /// </summary>
        SystemStatus,

        /// <summary>
        /// The engineering units of the property.
        /// </summary>
        Units,

        /// <summary>
        /// An unsigned integer value.
        /// </summary>
        UnsignedValue,

        /// <summary>
        /// The life safety mode state.
        /// </summary>
        LifeSafetyMode,

        /// <summary>
        /// The life safety state.
        /// </summary>
        LifeSafetyState,

        /// <summary>
        /// The reason for device restart.
        /// </summary>
        RestartReason,

        /// <summary>
        /// The alarm state of a door.
        /// </summary>
        DoorAlarmState,

        /// <summary>
        /// An action state.
        /// </summary>
        Action,

        /// <summary>
        /// The secured status of a door.
        /// </summary>
        DoorSecuredStatus,

        /// <summary>
        /// The status of a door.
        /// </summary>
        DoorStatus,

        /// <summary>
        /// The value state of a door.
        /// </summary>
        DoorValue,

        /// <summary>
        /// The file access method state.
        /// </summary>
        FileAccessMethod,

        /// <summary>
        /// The lock status state.
        /// </summary>
        LockStatus,

        /// <summary>
        /// The life safety operation state.
        /// </summary>
        LifeSafetyOperation,

        /// <summary>
        /// The maintenance state.
        /// </summary>
        Maintenance,

        /// <summary>
        /// The node type state.
        /// </summary>
        NodeType,

        /// <summary>
        /// The notification type state.
        /// </summary>
        NotifyType,

        /// <summary>
        /// The shed state.
        /// </summary>
        ShedState,

        /// <summary>
        /// The silenced state.
        /// </summary>
        SilencedState,

        /// <summary>
        /// The access event state.
        /// </summary>
        AccessEvent,

        /// <summary>
        /// The occupancy state of an access zone.
        /// </summary>
        ZoneOccupancyState,

        /// <summary>
        /// The reason for disabling an access credential.
        /// </summary>
        AccessCredentialDisableReason,

        /// <summary>
        /// The disable state of an access credential.
        /// </summary>
        AccessCredentialDisable,

        /// <summary>
        /// The authentication status state.
        /// </summary>
        AuthenticationStatus,

        /// <summary>
        /// The backup state.
        /// </summary>
        BackupState,

        /// <summary>
        /// The write status state.
        /// </summary>
        WriteStatus,

        /// <summary>
        /// The lighting in progress state.
        /// </summary>
        LightingInProgress,

        /// <summary>
        /// The lighting operation state.
        /// </summary>
        LightingOperation,

        /// <summary>
        /// The lighting transition state.
        /// </summary>
        LightingTransition,

        /// <summary>
        /// An integer value state.
        /// </summary>
        IntegerValue,

        /// <summary>
        /// A binary lighting present value state.
        /// </summary>
        BinaryLightingValue,

        /// <summary>
        /// The timer state.
        /// </summary>
        TimerState,

        /// <summary>
        /// The timer transition state.
        /// </summary>
        TimerTransition,

        /// <summary>
        /// The BACnet/IP mode state.
        /// </summary>
        BacnetIpMode,

        /// <summary>
        /// The network port command state.
        /// </summary>
        NetworkPortCommand,

        /// <summary>
        /// The network type state.
        /// </summary>
        NetworkType,

        /// <summary>
        /// The network number quality state.
        /// </summary>
        NetworkNumberQuality,

        /// <summary>
        /// The operation direction of an escalator.
        /// </summary>
        EscalatorOperationDirection,

        /// <summary>
        /// The fault state of an escalator.
        /// </summary>
        EscalatorFault,

        /// <summary>
        /// The mode state of an escalator.
        /// </summary>
        EscalatorMode,

        /// <summary>
        /// The direction state of a lift car.
        /// </summary>
        LiftCarDirection,

        /// <summary>
        /// The door command state of a lift car.
        /// </summary>
        LiftCarDoorCommand,

        /// <summary>
        /// The drive status of a lift car.
        /// </summary>
        LiftCarDriveStatus,

        /// <summary>
        /// The mode state of a lift car.
        /// </summary>
        LiftCarMode,

        /// <summary>
        /// The mode state of a lift group.
        /// </summary>
        LiftGroupMode,

        /// <summary>
        /// The fault state of a lift.
        /// </summary>
        LiftFault,

        /// <summary>
        /// The protocol level state.
        /// </summary>
        ProtocolLevel,

        /// <summary>
        /// The audit level state.
        /// </summary>
        AuditLevel,

        /// <summary>
        /// The audit operation state.
        /// </summary>
        AuditOperation,

        /// <summary>
        /// An extended unsigned integer value.
        /// </summary>
        ExtendedValue,

        /// <summary>
        /// The state of a secure connection.
        /// </summary>
        ScConnectionState,

        /// <summary>
        /// The state of a secure hub connector.
        /// </summary>
        ScHubConnectorState
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private PropertyStates(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A boolean property state (true/false).
    /// </summary>
    public Boolean BooleanValue
    {
        get
        {
            if (Choice != Option.BooleanValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BooleanValue)}.");
            }
            return (Boolean)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A boolean property state (true/false).
    /// </summary>
    public static PropertyStates FromBooleanValue(Boolean value)
    {
        return new PropertyStates(Option.BooleanValue, value);
    }

    /// <summary>
    /// A binary present value property state.
    /// </summary>
    public BinaryPv BinaryValue
    {
        get
        {
            if (Choice != Option.BinaryValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BinaryValue)}.");
            }
            return (BinaryPv)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A binary present value property state.
    /// </summary>
    public static PropertyStates FromBinaryValue(BinaryPv value)
    {
        return new PropertyStates(Option.BinaryValue, value);
    }

    /// <summary>
    /// The type of event for the property.
    /// </summary>
    public EventType EventType
    {
        get
        {
            if (Choice != Option.EventType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EventType)}.");
            }
            return (EventType)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The type of event for the property.
    /// </summary>
    public static PropertyStates FromEventType(EventType value)
    {
        return new PropertyStates(Option.EventType, value);
    }

    /// <summary>
    /// The polarity state of the property.
    /// </summary>
    public Polarity Polarity
    {
        get
        {
            if (Choice != Option.Polarity)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Polarity)}.");
            }
            return (Polarity)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The polarity state of the property.
    /// </summary>
    public static PropertyStates FromPolarity(Polarity value)
    {
        return new PropertyStates(Option.Polarity, value);
    }

    /// <summary>
    /// A program change request state.
    /// </summary>
    public ProgramRequest ProgramChange
    {
        get
        {
            if (Choice != Option.ProgramChange)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ProgramChange)}.");
            }
            return (ProgramRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A program change request state.
    /// </summary>
    public static PropertyStates FromProgramChange(ProgramRequest value)
    {
        return new PropertyStates(Option.ProgramChange, value);
    }

    /// <summary>
    /// The state of a program.
    /// </summary>
    public ProgramState ProgramState
    {
        get
        {
            if (Choice != Option.ProgramState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ProgramState)}.");
            }
            return (ProgramState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The state of a program.
    /// </summary>
    public static PropertyStates FromProgramState(ProgramState value)
    {
        return new PropertyStates(Option.ProgramState, value);
    }

    /// <summary>
    /// The reason for a program halt.
    /// </summary>
    public ProgramError ReasonForHalt
    {
        get
        {
            if (Choice != Option.ReasonForHalt)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ReasonForHalt)}.");
            }
            return (ProgramError)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The reason for a program halt.
    /// </summary>
    public static PropertyStates FromReasonForHalt(ProgramError value)
    {
        return new PropertyStates(Option.ReasonForHalt, value);
    }

    /// <summary>
    /// The reliability state of the property.
    /// </summary>
    public Reliability Reliability
    {
        get
        {
            if (Choice != Option.Reliability)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Reliability)}.");
            }
            return (Reliability)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The reliability state of the property.
    /// </summary>
    public static PropertyStates FromReliability(Reliability value)
    {
        return new PropertyStates(Option.Reliability, value);
    }

    /// <summary>
    /// The event state of the property.
    /// </summary>
    public EventState State
    {
        get
        {
            if (Choice != Option.State)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.State)}.");
            }
            return (EventState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The event state of the property.
    /// </summary>
    public static PropertyStates FromState(EventState value)
    {
        return new PropertyStates(Option.State, value);
    }

    /// <summary>
    /// The system status of the device.
    /// </summary>
    public DeviceStatus SystemStatus
    {
        get
        {
            if (Choice != Option.SystemStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SystemStatus)}.");
            }
            return (DeviceStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The system status of the device.
    /// </summary>
    public static PropertyStates FromSystemStatus(DeviceStatus value)
    {
        return new PropertyStates(Option.SystemStatus, value);
    }

    /// <summary>
    /// The engineering units of the property.
    /// </summary>
    public EngineeringUnits Units
    {
        get
        {
            if (Choice != Option.Units)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Units)}.");
            }
            return (EngineeringUnits)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The engineering units of the property.
    /// </summary>
    public static PropertyStates FromUnits(EngineeringUnits value)
    {
        return new PropertyStates(Option.Units, value);
    }

    /// <summary>
    /// An unsigned integer value.
    /// </summary>
    public Unsigned UnsignedValue
    {
        get
        {
            if (Choice != Option.UnsignedValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnsignedValue)}.");
            }
            return (Unsigned)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An unsigned integer value.
    /// </summary>
    public static PropertyStates FromUnsignedValue(Unsigned value)
    {
        return new PropertyStates(Option.UnsignedValue, value);
    }

    /// <summary>
    /// The life safety mode state.
    /// </summary>
    public LifeSafetyMode LifeSafetyMode
    {
        get
        {
            if (Choice != Option.LifeSafetyMode)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LifeSafetyMode)}.");
            }
            return (LifeSafetyMode)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The life safety mode state.
    /// </summary>
    public static PropertyStates FromLifeSafetyMode(LifeSafetyMode value)
    {
        return new PropertyStates(Option.LifeSafetyMode, value);
    }

    /// <summary>
    /// The life safety state.
    /// </summary>
    public LifeSafetyState LifeSafetyState
    {
        get
        {
            if (Choice != Option.LifeSafetyState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LifeSafetyState)}.");
            }
            return (LifeSafetyState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The life safety state.
    /// </summary>
    public static PropertyStates FromLifeSafetyState(LifeSafetyState value)
    {
        return new PropertyStates(Option.LifeSafetyState, value);
    }

    /// <summary>
    /// The reason for device restart.
    /// </summary>
    public RestartReason RestartReason
    {
        get
        {
            if (Choice != Option.RestartReason)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RestartReason)}.");
            }
            return (RestartReason)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The reason for device restart.
    /// </summary>
    public static PropertyStates FromRestartReason(RestartReason value)
    {
        return new PropertyStates(Option.RestartReason, value);
    }

    /// <summary>
    /// The alarm state of a door.
    /// </summary>
    public DoorAlarmState DoorAlarmState
    {
        get
        {
            if (Choice != Option.DoorAlarmState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoorAlarmState)}.");
            }
            return (DoorAlarmState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The alarm state of a door.
    /// </summary>
    public static PropertyStates FromDoorAlarmState(DoorAlarmState value)
    {
        return new PropertyStates(Option.DoorAlarmState, value);
    }

    /// <summary>
    /// An action state.
    /// </summary>
    public Action Action
    {
        get
        {
            if (Choice != Option.Action)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Action)}.");
            }
            return (Action)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An action state.
    /// </summary>
    public static PropertyStates FromAction(Action value)
    {
        return new PropertyStates(Option.Action, value);
    }

    /// <summary>
    /// The secured status of a door.
    /// </summary>
    public DoorSecuredStatus DoorSecuredStatus
    {
        get
        {
            if (Choice != Option.DoorSecuredStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoorSecuredStatus)}.");
            }
            return (DoorSecuredStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The secured status of a door.
    /// </summary>
    public static PropertyStates FromDoorSecuredStatus(DoorSecuredStatus value)
    {
        return new PropertyStates(Option.DoorSecuredStatus, value);
    }

    /// <summary>
    /// The status of a door.
    /// </summary>
    public DoorStatus DoorStatus
    {
        get
        {
            if (Choice != Option.DoorStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoorStatus)}.");
            }
            return (DoorStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The status of a door.
    /// </summary>
    public static PropertyStates FromDoorStatus(DoorStatus value)
    {
        return new PropertyStates(Option.DoorStatus, value);
    }

    /// <summary>
    /// The value state of a door.
    /// </summary>
    public DoorValue DoorValue
    {
        get
        {
            if (Choice != Option.DoorValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.DoorValue)}.");
            }
            return (DoorValue)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The value state of a door.
    /// </summary>
    public static PropertyStates FromDoorValue(DoorValue value)
    {
        return new PropertyStates(Option.DoorValue, value);
    }

    /// <summary>
    /// The file access method state.
    /// </summary>
    public FileAccessMethod FileAccessMethod
    {
        get
        {
            if (Choice != Option.FileAccessMethod)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FileAccessMethod)}.");
            }
            return (FileAccessMethod)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The file access method state.
    /// </summary>
    public static PropertyStates FromFileAccessMethod(FileAccessMethod value)
    {
        return new PropertyStates(Option.FileAccessMethod, value);
    }

    /// <summary>
    /// The lock status state.
    /// </summary>
    public LockStatus LockStatus
    {
        get
        {
            if (Choice != Option.LockStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LockStatus)}.");
            }
            return (LockStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The lock status state.
    /// </summary>
    public static PropertyStates FromLockStatus(LockStatus value)
    {
        return new PropertyStates(Option.LockStatus, value);
    }

    /// <summary>
    /// The life safety operation state.
    /// </summary>
    public LifeSafetyOperation LifeSafetyOperation
    {
        get
        {
            if (Choice != Option.LifeSafetyOperation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LifeSafetyOperation)}.");
            }
            return (LifeSafetyOperation)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The life safety operation state.
    /// </summary>
    public static PropertyStates FromLifeSafetyOperation(LifeSafetyOperation value)
    {
        return new PropertyStates(Option.LifeSafetyOperation, value);
    }

    /// <summary>
    /// The maintenance state.
    /// </summary>
    public Maintenance Maintenance
    {
        get
        {
            if (Choice != Option.Maintenance)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Maintenance)}.");
            }
            return (Maintenance)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The maintenance state.
    /// </summary>
    public static PropertyStates FromMaintenance(Maintenance value)
    {
        return new PropertyStates(Option.Maintenance, value);
    }

    /// <summary>
    /// The node type state.
    /// </summary>
    public NodeType NodeType
    {
        get
        {
            if (Choice != Option.NodeType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NodeType)}.");
            }
            return (NodeType)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The node type state.
    /// </summary>
    public static PropertyStates FromNodeType(NodeType value)
    {
        return new PropertyStates(Option.NodeType, value);
    }

    /// <summary>
    /// The notification type state.
    /// </summary>
    public NotifyType NotifyType
    {
        get
        {
            if (Choice != Option.NotifyType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NotifyType)}.");
            }
            return (NotifyType)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The notification type state.
    /// </summary>
    public static PropertyStates FromNotifyType(NotifyType value)
    {
        return new PropertyStates(Option.NotifyType, value);
    }

    /// <summary>
    /// The shed state.
    /// </summary>
    public ShedState ShedState
    {
        get
        {
            if (Choice != Option.ShedState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ShedState)}.");
            }
            return (ShedState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The shed state.
    /// </summary>
    public static PropertyStates FromShedState(ShedState value)
    {
        return new PropertyStates(Option.ShedState, value);
    }

    /// <summary>
    /// The silenced state.
    /// </summary>
    public SilencedState SilencedState
    {
        get
        {
            if (Choice != Option.SilencedState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SilencedState)}.");
            }
            return (SilencedState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The silenced state.
    /// </summary>
    public static PropertyStates FromSilencedState(SilencedState value)
    {
        return new PropertyStates(Option.SilencedState, value);
    }

    /// <summary>
    /// The access event state.
    /// </summary>
    public AccessEvent AccessEvent
    {
        get
        {
            if (Choice != Option.AccessEvent)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessEvent)}.");
            }
            return (AccessEvent)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The access event state.
    /// </summary>
    public static PropertyStates FromAccessEvent(AccessEvent value)
    {
        return new PropertyStates(Option.AccessEvent, value);
    }

    /// <summary>
    /// The occupancy state of an access zone.
    /// </summary>
    public AccessZoneOccupancyState ZoneOccupancyState
    {
        get
        {
            if (Choice != Option.ZoneOccupancyState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ZoneOccupancyState)}.");
            }
            return (AccessZoneOccupancyState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The occupancy state of an access zone.
    /// </summary>
    public static PropertyStates FromZoneOccupancyState(AccessZoneOccupancyState value)
    {
        return new PropertyStates(Option.ZoneOccupancyState, value);
    }

    /// <summary>
    /// The reason for disabling an access credential.
    /// </summary>
    public AccessCredentialDisableReason AccessCredentialDisableReason
    {
        get
        {
            if (Choice != Option.AccessCredentialDisableReason)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessCredentialDisableReason)}.");
            }
            return (AccessCredentialDisableReason)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The reason for disabling an access credential.
    /// </summary>
    public static PropertyStates FromAccessCredentialDisableReason(AccessCredentialDisableReason value)
    {
        return new PropertyStates(Option.AccessCredentialDisableReason, value);
    }

    /// <summary>
    /// The disable state of an access credential.
    /// </summary>
    public AccessCredentialDisable AccessCredentialDisable
    {
        get
        {
            if (Choice != Option.AccessCredentialDisable)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AccessCredentialDisable)}.");
            }
            return (AccessCredentialDisable)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The disable state of an access credential.
    /// </summary>
    public static PropertyStates FromAccessCredentialDisable(AccessCredentialDisable value)
    {
        return new PropertyStates(Option.AccessCredentialDisable, value);
    }

    /// <summary>
    /// The authentication status state.
    /// </summary>
    public AuthenticationStatus AuthenticationStatus
    {
        get
        {
            if (Choice != Option.AuthenticationStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuthenticationStatus)}.");
            }
            return (AuthenticationStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The authentication status state.
    /// </summary>
    public static PropertyStates FromAuthenticationStatus(AuthenticationStatus value)
    {
        return new PropertyStates(Option.AuthenticationStatus, value);
    }

    /// <summary>
    /// The backup state.
    /// </summary>
    public BackupState BackupState
    {
        get
        {
            if (Choice != Option.BackupState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BackupState)}.");
            }
            return (BackupState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The backup state.
    /// </summary>
    public static PropertyStates FromBackupState(BackupState value)
    {
        return new PropertyStates(Option.BackupState, value);
    }

    /// <summary>
    /// The write status state.
    /// </summary>
    public WriteStatus WriteStatus
    {
        get
        {
            if (Choice != Option.WriteStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WriteStatus)}.");
            }
            return (WriteStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The write status state.
    /// </summary>
    public static PropertyStates FromWriteStatus(WriteStatus value)
    {
        return new PropertyStates(Option.WriteStatus, value);
    }

    /// <summary>
    /// The lighting in progress state.
    /// </summary>
    public LightingInProgress LightingInProgress
    {
        get
        {
            if (Choice != Option.LightingInProgress)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LightingInProgress)}.");
            }
            return (LightingInProgress)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The lighting in progress state.
    /// </summary>
    public static PropertyStates FromLightingInProgress(LightingInProgress value)
    {
        return new PropertyStates(Option.LightingInProgress, value);
    }

    /// <summary>
    /// The lighting operation state.
    /// </summary>
    public LightingOperation LightingOperation
    {
        get
        {
            if (Choice != Option.LightingOperation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LightingOperation)}.");
            }
            return (LightingOperation)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The lighting operation state.
    /// </summary>
    public static PropertyStates FromLightingOperation(LightingOperation value)
    {
        return new PropertyStates(Option.LightingOperation, value);
    }

    /// <summary>
    /// The lighting transition state.
    /// </summary>
    public LightingTransition LightingTransition
    {
        get
        {
            if (Choice != Option.LightingTransition)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LightingTransition)}.");
            }
            return (LightingTransition)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The lighting transition state.
    /// </summary>
    public static PropertyStates FromLightingTransition(LightingTransition value)
    {
        return new PropertyStates(Option.LightingTransition, value);
    }

    /// <summary>
    /// An integer value state.
    /// </summary>
    public int IntegerValue
    {
        get
        {
            if (Choice != Option.IntegerValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IntegerValue)}.");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An integer value state.
    /// </summary>
    public static PropertyStates FromIntegerValue(int value)
    {
        return new PropertyStates(Option.IntegerValue, value);
    }

    /// <summary>
    /// A binary lighting present value state.
    /// </summary>
    public BinaryLightingPv BinaryLightingValue
    {
        get
        {
            if (Choice != Option.BinaryLightingValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BinaryLightingValue)}.");
            }
            return (BinaryLightingPv)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A binary lighting present value state.
    /// </summary>
    public static PropertyStates FromBinaryLightingValue(BinaryLightingPv value)
    {
        return new PropertyStates(Option.BinaryLightingValue, value);
    }

    /// <summary>
    /// The timer state.
    /// </summary>
    public TimerState TimerState
    {
        get
        {
            if (Choice != Option.TimerState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimerState)}.");
            }
            return (TimerState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The timer state.
    /// </summary>
    public static PropertyStates FromTimerState(TimerState value)
    {
        return new PropertyStates(Option.TimerState, value);
    }

    /// <summary>
    /// The timer transition state.
    /// </summary>
    public TimerTransition TimerTransition
    {
        get
        {
            if (Choice != Option.TimerTransition)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimerTransition)}.");
            }
            return (TimerTransition)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The timer transition state.
    /// </summary>
    public static PropertyStates FromTimerTransition(TimerTransition value)
    {
        return new PropertyStates(Option.TimerTransition, value);
    }

    /// <summary>
    /// The BACnet/IP mode state.
    /// </summary>
    public IpMode BacnetIpMode
    {
        get
        {
            if (Choice != Option.BacnetIpMode)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BacnetIpMode)}.");
            }
            return (IpMode)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The BACnet/IP mode state.
    /// </summary>
    public static PropertyStates FromBacnetIpMode(IpMode value)
    {
        return new PropertyStates(Option.BacnetIpMode, value);
    }

    /// <summary>
    /// The network port command state.
    /// </summary>
    public NetworkPortCommand NetworkPortCommand
    {
        get
        {
            if (Choice != Option.NetworkPortCommand)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NetworkPortCommand)}.");
            }
            return (NetworkPortCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The network port command state.
    /// </summary>
    public static PropertyStates FromNetworkPortCommand(NetworkPortCommand value)
    {
        return new PropertyStates(Option.NetworkPortCommand, value);
    }

    /// <summary>
    /// The network type state.
    /// </summary>
    public NetworkType NetworkType
    {
        get
        {
            if (Choice != Option.NetworkType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NetworkType)}.");
            }
            return (NetworkType)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The network type state.
    /// </summary>
    public static PropertyStates FromNetworkType(NetworkType value)
    {
        return new PropertyStates(Option.NetworkType, value);
    }

    /// <summary>
    /// The network number quality state.
    /// </summary>
    public NetworkNumberQuality NetworkNumberQuality
    {
        get
        {
            if (Choice != Option.NetworkNumberQuality)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.NetworkNumberQuality)}.");
            }
            return (NetworkNumberQuality)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The network number quality state.
    /// </summary>
    public static PropertyStates FromNetworkNumberQuality(NetworkNumberQuality value)
    {
        return new PropertyStates(Option.NetworkNumberQuality, value);
    }

    /// <summary>
    /// The operation direction of an escalator.
    /// </summary>
    public EscalatorOperationDirection EscalatorOperationDirection
    {
        get
        {
            if (Choice != Option.EscalatorOperationDirection)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EscalatorOperationDirection)}.");
            }
            return (EscalatorOperationDirection)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The operation direction of an escalator.
    /// </summary>
    public static PropertyStates FromEscalatorOperationDirection(EscalatorOperationDirection value)
    {
        return new PropertyStates(Option.EscalatorOperationDirection, value);
    }

    /// <summary>
    /// The fault state of an escalator.
    /// </summary>
    public EscalatorFault EscalatorFault
    {
        get
        {
            if (Choice != Option.EscalatorFault)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EscalatorFault)}.");
            }
            return (EscalatorFault)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The fault state of an escalator.
    /// </summary>
    public static PropertyStates FromEscalatorFault(EscalatorFault value)
    {
        return new PropertyStates(Option.EscalatorFault, value);
    }

    /// <summary>
    /// The mode state of an escalator.
    /// </summary>
    public EscalatorMode EscalatorMode
    {
        get
        {
            if (Choice != Option.EscalatorMode)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.EscalatorMode)}.");
            }
            return (EscalatorMode)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The mode state of an escalator.
    /// </summary>
    public static PropertyStates FromEscalatorMode(EscalatorMode value)
    {
        return new PropertyStates(Option.EscalatorMode, value);
    }

    /// <summary>
    /// The direction state of a lift car.
    /// </summary>
    public LiftCarDirection LiftCarDirection
    {
        get
        {
            if (Choice != Option.LiftCarDirection)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftCarDirection)}.");
            }
            return (LiftCarDirection)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The direction state of a lift car.
    /// </summary>
    public static PropertyStates FromLiftCarDirection(LiftCarDirection value)
    {
        return new PropertyStates(Option.LiftCarDirection, value);
    }

    /// <summary>
    /// The door command state of a lift car.
    /// </summary>
    public LiftCarDoorCommand LiftCarDoorCommand
    {
        get
        {
            if (Choice != Option.LiftCarDoorCommand)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftCarDoorCommand)}.");
            }
            return (LiftCarDoorCommand)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The door command state of a lift car.
    /// </summary>
    public static PropertyStates FromLiftCarDoorCommand(LiftCarDoorCommand value)
    {
        return new PropertyStates(Option.LiftCarDoorCommand, value);
    }

    /// <summary>
    /// The drive status of a lift car.
    /// </summary>
    public LiftCarDriveStatus LiftCarDriveStatus
    {
        get
        {
            if (Choice != Option.LiftCarDriveStatus)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftCarDriveStatus)}.");
            }
            return (LiftCarDriveStatus)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The drive status of a lift car.
    /// </summary>
    public static PropertyStates FromLiftCarDriveStatus(LiftCarDriveStatus value)
    {
        return new PropertyStates(Option.LiftCarDriveStatus, value);
    }

    /// <summary>
    /// The mode state of a lift car.
    /// </summary>
    public LiftCarMode LiftCarMode
    {
        get
        {
            if (Choice != Option.LiftCarMode)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftCarMode)}.");
            }
            return (LiftCarMode)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The mode state of a lift car.
    /// </summary>
    public static PropertyStates FromLiftCarMode(LiftCarMode value)
    {
        return new PropertyStates(Option.LiftCarMode, value);
    }

    /// <summary>
    /// The mode state of a lift group.
    /// </summary>
    public LiftGroupMode LiftGroupMode
    {
        get
        {
            if (Choice != Option.LiftGroupMode)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftGroupMode)}.");
            }
            return (LiftGroupMode)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The mode state of a lift group.
    /// </summary>
    public static PropertyStates FromLiftGroupMode(LiftGroupMode value)
    {
        return new PropertyStates(Option.LiftGroupMode, value);
    }

    /// <summary>
    /// The fault state of a lift.
    /// </summary>
    public LiftFault LiftFault
    {
        get
        {
            if (Choice != Option.LiftFault)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.LiftFault)}.");
            }
            return (LiftFault)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The fault state of a lift.
    /// </summary>
    public static PropertyStates FromLiftFault(LiftFault value)
    {
        return new PropertyStates(Option.LiftFault, value);
    }

    /// <summary>
    /// The protocol level state.
    /// </summary>
    public ProtocolLevel ProtocolLevel
    {
        get
        {
            if (Choice != Option.ProtocolLevel)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ProtocolLevel)}.");
            }
            return (ProtocolLevel)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The protocol level state.
    /// </summary>
    public static PropertyStates FromProtocolLevel(ProtocolLevel value)
    {
        return new PropertyStates(Option.ProtocolLevel, value);
    }

    /// <summary>
    /// The audit level state.
    /// </summary>
    public AuditLevel AuditLevel
    {
        get
        {
            if (Choice != Option.AuditLevel)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuditLevel)}.");
            }
            return (AuditLevel)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The audit level state.
    /// </summary>
    public static PropertyStates FromAuditLevel(AuditLevel value)
    {
        return new PropertyStates(Option.AuditLevel, value);
    }

    /// <summary>
    /// The audit operation state.
    /// </summary>
    public AuditOperation AuditOperation
    {
        get
        {
            if (Choice != Option.AuditOperation)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AuditOperation)}.");
            }
            return (AuditOperation)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The audit operation state.
    /// </summary>
    public static PropertyStates FromAuditOperation(AuditOperation value)
    {
        return new PropertyStates(Option.AuditOperation, value);
    }

    /// <summary>
    /// An extended unsigned integer value.
    /// </summary>
    public Unsigned32 ExtendedValue
    {
        get
        {
            if (Choice != Option.ExtendedValue)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ExtendedValue)}.");
            }
            return (Unsigned32)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An extended unsigned integer value.
    /// </summary>
    public static PropertyStates FromExtendedValue(Unsigned32 value)
    {
        return new PropertyStates(Option.ExtendedValue, value);
    }

    /// <summary>
    /// The state of a secure connection.
    /// </summary>
    public ScConnectionState ScConnectionState
    {
        get
        {
            if (Choice != Option.ScConnectionState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ScConnectionState)}.");
            }
            return (ScConnectionState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The state of a secure connection.
    /// </summary>
    public static PropertyStates FromScConnectionState(ScConnectionState value)
    {
        return new PropertyStates(Option.ScConnectionState, value);
    }

    /// <summary>
    /// The state of a secure hub connector.
    /// </summary>
    public ScHubConnectorState ScHubConnectorState
    {
        get
        {
            if (Choice != Option.ScHubConnectorState)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ScHubConnectorState)}.");
            }
            return (ScHubConnectorState)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The state of a secure hub connector.
    /// </summary>
    public static PropertyStates FromScHubConnectorState(ScHubConnectorState value)
    {
        return new PropertyStates(Option.ScHubConnectorState, value);
    }
}
