// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class GetEnrollmentSummaryRequest
{
    /// <summary>
    /// Represents the enumeration event-state-filter as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TEventStateFilter : byte
    {
        /// <summary>
        /// Include events in offnormal state.
        /// </summary>
        Offnormal = 0,
    
        /// <summary>
        /// Include events in fault state.
        /// </summary>
        Fault = 1,
    
        /// <summary>
        /// Include events in normal state.
        /// </summary>
        Normal = 2,
    
        /// <summary>
        /// Include events in all states.
        /// </summary>
        All = 3,
    
        /// <summary>
        /// Include only active events.
        /// </summary>
        Active = 4
    }
}
