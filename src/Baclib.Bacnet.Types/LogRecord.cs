// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetLogRecord as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LogRecord
{
    /// <summary>
    /// The date and time when the log entry was recorded.
    /// </summary>
    public required DateTime Timestamp { get; init; }
    
    /// <summary>
    /// The actual data recorded in this log entry, which can be of various types.
    /// </summary>
    public required TLogDatum LogDatum { get; init; }
    
    /// <summary>
    /// Optional status flags indicating the state of the logged object at the time of recording.
    /// </summary>
    public StatusFlags? StatusFlags { get; init; }
}
