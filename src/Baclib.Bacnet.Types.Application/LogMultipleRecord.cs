// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetLogMultipleRecord as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LogMultipleRecord
{
    /// <summary>
    /// The date and time when the log entry was recorded.
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// The log data, which can be a status indicator, a series of values, or a time change notification.
    /// </summary>
    public required LogData LogData { get; init; }
}
