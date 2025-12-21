// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuditOperation as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuditOperation : byte
{
    /// <summary>
    /// Read operation.
    /// </summary>
    Read = 0,

    /// <summary>
    /// Write operation.
    /// </summary>
    Write = 1,

    /// <summary>
    /// Create operation.
    /// </summary>
    Create = 2,

    /// <summary>
    /// Delete operation.
    /// </summary>
    Delete = 3,

    /// <summary>
    /// Life safety operation.
    /// </summary>
    LifeSafety = 4,

    /// <summary>
    /// Acknowledge alarm operation.
    /// </summary>
    AcknowledgeAlarm = 5,

    /// <summary>
    /// Device disable communication operation.
    /// </summary>
    DeviceDisableComm = 6,

    /// <summary>
    /// Device enable communication operation.
    /// </summary>
    DeviceEnableComm = 7,

    /// <summary>
    /// Device reset operation.
    /// </summary>
    DeviceReset = 8,

    /// <summary>
    /// Device backup operation.
    /// </summary>
    DeviceBackup = 9,

    /// <summary>
    /// Device restore operation.
    /// </summary>
    DeviceRestore = 10,

    /// <summary>
    /// Subscription operation.
    /// </summary>
    Subscription = 11,

    /// <summary>
    /// Notification operation.
    /// </summary>
    Notification = 12,

    /// <summary>
    /// Auditing failure operation.
    /// </summary>
    AuditingFailure = 13,

    /// <summary>
    /// Network changes operation.
    /// </summary>
    NetworkChanges = 14,

    /// <summary>
    /// General operation.
    /// </summary>
    General = 15
}
