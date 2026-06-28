// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence change-of-value as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfValue
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
    
        /// <summary>
        /// The criteria defining what constitutes a significant change of value.
        /// </summary>
        public required TCovCriteria CovCriteria { get; init; }
    }
}
