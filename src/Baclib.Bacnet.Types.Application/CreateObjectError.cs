// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence CreateObject-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CreateObjectError
{
    /// <summary>
    /// The error class and code describing the failure.
    /// </summary>
    public required Error ErrorType { get; init; }

    /// <summary>
    /// The index of the first property value in the list-of-initial-values that caused an error.
    /// </summary>
    public required Unsigned FirstFailedElementNumber { get; init; }
}
