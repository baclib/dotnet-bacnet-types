// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuditLogRecord as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuditLogRecord
{
    /// <summary>
    /// The date and time when the audit log record was created.
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// The data content of the audit log record.
    /// </summary>
    public required TLogDatum LogDatum { get; init; }
}
