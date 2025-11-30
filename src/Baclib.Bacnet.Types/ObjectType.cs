// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents BACnet object types as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// Object type values are 10-bit unsigned integers (0-1023).
/// Values 0-127 are defined by ASHRAE, 128-1023 are vendor-specific.
/// </remarks>
public enum ObjectType : ushort
{
    /// <summary>Analog Input object (0)</summary>
    AnalogInput = 0,

    /// <summary>Analog Output object (1)</summary>
    AnalogOutput = 1,

    /// <summary>Analog Value object (2)</summary>
    AnalogValue = 2,

    /// <summary>Binary Input object (3)</summary>
    BinaryInput = 3,

    /// <summary>Binary Output object (4)</summary>
    BinaryOutput = 4,

    /// <summary>Binary Value object (5)</summary>
    BinaryValue = 5,

    /// <summary>Calendar object (6)</summary>
    Calendar = 6,

    /// <summary>Command object (7)</summary>
    Command = 7,

    /// <summary>Device object (8)</summary>
    Device = 8,

    /// <summary>Event Enrollment object (9)</summary>
    EventEnrollment = 9,

    /// <summary>File object (10)</summary>
    File = 10,

    /// <summary>Group object (11)</summary>
    Group = 11,

    /// <summary>Loop object (12)</summary>
    Loop = 12,

    /// <summary>Multi-State Input object (13)</summary>
    MultiStateInput = 13,

    /// <summary>Multi-State Output object (14)</summary>
    MultiStateOutput = 14,

    /// <summary>Notification Class object (15)</summary>
    NotificationClass = 15,

    /// <summary>Program object (16)</summary>
    Program = 16,

    /// <summary>Schedule object (17)</summary>
    Schedule = 17,

    /// <summary>Averaging object (18)</summary>
    Averaging = 18,

    /// <summary>Multi-State Value object (19)</summary>
    MultiStateValue = 19,

    /// <summary>Trend Log object (20)</summary>
    TrendLog = 20,

    /// <summary>Life Safety Point object (21)</summary>
    LifeSafetyPoint = 21,

    /// <summary>Life Safety Zone object (22)</summary>
    LifeSafetyZone = 22,

    /// <summary>Accumulator object (23)</summary>
    Accumulator = 23,

    /// <summary>Pulse Converter object (24)</summary>
    PulseConverter = 24,

    /// <summary>Event Log object (25)</summary>
    EventLog = 25,

    /// <summary>Global Group object (26)</summary>
    GlobalGroup = 26,

    /// <summary>Trend Log Multiple object (27)</summary>
    TrendLogMultiple = 27,

    /// <summary>Load Control object (28)</summary>
    LoadControl = 28,

    /// <summary>Structured View object (29)</summary>
    StructuredView = 29,

    /// <summary>Access Door object (30)</summary>
    AccessDoor = 30,

    /// <summary>Timer object (31)</summary>
    Timer = 31,

    /// <summary>Access Credential object (32)</summary>
    AccessCredential = 32,

    /// <summary>Access Point object (33)</summary>
    AccessPoint = 33,

    /// <summary>Access Rights object (34)</summary>
    AccessRights = 34,

    /// <summary>Access User object (35)</summary>
    AccessUser = 35,

    /// <summary>Access Zone object (36)</summary>
    AccessZone = 36,

    /// <summary>Credential Data Input object (37)</summary>
    CredentialDataInput = 37,

    /// <summary>Network Security object (38)</summary>
    NetworkSecurity = 38,

    /// <summary>BitString Value object (39)</summary>
    BitstringValue = 39,

    /// <summary>CharacterString Value object (40)</summary>
    CharacterstringValue = 40,

    /// <summary>Date Pattern Value object (41)</summary>
    DatePatternValue = 41,

    /// <summary>Date Value object (42)</summary>
    DateValue = 42,

    /// <summary>DateTime Pattern Value object (43)</summary>
    DatetimePatternValue = 43,

    /// <summary>DateTime Value object (44)</summary>
    DatetimeValue = 44,

    /// <summary>Integer Value object (45)</summary>
    IntegerValue = 45,

    /// <summary>Large Analog Value object (46)</summary>
    LargeAnalogValue = 46,

    /// <summary>OctetString Value object (47)</summary>
    OctetstringValue = 47,

    /// <summary>Positive Integer Value object (48)</summary>
    PositiveIntegerValue = 48,

    /// <summary>Time Pattern Value object (49)</summary>
    TimePatternValue = 49,

    /// <summary>Time Value object (50)</summary>
    TimeValue = 50,

    /// <summary>Notification Forwarder object (51)</summary>
    NotificationForwarder = 51,

    /// <summary>Alert Enrollment object (52)</summary>
    AlertEnrollment = 52,

    /// <summary>Channel object (53)</summary>
    Channel = 53,

    /// <summary>Lighting Output object (54)</summary>
    LightingOutput = 54,

    /// <summary>Binary Lighting Output object (55)</summary>
    BinaryLightingOutput = 55,

    /// <summary>Network Port object (56)</summary>
    NetworkPort = 56,

    /// <summary>Elevator Group object (57)</summary>
    ElevatorGroup = 57,

    /// <summary>Escalator object (58)</summary>
    Escalator = 58,

    /// <summary>Lift object (59)</summary>
    Lift = 59,

    /// <summary>Staging object (60)</summary>
    Staging = 60,

    /// <summary>Audit Log object (61)</summary>
    AuditLog = 61,

    /// <summary>Audit Reporter object (62)</summary>
    AuditReporter = 62,

    /// <summary>Color object (63)</summary>
    Color = 63,

    /// <summary>Color Temperature object (64)</summary>
    ColorTemperature = 64
}
