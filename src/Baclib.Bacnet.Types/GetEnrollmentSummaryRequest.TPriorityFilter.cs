// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class GetEnrollmentSummaryRequest
{
    /// <summary>
    /// Represents the sequence priority-filter as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TPriorityFilter
    {
        /// <summary>
        /// Minimum priority value for the filter range.
        /// </summary>
        public required Unsigned8 MinPriority { get; init; }
        
        /// <summary>
        /// Maximum priority value for the filter range.
        /// </summary>
        public required Unsigned8 MaxPriority { get; init; }
        }
}
