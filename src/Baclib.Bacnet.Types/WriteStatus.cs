// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetWriteStatus as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum WriteStatus : byte
{
    /// <summary>
    /// No write operation is currently active.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// A write operation is currently in progress.
    /// </summary>
    InProgress = 1,

    /// <summary>
    /// The write operation completed successfully.
    /// </summary>
    Successful = 2,

    /// <summary>
    /// The write operation failed.
    /// </summary>
    Failed = 3
}
