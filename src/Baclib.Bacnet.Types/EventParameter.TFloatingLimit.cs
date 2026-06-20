// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence floating-limit as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFloatingLimit
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
        
        /// <summary>
        /// Reference to the property containing the setpoint value.
        /// </summary>
        public required DeviceObjectPropertyReference SetpointReference { get; init; }
        
        /// <summary>
        /// The maximum allowed negative deviation from the setpoint.
        /// </summary>
        public required float LowDiffLimit { get; init; }
        
        /// <summary>
        /// The maximum allowed positive deviation from the setpoint.
        /// </summary>
        public required float HighDiffLimit { get; init; }
        
        /// <summary>
        /// The deadband value to prevent rapid toggling of the event state.
        /// </summary>
        public required float Deadband { get; init; }
        }
}
