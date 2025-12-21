// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetPropertyIdentifier as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum PropertyIdentifier : uint
{
    /// <summary>BACnetEventTransitionBits indicating acknowledged transitions (0)</summary>
    AckedTransitions = 0,
    
    /// <summary>BACnetEventTransitionBits indicating which transitions require acknowledgement (1)</summary>
    AckRequired = 1,
    
    /// <summary>Action to be performed (2)</summary>
    Action = 2,
    
    /// <summary>Text description of action (3)</summary>
    ActionText = 3,
    
    /// <summary>Text displayed when binary value is active (4)</summary>
    ActiveText = 4,
    
    /// <summary>List of active virtual terminal sessions (5)</summary>
    ActiveVtSessions = 5,
    
    /// <summary>Alarm value for analog inputs (6)</summary>
    AlarmValue = 6,
    
    /// <summary>List of alarm values (7)</summary>
    AlarmValues = 7,
    
    /// <summary>Indicates all properties (8)</summary>
    All = 8,
    
    /// <summary>Indicates if all writes were successful (9)</summary>
    AllWritesSuccessful = 9,
    
    /// <summary>Timeout for APDU segment transmission (10)</summary>
    ApduSegmentTimeout = 10,
    
    /// <summary>Timeout for APDU response (11)</summary>
    ApduTimeout = 11,
    
    /// <summary>Version of application software (12)</summary>
    ApplicationSoftwareVersion = 12,
    
    /// <summary>Archive flag (13)</summary>
    Archive = 13,
    
    /// <summary>Bias value (14)</summary>
    Bias = 14,
    
    /// <summary>Number of change of state occurrences (15)</summary>
    ChangeOfStateCount = 15,
    
    /// <summary>Time of last change of state (16)</summary>
    ChangeOfStateTime = 16,
    
    /// <summary>Notification class for event reporting (17)</summary>
    NotificationClass = 17,
    
    /// <summary>Reference to controlled variable (19)</summary>
    ControlledVariableReference = 19,
    
    /// <summary>Engineering units of controlled variable (20)</summary>
    ControlledVariableUnits = 20,
    
    /// <summary>Current value of controlled variable (21)</summary>
    ControlledVariableValue = 21,
    
    /// <summary>Change of value increment (22)</summary>
    CovIncrement = 22,
    
    /// <summary>List of dates (23)</summary>
    DateList = 23,
    
    /// <summary>Indicates daylight savings time status (24)</summary>
    DaylightSavingsStatus = 24,
    
    /// <summary>Deadband value (25)</summary>
    Deadband = 25,
    
    /// <summary>Derivative constant for PID control (26)</summary>
    DerivativeConstant = 26,
    
    /// <summary>Engineering units for derivative constant (27)</summary>
    DerivativeConstantUnits = 27,
    
    /// <summary>Textual description (28)</summary>
    Description = 28,
    
    /// <summary>Description of halt condition (29)</summary>
    DescriptionOfHalt = 29,
    
    /// <summary>Device address binding table (30)</summary>
    DeviceAddressBinding = 30,
    
    /// <summary>Type of device (31)</summary>
    DeviceType = 31,
    
    /// <summary>Effective period for schedule (32)</summary>
    EffectivePeriod = 32,
    
    /// <summary>Accumulated active time (33)</summary>
    ElapsedActiveTime = 33,
    
    /// <summary>Error limit threshold (34)</summary>
    ErrorLimit = 34,
    
    /// <summary>Event notification enable flags (35)</summary>
    EventEnable = 35,
    
    /// <summary>Current event state (36)</summary>
    EventState = 36,
    
    /// <summary>Type of event (37)</summary>
    EventType = 37,
    
    /// <summary>Exception schedule entries (38)</summary>
    ExceptionSchedule = 38,
    
    /// <summary>Fault condition values (39)</summary>
    FaultValues = 39,
    
    /// <summary>Feedback value in control loop (40)</summary>
    FeedbackValue = 40,
    
    /// <summary>File access method (41)</summary>
    FileAccessMethod = 41,
    
    /// <summary>Size of file in octets (42)</summary>
    FileSize = 42,
    
    /// <summary>Type of file (43)</summary>
    FileType = 43,
    
    /// <summary>Firmware revision string (44)</summary>
    FirmwareRevision = 44,
    
    /// <summary>High limit for analog value (45)</summary>
    HighLimit = 45,
    
    /// <summary>Text displayed when binary value is inactive (46)</summary>
    InactiveText = 46,
    
    /// <summary>Indicates command in process (47)</summary>
    InProcess = 47,
    
    /// <summary>Object identifier of which this is an instance (48)</summary>
    InstanceOf = 48,
    
    /// <summary>Integral constant for PID control (49)</summary>
    IntegralConstant = 49,
    
    /// <summary>Engineering units for integral constant (50)</summary>
    IntegralConstantUnits = 50,
    
    /// <summary>Indicates if confirmed notifications are issued (51)</summary>
    IssueConfirmedNotifications = 51,
    
    /// <summary>Limit enable flags (52)</summary>
    LimitEnable = 52,
    
    /// <summary>List of group member references (53)</summary>
    ListOfGroupMembers = 53,
    
    /// <summary>List of object property references (54)</summary>
    ListOfObjectPropertyReferences = 54,
    
    /// <summary>Local date (56)</summary>
    LocalDate = 56,
    
    /// <summary>Local time (57)</summary>
    LocalTime = 57,
    
    /// <summary>Physical location description (58)</summary>
    Location = 58,
    
    /// <summary>Low limit for analog value (59)</summary>
    LowLimit = 59,
    
    /// <summary>Reference to manipulated variable (60)</summary>
    ManipulatedVariableReference = 60,
    
    /// <summary>Maximum output value (61)</summary>
    MaximumOutput = 61,
    
    /// <summary>Maximum APDU length accepted (62)</summary>
    MaxApduLengthAccepted = 62,
    
    /// <summary>Maximum information frames (63)</summary>
    MaxInfoFrames = 63,
    
    /// <summary>Maximum master address (64)</summary>
    MaxManager = 64,
    
    /// <summary>Maximum present value (65)</summary>
    MaxPresValue = 65,
    
    /// <summary>Minimum off time (66)</summary>
    MinimumOffTime = 66,
    
    /// <summary>Minimum on time (67)</summary>
    MinimumOnTime = 67,
    
    /// <summary>Minimum output value (68)</summary>
    MinimumOutput = 68,
    
    /// <summary>Minimum present value (69)</summary>
    MinPresValue = 69,
    
    /// <summary>Model name of device (70)</summary>
    ModelName = 70,
    
    /// <summary>Date of last modification (71)</summary>
    ModificationDate = 71,
    
    /// <summary>Type of notification (72)</summary>
    NotifyType = 72,
    
    /// <summary>Number of APDU retries (73)</summary>
    NumberOfApduRetries = 73,
    
    /// <summary>Number of states for multistate value (74)</summary>
    NumberOfStates = 74,
    
    /// <summary>Object identifier (75)</summary>
    ObjectIdentifier = 75,
    
    /// <summary>List of objects in device (76)</summary>
    ObjectList = 76,
    
    /// <summary>Name of object (77)</summary>
    ObjectName = 77,
    
    /// <summary>Object property reference (78)</summary>
    ObjectPropertyReference = 78,
    
    /// <summary>Type of object (79)</summary>
    ObjectType = 79,
    
    /// <summary>Optional property indicator (80)</summary>
    Optional = 80,
    
    /// <summary>Out of service indicator (81)</summary>
    OutOfService = 81,
    
    /// <summary>Output engineering units (82)</summary>
    OutputUnits = 82,
    
    /// <summary>Event algorithm parameters (83)</summary>
    EventParameters = 83,
    
    /// <summary>Polarity of binary input (84)</summary>
    Polarity = 84,
    
    /// <summary>Present value of object (85)</summary>
    PresentValue = 85,
    
    /// <summary>Priority level (86)</summary>
    Priority = 86,
    
    /// <summary>Array of priority values (87)</summary>
    PriorityArray = 87,
    
    /// <summary>Priority for writing (88)</summary>
    PriorityForWriting = 88,
    
    /// <summary>Process identifier (89)</summary>
    ProcessIdentifier = 89,
    
    /// <summary>Program change indicator (90)</summary>
    ProgramChange = 90,
    
    /// <summary>Location of program (91)</summary>
    ProgramLocation = 91,
    
    /// <summary>State of program execution (92)</summary>
    ProgramState = 92,
    
    /// <summary>Proportional constant for PID control (93)</summary>
    ProportionalConstant = 93,
    
    /// <summary>Engineering units for proportional constant (94)</summary>
    ProportionalConstantUnits = 94,
    
    /// <summary>Protocol object types supported (96)</summary>
    ProtocolObjectTypesSupported = 96,
    
    /// <summary>Protocol services supported (97)</summary>
    ProtocolServicesSupported = 97,
    
    /// <summary>Protocol version number (98)</summary>
    ProtocolVersion = 98,
    
    /// <summary>Read-only indicator (99)</summary>
    ReadOnly = 99,
    
    /// <summary>Reason for program halt (100)</summary>
    ReasonForHalt = 100,
    
    /// <summary>List of event notification recipients (102)</summary>
    RecipientList = 102,
    
    /// <summary>Reliability indicator (103)</summary>
    Reliability = 103,
    
    /// <summary>Default value when all priorities relinquished (104)</summary>
    RelinquishDefault = 104,
    
    /// <summary>Required property indicator (105)</summary>
    Required = 105,
    
    /// <summary>Resolution of value (106)</summary>
    Resolution = 106,
    
    /// <summary>Segmentation support level (107)</summary>
    SegmentationSupported = 107,
    
    /// <summary>Setpoint value (108)</summary>
    Setpoint = 108,
    
    /// <summary>Reference to setpoint (109)</summary>
    SetpointReference = 109,
    
    /// <summary>Text array for multistate values (110)</summary>
    StateText = 110,
    
    /// <summary>Status flags (111)</summary>
    StatusFlags = 111,
    
    /// <summary>System status (112)</summary>
    SystemStatus = 112,
    
    /// <summary>Time delay for event detection (113)</summary>
    TimeDelay = 113,
    
    /// <summary>Time of active time reset (114)</summary>
    TimeOfActiveTimeReset = 114,
    
    /// <summary>Time of state count reset (115)</summary>
    TimeOfStateCountReset = 115,
    
    /// <summary>List of time synchronization recipients (116)</summary>
    TimeSynchronizationRecipients = 116,
    
    /// <summary>Engineering units (117)</summary>
    Units = 117,
    
    /// <summary>Update interval (118)</summary>
    UpdateInterval = 118,
    
    /// <summary>UTC offset in minutes (119)</summary>
    UtcOffset = 119,
    
    /// <summary>Vendor identifier (120)</summary>
    VendorIdentifier = 120,
    
    /// <summary>Vendor name (121)</summary>
    VendorName = 121,
    
    /// <summary>Virtual terminal classes supported (122)</summary>
    VtClassesSupported = 122,
    
    /// <summary>Weekly schedule (123)</summary>
    WeeklySchedule = 123,
    
    /// <summary>Number of attempted samples (124)</summary>
    AttemptedSamples = 124,
    
    /// <summary>Average value (125)</summary>
    AverageValue = 125,
    
    /// <summary>Buffer size (126)</summary>
    BufferSize = 126,
    
    /// <summary>Client COV increment (127)</summary>
    ClientCovIncrement = 127,
    
    /// <summary>COV resubscription interval (128)</summary>
    CovResubscriptionInterval = 128,
    
    /// <summary>Event timestamps (130)</summary>
    EventTimeStamps = 130,
    
    /// <summary>Log buffer (131)</summary>
    LogBuffer = 131,
    
    /// <summary>Log device object property reference (132)</summary>
    LogDeviceObjectProperty = 132,
    
    /// <summary>Enable flag (133)</summary>
    Enable = 133,
    
    /// <summary>Log interval (134)</summary>
    LogInterval = 134,
    
    /// <summary>Maximum value (135)</summary>
    MaximumValue = 135,
    
    /// <summary>Minimum value (136)</summary>
    MinimumValue = 136,
    
    /// <summary>Notification threshold (137)</summary>
    NotificationThreshold = 137,
    
    /// <summary>Protocol revision number (139)</summary>
    ProtocolRevision = 139,
    
    /// <summary>Records since notification (140)</summary>
    RecordsSinceNotification = 140,
    
    /// <summary>Record count (141)</summary>
    RecordCount = 141,
    
    /// <summary>Start time (142)</summary>
    StartTime = 142,
    
    /// <summary>Stop time (143)</summary>
    StopTime = 143,
    
    /// <summary>Stop when full flag (144)</summary>
    StopWhenFull = 144,
    
    /// <summary>Total record count (145)</summary>
    TotalRecordCount = 145,
    
    /// <summary>Number of valid samples (146)</summary>
    ValidSamples = 146,
    
    /// <summary>Window interval (147)</summary>
    WindowInterval = 147,
    
    /// <summary>Window samples (148)</summary>
    WindowSamples = 148,
    
    /// <summary>Maximum value timestamp (149)</summary>
    MaximumValueTimestamp = 149,
    
    /// <summary>Minimum value timestamp (150)</summary>
    MinimumValueTimestamp = 150,
    
    /// <summary>Variance value (151)</summary>
    VarianceValue = 151,
    
    /// <summary>Active COV subscriptions (152)</summary>
    ActiveCovSubscriptions = 152,
    
    /// <summary>Backup failure timeout (153)</summary>
    BackupFailureTimeout = 153,
    
    /// <summary>Configuration files (154)</summary>
    ConfigurationFiles = 154,
    
    /// <summary>Database revision (155)</summary>
    DatabaseRevision = 155,
    
    /// <summary>Direct reading (156)</summary>
    DirectReading = 156,
    
    /// <summary>Last restore time (157)</summary>
    LastRestoreTime = 157,
    
    /// <summary>Maintenance required flag (158)</summary>
    MaintenanceRequired = 158,
    
    /// <summary>Member of list (159)</summary>
    MemberOf = 159,
    
    /// <summary>Mode (160)</summary>
    Mode = 160,
    
    /// <summary>Operation expected (161)</summary>
    OperationExpected = 161,
    
    /// <summary>Setting value (162)</summary>
    Setting = 162,
    
    /// <summary>Silenced flag (163)</summary>
    Silenced = 163,
    
    /// <summary>Tracking value (164)</summary>
    TrackingValue = 164,
    
    /// <summary>Zone members (165)</summary>
    ZoneMembers = 165,
    
    /// <summary>Life safety alarm values (166)</summary>
    LifeSafetyAlarmValues = 166,
    
    /// <summary>Maximum segments accepted (167)</summary>
    MaxSegmentsAccepted = 167,
    
    /// <summary>Profile name (168)</summary>
    ProfileName = 168,
    
    /// <summary>Auto subordinate discovery flag (169)</summary>
    AutoSubordinateDiscovery = 169,
    
    /// <summary>Manual subordinate address binding (170)</summary>
    ManualSubordinateAddressBinding = 170,
    
    /// <summary>Subordinate address binding (171)</summary>
    SubordinateAddressBinding = 171,
    
    /// <summary>Subordinate proxy enable flag (172)</summary>
    SubordinateProxyEnable = 172,
    
    /// <summary>Last notify record (173)</summary>
    LastNotifyRecord = 173,
    
    /// <summary>Schedule default value (174)</summary>
    ScheduleDefault = 174,
    
    /// <summary>Accepted modes (175)</summary>
    AcceptedModes = 175,
    
    /// <summary>Adjust value (176)</summary>
    AdjustValue = 176,
    
    /// <summary>Count value (177)</summary>
    Count = 177,
    
    /// <summary>Count before change (178)</summary>
    CountBeforeChange = 178,
    
    /// <summary>Count change time (179)</summary>
    CountChangeTime = 179,
    
    /// <summary>COV period (180)</summary>
    CovPeriod = 180,
    
    /// <summary>Input reference (181)</summary>
    InputReference = 181,
    
    /// <summary>Limit monitoring interval (182)</summary>
    LimitMonitoringInterval = 182,
    
    /// <summary>Logging object (183)</summary>
    LoggingObject = 183,
    
    /// <summary>Logging record (184)</summary>
    LoggingRecord = 184,
    
    /// <summary>Prescale value (185)</summary>
    Prescale = 185,
    
    /// <summary>Pulse rate (186)</summary>
    PulseRate = 186,
    
    /// <summary>Scale value (187)</summary>
    Scale = 187,
    
    /// <summary>Scale factor (188)</summary>
    ScaleFactor = 188,
    
    /// <summary>Update time (189)</summary>
    UpdateTime = 189,
    
    /// <summary>Value before change (190)</summary>
    ValueBeforeChange = 190,
    
    /// <summary>Value set (191)</summary>
    ValueSet = 191,
    
    /// <summary>Value change time (192)</summary>
    ValueChangeTime = 192,
    
    /// <summary>Align intervals flag (193)</summary>
    AlignIntervals = 193,
    
    /// <summary>Interval offset (195)</summary>
    IntervalOffset = 195,
    
    /// <summary>Last restart reason (196)</summary>
    LastRestartReason = 196,
    
    /// <summary>Logging type (197)</summary>
    LoggingType = 197,
    
    /// <summary>Restart notification recipients (202)</summary>
    RestartNotificationRecipients = 202,
    
    /// <summary>Time of device restart (203)</summary>
    TimeOfDeviceRestart = 203,
    
    /// <summary>Time synchronization interval (204)</summary>
    TimeSynchronizationInterval = 204,
    
    /// <summary>Trigger (205)</summary>
    Trigger = 205,
    
    /// <summary>UTC time synchronization recipients (206)</summary>
    UtcTimeSynchronizationRecipients = 206,
    
    /// <summary>Node subtype (207)</summary>
    NodeSubtype = 207,
    
    /// <summary>Node type (208)</summary>
    NodeType = 208,
    
    /// <summary>Structured object list (209)</summary>
    StructuredObjectList = 209,
    
    /// <summary>Subordinate annotations (210)</summary>
    SubordinateAnnotations = 210,
    
    /// <summary>Subordinate list (211)</summary>
    SubordinateList = 211,
    
    /// <summary>Actual shed level (212)</summary>
    ActualShedLevel = 212,
    
    /// <summary>Duty window (213)</summary>
    DutyWindow = 213,
    
    /// <summary>Expected shed level (214)</summary>
    ExpectedShedLevel = 214,
    
    /// <summary>Full duty baseline (215)</summary>
    FullDutyBaseline = 215,
    
    /// <summary>Requested shed level (218)</summary>
    RequestedShedLevel = 218,
    
    /// <summary>Shed duration (219)</summary>
    ShedDuration = 219,
    
    /// <summary>Shed level descriptions (220)</summary>
    ShedLevelDescriptions = 220,
    
    /// <summary>Shed levels (221)</summary>
    ShedLevels = 221,
    
    /// <summary>State description (222)</summary>
    StateDescription = 222,
    
    /// <summary>Door alarm state (226)</summary>
    DoorAlarmState = 226,
    
    /// <summary>Door extended pulse time (227)</summary>
    DoorExtendedPulseTime = 227,
    
    /// <summary>Door members (228)</summary>
    DoorMembers = 228,
    
    /// <summary>Door open too long time (229)</summary>
    DoorOpenTooLongTime = 229,
    
    /// <summary>Door pulse time (230)</summary>
    DoorPulseTime = 230,
    
    /// <summary>Door status (231)</summary>
    DoorStatus = 231,
    
    /// <summary>Door unlock delay time (232)</summary>
    DoorUnlockDelayTime = 232,
    
    /// <summary>Lock status (233)</summary>
    LockStatus = 233,
    
    /// <summary>Masked alarm values (234)</summary>
    MaskedAlarmValues = 234,
    
    /// <summary>Secured status (235)</summary>
    SecuredStatus = 235,
    
    /// <summary>Absentee limit (244)</summary>
    AbsenteeLimit = 244,
    
    /// <summary>Access alarm events (245)</summary>
    AccessAlarmEvents = 245,
    
    /// <summary>Access doors (246)</summary>
    AccessDoors = 246,
    
    /// <summary>Access event (247)</summary>
    AccessEvent = 247,
    
    /// <summary>Access event authentication factor (248)</summary>
    AccessEventAuthenticationFactor = 248,
    
    /// <summary>Access event credential (249)</summary>
    AccessEventCredential = 249,
    
    /// <summary>Access event time (250)</summary>
    AccessEventTime = 250,
    
    /// <summary>Access transaction events (251)</summary>
    AccessTransactionEvents = 251,
    
    /// <summary>Accompaniment (252)</summary>
    Accompaniment = 252,
    
    /// <summary>Accompaniment time (253)</summary>
    AccompanimentTime = 253,
    
    /// <summary>Activation time (254)</summary>
    ActivationTime = 254,
    
    /// <summary>Active authentication policy (255)</summary>
    ActiveAuthenticationPolicy = 255,
    
    /// <summary>Assigned access rights (256)</summary>
    AssignedAccessRights = 256,
    
    /// <summary>Authentication factors (257)</summary>
    AuthenticationFactors = 257,
    
    /// <summary>Authentication policy list (258)</summary>
    AuthenticationPolicyList = 258,
    
    /// <summary>Authentication policy names (259)</summary>
    AuthenticationPolicyNames = 259,
    
    /// <summary>Authentication status (260)</summary>
    AuthenticationStatus = 260,
    
    /// <summary>Authorization mode (261)</summary>
    AuthorizationMode = 261,
    
    /// <summary>Belongs to (262)</summary>
    BelongsTo = 262,
    
    /// <summary>Credential disable (263)</summary>
    CredentialDisable = 263,
    
    /// <summary>Credential status (264)</summary>
    CredentialStatus = 264,
    
    /// <summary>Credentials (265)</summary>
    Credentials = 265,
    
    /// <summary>Credentials in zone (266)</summary>
    CredentialsInZone = 266,
    
    /// <summary>Days remaining (267)</summary>
    DaysRemaining = 267,
    
    /// <summary>Entry points (268)</summary>
    EntryPoints = 268,
    
    /// <summary>Exit points (269)</summary>
    ExitPoints = 269,
    
    /// <summary>Expiration time (270)</summary>
    ExpirationTime = 270,
    
    /// <summary>Extended time enable (271)</summary>
    ExtendedTimeEnable = 271,
    
    /// <summary>Failed attempt events (272)</summary>
    FailedAttemptEvents = 272,
    
    /// <summary>Failed attempts (273)</summary>
    FailedAttempts = 273,
    
    /// <summary>Failed attempts time (274)</summary>
    FailedAttemptsTime = 274,
    
    /// <summary>Last access event (275)</summary>
    LastAccessEvent = 275,
    
    /// <summary>Last access point (276)</summary>
    LastAccessPoint = 276,
    
    /// <summary>Last credential added (277)</summary>
    LastCredentialAdded = 277,
    
    /// <summary>Last credential added time (278)</summary>
    LastCredentialAddedTime = 278,
    
    /// <summary>Last credential removed (279)</summary>
    LastCredentialRemoved = 279,
    
    /// <summary>Last credential removed time (280)</summary>
    LastCredentialRemovedTime = 280,
    
    /// <summary>Last use time (281)</summary>
    LastUseTime = 281,
    
    /// <summary>Lockout (282)</summary>
    Lockout = 282,
    
    /// <summary>Lockout relinquish time (283)</summary>
    LockoutRelinquishTime = 283,
    
    /// <summary>Maximum failed attempts (285)</summary>
    MaxFailedAttempts = 285,
    
    /// <summary>Members (286)</summary>
    Members = 286,
    
    /// <summary>Muster point (287)</summary>
    MusterPoint = 287,
    
    /// <summary>Negative access rules (288)</summary>
    NegativeAccessRules = 288,
    
    /// <summary>Number of authentication policies (289)</summary>
    NumberOfAuthenticationPolicies = 289,
    
    /// <summary>Occupancy count (290)</summary>
    OccupancyCount = 290,
    
    /// <summary>Occupancy count adjust (291)</summary>
    OccupancyCountAdjust = 291,
    
    /// <summary>Occupancy count enable (292)</summary>
    OccupancyCountEnable = 292,
    
    /// <summary>Occupancy lower limit (294)</summary>
    OccupancyLowerLimit = 294,
    
    /// <summary>Occupancy lower limit enforced (295)</summary>
    OccupancyLowerLimitEnforced = 295,
    
    /// <summary>Occupancy state (296)</summary>
    OccupancyState = 296,
    
    /// <summary>Occupancy upper limit (297)</summary>
    OccupancyUpperLimit = 297,
    
    /// <summary>Occupancy upper limit enforced (298)</summary>
    OccupancyUpperLimitEnforced = 298,
    
    /// <summary>Passback mode (300)</summary>
    PassbackMode = 300,
    
    /// <summary>Passback timeout (301)</summary>
    PassbackTimeout = 301,
    
    /// <summary>Positive access rules (302)</summary>
    PositiveAccessRules = 302,
    
    /// <summary>Reason for disable (303)</summary>
    ReasonForDisable = 303,
    
    /// <summary>Supported formats (304)</summary>
    SupportedFormats = 304,
    
    /// <summary>Supported format classes (305)</summary>
    SupportedFormatClasses = 305,
    
    /// <summary>Threat authority (306)</summary>
    ThreatAuthority = 306,
    
    /// <summary>Threat level (307)</summary>
    ThreatLevel = 307,
    
    /// <summary>Trace flag (308)</summary>
    TraceFlag = 308,
    
    /// <summary>Transaction notification class (309)</summary>
    TransactionNotificationClass = 309,
    
    /// <summary>User external identifier (310)</summary>
    UserExternalIdentifier = 310,
    
    /// <summary>User information reference (311)</summary>
    UserInformationReference = 311,
    
    /// <summary>User name (317)</summary>
    UserName = 317,
    
    /// <summary>User type (318)</summary>
    UserType = 318,
    
    /// <summary>Uses remaining (319)</summary>
    UsesRemaining = 319,
    
    /// <summary>Zone from (320)</summary>
    ZoneFrom = 320,
    
    /// <summary>Zone to (321)</summary>
    ZoneTo = 321,
    
    /// <summary>Access event tag (322)</summary>
    AccessEventTag = 322,
    
    /// <summary>Global identifier (323)</summary>
    GlobalIdentifier = 323,
    
    /// <summary>Verification time (326)</summary>
    VerificationTime = 326,
    
    /// <summary>Backup and restore state (338)</summary>
    BackupAndRestoreState = 338,
    
    /// <summary>Backup preparation time (339)</summary>
    BackupPreparationTime = 339,
    
    /// <summary>Restore completion time (340)</summary>
    RestoreCompletionTime = 340,
    
    /// <summary>Restore preparation time (341)</summary>
    RestorePreparationTime = 341,
    
    /// <summary>Bit mask (342)</summary>
    BitMask = 342,
    
    /// <summary>Bit text (343)</summary>
    BitText = 343,
    
    /// <summary>Is UTC (344)</summary>
    IsUtc = 344,
    
    /// <summary>Group members (345)</summary>
    GroupMembers = 345,
    
    /// <summary>Group member names (346)</summary>
    GroupMemberNames = 346,
    
    /// <summary>Member status flags (347)</summary>
    MemberStatusFlags = 347,
    
    /// <summary>Requested update interval (348)</summary>
    RequestedUpdateInterval = 348,
    
    /// <summary>COVU period (349)</summary>
    CovuPeriod = 349,
    
    /// <summary>COVU recipients (350)</summary>
    CovuRecipients = 350,
    
    /// <summary>Event message texts (351)</summary>
    EventMessageTexts = 351,
    
    /// <summary>Event message texts config (352)</summary>
    EventMessageTextsConfig = 352,
    
    /// <summary>Event detection enable (353)</summary>
    EventDetectionEnable = 353,
    
    /// <summary>Event algorithm inhibit (354)</summary>
    EventAlgorithmInhibit = 354,
    
    /// <summary>Event algorithm inhibit reference (355)</summary>
    EventAlgorithmInhibitRef = 355,
    
    /// <summary>Time delay normal (356)</summary>
    TimeDelayNormal = 356,
    
    /// <summary>Reliability evaluation inhibit (357)</summary>
    ReliabilityEvaluationInhibit = 357,
    
    /// <summary>Fault parameters (358)</summary>
    FaultParameters = 358,
    
    /// <summary>Fault type (359)</summary>
    FaultType = 359,
    
    /// <summary>Local forwarding only (360)</summary>
    LocalForwardingOnly = 360,
    
    /// <summary>Process identifier filter (361)</summary>
    ProcessIdentifierFilter = 361,
    
    /// <summary>Subscribed recipients (362)</summary>
    SubscribedRecipients = 362,
    
    /// <summary>Port filter (363)</summary>
    PortFilter = 363,
    
    /// <summary>Authorization exemptions (364)</summary>
    AuthorizationExemptions = 364,
    
    /// <summary>Allow group delay inhibit (365)</summary>
    AllowGroupDelayInhibit = 365,
    
    /// <summary>Channel number (366)</summary>
    ChannelNumber = 366,
    
    /// <summary>Control groups (367)</summary>
    ControlGroups = 367,
    
    /// <summary>Execution delay (368)</summary>
    ExecutionDelay = 368,
    
    /// <summary>Last priority (369)</summary>
    LastPriority = 369,
    
    /// <summary>Write status (370)</summary>
    WriteStatus = 370,
    
    /// <summary>Property list (371)</summary>
    PropertyList = 371,
    
    /// <summary>Serial number (372)</summary>
    SerialNumber = 372,
    
    /// <summary>Blink warn enable (373)</summary>
    BlinkWarnEnable = 373,
    
    /// <summary>Default fade time (374)</summary>
    DefaultFadeTime = 374,
    
    /// <summary>Default ramp rate (375)</summary>
    DefaultRampRate = 375,
    
    /// <summary>Default step increment (376)</summary>
    DefaultStepIncrement = 376,
    
    /// <summary>Egress time (377)</summary>
    EgressTime = 377,
    
    /// <summary>In progress (378)</summary>
    InProgress = 378,
    
    /// <summary>Instantaneous power (379)</summary>
    InstantaneousPower = 379,
    
    /// <summary>Lighting command (380)</summary>
    LightingCommand = 380,
    
    /// <summary>Lighting command default priority (381)</summary>
    LightingCommandDefaultPriority = 381,
    
    /// <summary>Maximum actual value (382)</summary>
    MaxActualValue = 382,
    
    /// <summary>Minimum actual value (383)</summary>
    MinActualValue = 383,
    
    /// <summary>Power (384)</summary>
    Power = 384,
    
    /// <summary>Transition (385)</summary>
    Transition = 385,
    
    /// <summary>Egress active (386)</summary>
    EgressActive = 386,
    
    /// <summary>Interface value (387)</summary>
    InterfaceValue = 387,
    
    /// <summary>Fault high limit (388)</summary>
    FaultHighLimit = 388,
    
    /// <summary>Fault low limit (389)</summary>
    FaultLowLimit = 389,
    
    /// <summary>Low diff limit (390)</summary>
    LowDiffLimit = 390,
    
    /// <summary>Strike count (391)</summary>
    StrikeCount = 391,
    
    /// <summary>Time of strike count reset (392)</summary>
    TimeOfStrikeCountReset = 392,
    
    /// <summary>Default timeout (393)</summary>
    DefaultTimeout = 393,
    
    /// <summary>Initial timeout (394)</summary>
    InitialTimeout = 394,
    
    /// <summary>Last state change (395)</summary>
    LastStateChange = 395,
    
    /// <summary>State change values (396)</summary>
    StateChangeValues = 396,
    
    /// <summary>Timer running (397)</summary>
    TimerRunning = 397,
    
    /// <summary>Timer state (398)</summary>
    TimerState = 398,
    
    /// <summary>APDU length (399)</summary>
    ApduLength = 399,
    
    /// <summary>IP address (400)</summary>
    IpAddress = 400,
    
    /// <summary>IP default gateway (401)</summary>
    IpDefaultGateway = 401,
    
    /// <summary>IP DHCP enable (402)</summary>
    IpDhcpEnable = 402,
    
    /// <summary>IP DHCP lease time (403)</summary>
    IpDhcpLeaseTime = 403,
    
    /// <summary>IP DHCP lease time remaining (404)</summary>
    IpDhcpLeaseTimeRemaining = 404,
    
    /// <summary>IP DHCP server (405)</summary>
    IpDhcpServer = 405,
    
    /// <summary>IP DNS server (406)</summary>
    IpDnsServer = 406,
    
    /// <summary>BACnet IP global address (407)</summary>
    BacnetIpGlobalAddress = 407,
    
    /// <summary>BACnet IP mode (408)</summary>
    BacnetIpMode = 408,
    
    /// <summary>BACnet IP multicast address (409)</summary>
    BacnetIpMulticastAddress = 409,
    
    /// <summary>BACnet IP NAT traversal (410)</summary>
    BacnetIpNatTraversal = 410,
    
    /// <summary>IP subnet mask (411)</summary>
    IpSubnetMask = 411,
    
    /// <summary>BACnet IP UDP port (412)</summary>
    BacnetIpUdpPort = 412,
    
    /// <summary>BBMD accept FD registrations (413)</summary>
    BbmdAcceptFdRegistrations = 413,
    
    /// <summary>BBMD broadcast distribution table (414)</summary>
    BbmdBroadcastDistributionTable = 414,
    
    /// <summary>BBMD foreign device table (415)</summary>
    BbmdForeignDeviceTable = 415,
    
    /// <summary>Changes pending (416)</summary>
    ChangesPending = 416,
    
    /// <summary>Command (417)</summary>
    Command = 417,
    
    /// <summary>FD BBMD address (418)</summary>
    FdBbmdAddress = 418,
    
    /// <summary>FD subscription lifetime (419)</summary>
    FdSubscriptionLifetime = 419,
    
    /// <summary>Link speed (420)</summary>
    LinkSpeed = 420,
    
    /// <summary>Link speeds (421)</summary>
    LinkSpeeds = 421,
    
    /// <summary>Link speed autonegotiate (422)</summary>
    LinkSpeedAutonegotiate = 422,
    
    /// <summary>MAC address (423)</summary>
    MacAddress = 423,
    
    /// <summary>Network interface name (424)</summary>
    NetworkInterfaceName = 424,
    
    /// <summary>Network number (425)</summary>
    NetworkNumber = 425,
    
    /// <summary>Network number quality (426)</summary>
    NetworkNumberQuality = 426,
    
    /// <summary>Network type (427)</summary>
    NetworkType = 427,
    
    /// <summary>Routing table (428)</summary>
    RoutingTable = 428,
    
    /// <summary>Virtual MAC address table (429)</summary>
    VirtualMacAddressTable = 429,
    
    /// <summary>Command time array (430)</summary>
    CommandTimeArray = 430,
    
    /// <summary>Current command priority (431)</summary>
    CurrentCommandPriority = 431,
    
    /// <summary>Last command time (432)</summary>
    LastCommandTime = 432,
    
    /// <summary>Value source (433)</summary>
    ValueSource = 433,
    
    /// <summary>Value source array (434)</summary>
    ValueSourceArray = 434,
    
    /// <summary>BACnet IPv6 mode (435)</summary>
    BacnetIpv6Mode = 435,
    
    /// <summary>IPv6 address (436)</summary>
    Ipv6Address = 436,
    
    /// <summary>IPv6 prefix length (437)</summary>
    Ipv6PrefixLength = 437,
    
    /// <summary>BACnet IPv6 UDP port (438)</summary>
    BacnetIpv6UdpPort = 438,
    
    /// <summary>IPv6 default gateway (439)</summary>
    Ipv6DefaultGateway = 439,
    
    /// <summary>BACnet IPv6 multicast address (440)</summary>
    BacnetIpv6MulticastAddress = 440,
    
    /// <summary>IPv6 DNS server (441)</summary>
    Ipv6DnsServer = 441,
    
    /// <summary>IPv6 auto addressing enable (442)</summary>
    Ipv6AutoAddressingEnable = 442,
    
    /// <summary>IPv6 DHCP lease time (443)</summary>
    Ipv6DhcpLeaseTime = 443,
    
    /// <summary>IPv6 DHCP lease time remaining (444)</summary>
    Ipv6DhcpLeaseTimeRemaining = 444,
    
    /// <summary>IPv6 DHCP server (445)</summary>
    Ipv6DhcpServer = 445,
    
    /// <summary>IPv6 zone index (446)</summary>
    Ipv6ZoneIndex = 446,
    
    /// <summary>Assigned landing calls (447)</summary>
    AssignedLandingCalls = 447,
    
    /// <summary>Car assigned direction (448)</summary>
    CarAssignedDirection = 448,
    
    /// <summary>Car door command (449)</summary>
    CarDoorCommand = 449,
    
    /// <summary>Car door status (450)</summary>
    CarDoorStatus = 450,
    
    /// <summary>Car door text (451)</summary>
    CarDoorText = 451,
    
    /// <summary>Car door zone (452)</summary>
    CarDoorZone = 452,
    
    /// <summary>Car drive status (453)</summary>
    CarDriveStatus = 453,
    
    /// <summary>Car load (454)</summary>
    CarLoad = 454,
    
    /// <summary>Car load units (455)</summary>
    CarLoadUnits = 455,
    
    /// <summary>Car mode (456)</summary>
    CarMode = 456,
    
    /// <summary>Car moving direction (457)</summary>
    CarMovingDirection = 457,
    
    /// <summary>Car position (458)</summary>
    CarPosition = 458,
    
    /// <summary>Elevator group (459)</summary>
    ElevatorGroup = 459,
    
    /// <summary>Energy meter (460)</summary>
    EnergyMeter = 460,
    
    /// <summary>Energy meter reference (461)</summary>
    EnergyMeterRef = 461,
    
    /// <summary>Escalator mode (462)</summary>
    EscalatorMode = 462,
    
    /// <summary>Fault signals (463)</summary>
    FaultSignals = 463,
    
    /// <summary>Floor text (464)</summary>
    FloorText = 464,
    
    /// <summary>Group ID (465)</summary>
    GroupId = 465,
    
    /// <summary>Group mode (467)</summary>
    GroupMode = 467,
    
    /// <summary>Higher deck (468)</summary>
    HigherDeck = 468,
    
    /// <summary>Installation ID (469)</summary>
    InstallationId = 469,
    
    /// <summary>Landing calls (470)</summary>
    LandingCalls = 470,
    
    /// <summary>Landing call control (471)</summary>
    LandingCallControl = 471,
    
    /// <summary>Landing door status (472)</summary>
    LandingDoorStatus = 472,
    
    /// <summary>Lower deck (473)</summary>
    LowerDeck = 473,
    
    /// <summary>Machine room ID (474)</summary>
    MachineRoomId = 474,
    
    /// <summary>Making car call (475)</summary>
    MakingCarCall = 475,
    
    /// <summary>Next stopping floor (476)</summary>
    NextStoppingFloor = 476,
    
    /// <summary>Operation direction (477)</summary>
    OperationDirection = 477,
    
    /// <summary>Passenger alarm (478)</summary>
    PassengerAlarm = 478,
    
    /// <summary>Power mode (479)</summary>
    PowerMode = 479,
    
    /// <summary>Registered car call (480)</summary>
    RegisteredCarCall = 480,
    
    /// <summary>Active COV multiple subscriptions (481)</summary>
    ActiveCovMultipleSubscriptions = 481,
    
    /// <summary>Protocol level (482)</summary>
    ProtocolLevel = 482,
    
    /// <summary>Reference port (483)</summary>
    ReferencePort = 483,
    
    /// <summary>Deployed profile location (484)</summary>
    DeployedProfileLocation = 484,
    
    /// <summary>Profile location (485)</summary>
    ProfileLocation = 485,
    
    /// <summary>Tags (486)</summary>
    Tags = 486,
    
    /// <summary>Subordinate node types (487)</summary>
    SubordinateNodeTypes = 487,
    
    /// <summary>Subordinate tags (488)</summary>
    SubordinateTags = 488,
    
    /// <summary>Subordinate relationships (489)</summary>
    SubordinateRelationships = 489,
    
    /// <summary>Default subordinate relationship (490)</summary>
    DefaultSubordinateRelationship = 490,
    
    /// <summary>Represents (491)</summary>
    Represents = 491,
    
    /// <summary>Default present value (492)</summary>
    DefaultPresentValue = 492,
    
    /// <summary>Present stage (493)</summary>
    PresentStage = 493,
    
    /// <summary>Stages (494)</summary>
    Stages = 494,
    
    /// <summary>Stage names (495)</summary>
    StageNames = 495,
    
    /// <summary>Target references (496)</summary>
    TargetReferences = 496,
    
    /// <summary>Audit source reporter (497)</summary>
    AuditSourceReporter = 497,
    
    /// <summary>Audit level (498)</summary>
    AuditLevel = 498,
    
    /// <summary>Audit notification recipient (499)</summary>
    AuditNotificationRecipient = 499,
    
    /// <summary>Audit priority filter (500)</summary>
    AuditPriorityFilter = 500,
    
    /// <summary>Auditable operations (501)</summary>
    AuditableOperations = 501,
    
    /// <summary>Delete on forward (502)</summary>
    DeleteOnForward = 502,
    
    /// <summary>Maximum send delay (503)</summary>
    MaximumSendDelay = 503,
    
    /// <summary>Monitored objects (504)</summary>
    MonitoredObjects = 504,
    
    /// <summary>Send now (505)</summary>
    SendNow = 505,
    
    /// <summary>Floor number (506)</summary>
    FloorNumber = 506,
    
    /// <summary>Device UUID (507)</summary>
    DeviceUuid = 507,
    
    /// <summary>Additional reference ports (508)</summary>
    AdditionalReferencePorts = 508,
    
    /// <summary>Certificate signing request file (509)</summary>
    CertificateSigningRequestFile = 509,
    
    /// <summary>Command validation result (510)</summary>
    CommandValidationResult = 510,
    
    /// <summary>Issuer certificate files (511)</summary>
    IssuerCertificateFiles = 511,
    
    /// <summary>Maximum BVLC length accepted (4194304)</summary>
    MaxBvlcLengthAccepted = 4194304,
    
    /// <summary>Maximum NPDU length accepted (4194305)</summary>
    MaxNpduLengthAccepted = 4194305,
    
    /// <summary>Operational certificate file (4194306)</summary>
    OperationalCertificateFile = 4194306,
    
    /// <summary>Current health (4194307)</summary>
    CurrentHealth = 4194307,
    
    /// <summary>SC connect wait timeout (4194308)</summary>
    ScConnectWaitTimeout = 4194308,
    
    /// <summary>SC direct connect accept enable (4194309)</summary>
    ScDirectConnectAcceptEnable = 4194309,
    
    /// <summary>SC direct connect accept URIs (4194310)</summary>
    ScDirectConnectAcceptUris = 4194310,
    
    /// <summary>SC direct connect binding (4194311)</summary>
    ScDirectConnectBinding = 4194311,
    
    /// <summary>SC direct connect connection status (4194312)</summary>
    ScDirectConnectConnectionStatus = 4194312,
    
    /// <summary>SC direct connect initiate enable (4194313)</summary>
    ScDirectConnectInitiateEnable = 4194313,
    
    /// <summary>SC disconnect wait timeout (4194314)</summary>
    ScDisconnectWaitTimeout = 4194314,
    
    /// <summary>SC failed connection requests (4194315)</summary>
    ScFailedConnectionRequests = 4194315,
    
    /// <summary>SC failover hub connection status (4194316)</summary>
    ScFailoverHubConnectionStatus = 4194316,
    
    /// <summary>SC failover hub URI (4194317)</summary>
    ScFailoverHubUri = 4194317,
    
    /// <summary>SC hub connector state (4194318)</summary>
    ScHubConnectorState = 4194318,
    
    /// <summary>SC hub function accept URIs (4194319)</summary>
    ScHubFunctionAcceptUris = 4194319,
    
    /// <summary>SC hub function binding (4194320)</summary>
    ScHubFunctionBinding = 4194320,
    
    /// <summary>SC hub function connection status (4194321)</summary>
    ScHubFunctionConnectionStatus = 4194321,
    
    /// <summary>SC hub function enable (4194322)</summary>
    ScHubFunctionEnable = 4194322,
    
    /// <summary>SC heartbeat timeout (4194323)</summary>
    ScHeartbeatTimeout = 4194323,
    
    /// <summary>SC primary hub connection status (4194324)</summary>
    ScPrimaryHubConnectionStatus = 4194324,
    
    /// <summary>SC primary hub URI (4194325)</summary>
    ScPrimaryHubUri = 4194325,
    
    /// <summary>SC maximum reconnect time (4194326)</summary>
    ScMaximumReconnectTime = 4194326,
    
    /// <summary>SC minimum reconnect time (4194327)</summary>
    ScMinimumReconnectTime = 4194327,
    
    /// <summary>Color override (4194328)</summary>
    ColorOverride = 4194328,
    
    /// <summary>Color reference (4194329)</summary>
    ColorReference = 4194329,
    
    /// <summary>Default color (4194330)</summary>
    DefaultColor = 4194330,
    
    /// <summary>Default color temperature (4194331)</summary>
    DefaultColorTemperature = 4194331,
    
    /// <summary>Override color reference (4194332)</summary>
    OverrideColorReference = 4194332,
    
    /// <summary>Write every scheduled action (4194333)</summary>
    WriteEveryScheduledAction = 4194333,
    
    /// <summary>Color command (4194334)</summary>
    ColorCommand = 4194334,
    
    /// <summary>High end trim (4194335)</summary>
    HighEndTrim = 4194335,
    
    /// <summary>Low end trim (4194336)</summary>
    LowEndTrim = 4194336,
    
    /// <summary>Trim fade time (4194337)</summary>
    TrimFadeTime = 4194337,
    
    /// <summary>Device address proxy enable (4194338)</summary>
    DeviceAddressProxyEnable = 4194338,
    
    /// <summary>Device address proxy table (4194339)</summary>
    DeviceAddressProxyTable = 4194339,
    
    /// <summary>Device address proxy timeout (4194340)</summary>
    DeviceAddressProxyTimeout = 4194340,
    
    /// <summary>Default on value (4194341)</summary>
    DefaultOnValue = 4194341,
    
    /// <summary>Last on value (4194342)</summary>
    LastOnValue = 4194342,
    
    /// <summary>Authorization cache (4194343)</summary>
    AuthorizationCache = 4194343,
    
    /// <summary>Authorization groups (4194344)</summary>
    AuthorizationGroups = 4194344,
    
    /// <summary>Authorization policy (4194345)</summary>
    AuthorizationPolicy = 4194345,
    
    /// <summary>Authorization scope (4194346)</summary>
    AuthorizationScope = 4194346,
    
    /// <summary>Authorization server (4194347)</summary>
    AuthorizationServer = 4194347,
    
    /// <summary>Authorization status (4194348)</summary>
    AuthorizationStatus = 4194348,
    
    /// <summary>Maximum proxied I-Ams per second (4194349)</summary>
    MaxProxiedIAmsPerSecond = 4194349
}
