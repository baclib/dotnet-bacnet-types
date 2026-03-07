// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence AuditLogQuery-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuditLogQueryRequest
{
    /// <summary>
    /// The object identifier of the audit log to query.
    /// </summary>
    public required ObjectIdentifier AuditLog { get; init; }
    
    /// <summary>
    /// The parameters defining which records to retrieve.
    /// </summary>
    public required AuditLogQueryParameters QueryParameters { get; init; }
    
    /// <summary>
    /// The sequence number at which to start retrieving records.
    /// </summary>
    public Unsigned64? StartAtSequenceNumber { get; init; }

    /// <summary>
    /// The maximum number of records to return.
    /// </summary>
    public required Unsigned16 RequestedCount { get; init; }
    }
