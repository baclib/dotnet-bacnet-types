// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence floating-limit as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFloatingLimit
    {
        /// <summary>
        /// The current reference value being monitored.
        /// </summary>
        public required float ReferenceValue { get; init; }
        
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
        
        /// <summary>
        /// The setpoint value from which the reference value has deviated.
        /// </summary>
        public required float SetpointValue { get; init; }
        
        /// <summary>
        /// The maximum allowed deviation from the setpoint value.
        /// </summary>
        public required float ErrorLimit { get; init; }
        }
}
