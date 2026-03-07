// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence change-of-status-flags as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfStatusFlags
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
        
        /// <summary>
        /// The status flags to monitor for changes.
        /// </summary>
        public required StatusFlags SelectedFlags { get; init; }
        }
}
