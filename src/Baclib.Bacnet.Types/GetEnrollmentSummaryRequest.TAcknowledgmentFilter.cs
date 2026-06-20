// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class GetEnrollmentSummaryRequest
{
    /// <summary>
    /// Represents the enumeration acknowledgment-filter as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TAcknowledgmentFilter : byte
    {
        /// <summary>
        /// Include all events regardless of acknowledgment status.
        /// </summary>
        All = 0,
    
        /// <summary>
        /// Include only acknowledged events.
        /// </summary>
        Acked = 1,
    
        /// <summary>
        /// Include only unacknowledged events.
        /// </summary>
        NotAcked = 2
    }
}
