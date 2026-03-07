// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ChangeList-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ChangeListError
{
    /// <summary>
    /// The error that occurred during the change list operation.
    /// </summary>
    public required Error ErrorType { get; init; }
    
    /// <summary>
    /// The index of the first element in the change list that failed.
    /// </summary>
    public required Unsigned FirstFailedElementNumber { get; init; }
    }
