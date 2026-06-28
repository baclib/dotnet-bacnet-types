// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence AuditLogQuery-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuditLogQueryAck
{
    /// <summary>
    /// The object identifier of the audit log being queried.
    /// </summary>
    public required ObjectIdentifier AuditLog { get; init; }

    /// <summary>
    /// A list of audit log records that match the query criteria.
    /// </summary>
    public required SequenceOf<AuditLogRecordResult> Records { get; init; }

    /// <summary>
    /// Indicates whether there are no more records available beyond those returned.
    /// </summary>
    public required Boolean NoMoreItems { get; init; }
}
