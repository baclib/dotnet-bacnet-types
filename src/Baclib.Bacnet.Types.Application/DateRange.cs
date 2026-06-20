// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetDateRange as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DateRange
{
    /// <summary>
    /// The starting date of the range.
    /// </summary>
    public required Date StartDate { get; init; }
    
    /// <summary>
    /// The ending date of the range.
    /// </summary>
    public required Date EndDate { get; init; }
    }
