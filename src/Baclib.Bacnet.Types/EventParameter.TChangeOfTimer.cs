// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence change-of-timer as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfTimer
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
        
        /// <summary>
        /// A list of timer state values that trigger the event when matched.
        /// </summary>
        public required TAlarmValues AlarmValues { get; init; }
        
        /// <summary>
        /// Reference to the property containing the timer update time.
        /// </summary>
        public required DeviceObjectPropertyReference UpdateTimeReference { get; init; }
        }
}
