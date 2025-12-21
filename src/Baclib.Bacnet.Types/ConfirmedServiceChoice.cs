// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetConfirmedServiceChoice as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ConfirmedServiceChoice : byte
{
    /// <summary>
    /// Acknowledge alarm service.
    /// </summary>
    AcknowledgeAlarm = 0,

    /// <summary>
    /// Confirmed COV notification service.
    /// </summary>
    ConfirmedCovNotification = 1,

    /// <summary>
    /// Confirmed event notification service.
    /// </summary>
    ConfirmedEventNotification = 2,

    /// <summary>
    /// Get alarm summary service.
    /// </summary>
    GetAlarmSummary = 3,

    /// <summary>
    /// Get enrollment summary service.
    /// </summary>
    GetEnrollmentSummary = 4,

    /// <summary>
    /// Subscribe COV service.
    /// </summary>
    SubscribeCov = 5,

    /// <summary>
    /// Atomic read file service.
    /// </summary>
    AtomicReadFile = 6,

    /// <summary>
    /// Atomic write file service.
    /// </summary>
    AtomicWriteFile = 7,

    /// <summary>
    /// Add list element service.
    /// </summary>
    AddListElement = 8,

    /// <summary>
    /// Remove list element service.
    /// </summary>
    RemoveListElement = 9,

    /// <summary>
    /// Create object service.
    /// </summary>
    CreateObject = 10,

    /// <summary>
    /// Delete object service.
    /// </summary>
    DeleteObject = 11,

    /// <summary>
    /// Read property service.
    /// </summary>
    ReadProperty = 12,

    /// <summary>
    /// Read property multiple service.
    /// </summary>
    ReadPropertyMultiple = 14,

    /// <summary>
    /// Write property service.
    /// </summary>
    WriteProperty = 15,

    /// <summary>
    /// Write property multiple service.
    /// </summary>
    WritePropertyMultiple = 16,

    /// <summary>
    /// Device communication control service.
    /// </summary>
    DeviceCommunicationControl = 17,

    /// <summary>
    /// Confirmed private transfer service.
    /// </summary>
    ConfirmedPrivateTransfer = 18,

    /// <summary>
    /// Confirmed text message service.
    /// </summary>
    ConfirmedTextMessage = 19,

    /// <summary>
    /// Reinitialize device service.
    /// </summary>
    ReinitializeDevice = 20,

    /// <summary>
    /// VT open service.
    /// </summary>
    VtOpen = 21,

    /// <summary>
    /// VT close service.
    /// </summary>
    VtClose = 22,

    /// <summary>
    /// VT data service.
    /// </summary>
    VtData = 23,

    /// <summary>
    /// Read range service.
    /// </summary>
    ReadRange = 26,

    /// <summary>
    /// Life safety operation service.
    /// </summary>
    LifeSafetyOperation = 27,

    /// <summary>
    /// Subscribe COV property service.
    /// </summary>
    SubscribeCovProperty = 28,

    /// <summary>
    /// Get event information service.
    /// </summary>
    GetEventInformation = 29,

    /// <summary>
    /// Subscribe COV property multiple service.
    /// </summary>
    SubscribeCovPropertyMultiple = 30,

    /// <summary>
    /// Confirmed COV notification multiple service.
    /// </summary>
    ConfirmedCovNotificationMultiple = 31,

    /// <summary>
    /// Confirmed audit notification service.
    /// </summary>
    ConfirmedAuditNotification = 32,

    /// <summary>
    /// Audit log query service.
    /// </summary>
    AuditLogQuery = 33,

    /// <summary>
    /// Authentication request service.
    /// </summary>
    AuthRequest = 34
}
