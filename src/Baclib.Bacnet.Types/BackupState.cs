// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetBackupState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum BackupState : byte
{
    /// <summary>
    /// Idle state.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// Preparing for backup state.
    /// </summary>
    PreparingForBackup = 1,

    /// <summary>
    /// Preparing for restore state.
    /// </summary>
    PreparingForRestore = 2,

    /// <summary>
    /// Performing a backup state.
    /// </summary>
    PerformingABackup = 3,

    /// <summary>
    /// Performing a restore state.
    /// </summary>
    PerformingARestore = 4,

    /// <summary>
    /// Backup failure state.
    /// </summary>
    BackupFailure = 5,

    /// <summary>
    /// Restore failure state.
    /// </summary>
    RestoreFailure = 6
}
