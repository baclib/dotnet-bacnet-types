// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence out-of-range as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TOutOfRange
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
        
        /// <summary>
        /// The low limit threshold value.
        /// </summary>
        public required float LowLimit { get; init; }
        
        /// <summary>
        /// The high limit threshold value.
        /// </summary>
        public required float HighLimit { get; init; }
        
        /// <summary>
        /// The deadband value to prevent rapid toggling of the event state.
        /// </summary>
        public required float Deadband { get; init; }
        }
}
