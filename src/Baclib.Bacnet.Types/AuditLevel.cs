// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuditLevel as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum AuditLevel : byte
{
    /// <summary>
    /// No auditing.
    /// </summary>
    None = 0,

    /// <summary>
    /// Audit all actions.
    /// </summary>
    AuditAll = 1,

    /// <summary>
    /// Audit configuration changes.
    /// </summary>
    AuditConfig = 2,

    /// <summary>
    /// Default audit level.
    /// </summary>
    Default = 3
}
