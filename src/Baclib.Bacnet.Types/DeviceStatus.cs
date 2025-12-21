// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetDeviceStatus as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum DeviceStatus : ushort
{
    /// <summary>
    /// Device is operational.
    /// </summary>
    Operational = 0,

    /// <summary>
    /// Device is operational but read-only.
    /// </summary>
    OperationalReadOnly = 1,

    /// <summary>
    /// Device requires a download.
    /// </summary>
    DownloadRequired = 2,

    /// <summary>
    /// Download is in progress.
    /// </summary>
    DownloadInProgress = 3,

    /// <summary>
    /// Device is non-operational.
    /// </summary>
    NonOperational = 4,

    /// <summary>
    /// Backup is in progress.
    /// </summary>
    BackupInProgress = 5
}
