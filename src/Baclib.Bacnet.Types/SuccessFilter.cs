// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetSuccessFilter as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum SuccessFilter : byte
{
    /// <summary>
    /// Include all results, both successes and failures.
    /// </summary>
    All = 0,

    /// <summary>
    /// Include only successful results.
    /// </summary>
    SuccessesOnly = 1,

    /// <summary>
    /// Include only failed results.
    /// </summary>
    FailuresOnly = 2
}
