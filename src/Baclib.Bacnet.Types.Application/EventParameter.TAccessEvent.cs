// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence access-event as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TAccessEvent
    {
        /// <summary>
        /// A list of access event types that trigger the event when matched.
        /// </summary>
        public required SequenceOf<AccessEvent> ListOfAccessEvents { get; init; }
    
        /// <summary>
        /// Reference to the property containing the time of the access event.
        /// </summary>
        public required DeviceObjectPropertyReference AccessEventTimeReference { get; init; }
    }
}
