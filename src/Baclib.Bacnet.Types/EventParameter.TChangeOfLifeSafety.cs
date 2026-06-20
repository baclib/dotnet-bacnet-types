// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence change-of-life-safety as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfLifeSafety
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
        
        /// <summary>
        /// A list of life safety state values that trigger the event when matched.
        /// </summary>
        public required TListOfLifeSafetyAlarmValues ListOfLifeSafetyAlarmValues { get; init; }
        
        /// <summary>
        /// An additional list of alarm values for event detection.
        /// </summary>
        public required TListOfAlarmValues ListOfAlarmValues { get; init; }
        
        /// <summary>
        /// Reference to the property containing the life safety mode.
        /// </summary>
        public required DeviceObjectPropertyReference ModePropertyReference { get; init; }
        }
}
