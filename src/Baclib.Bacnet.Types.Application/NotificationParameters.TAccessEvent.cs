// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence access-event as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TAccessEvent
    {
        /// <summary>
        /// The type of access event that occurred.
        /// </summary>
        public required AccessEvent AccessEvent { get; init; }
    
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
    
        /// <summary>
        /// A unique tag identifying this access event instance.
        /// </summary>
        public required Unsigned AccessEventTag { get; init; }
    
        /// <summary>
        /// The timestamp when the access event occurred.
        /// </summary>
        public required TimeStamp AccessEventTime { get; init; }
    
        /// <summary>
        /// Reference to the access credential used in the event.
        /// </summary>
        public required DeviceObjectReference AccessCredential { get; init; }
    
        /// <summary>
        /// Optional authentication factor information associated with the access event.
        /// </summary>
        public Optional<AuthenticationFactor> AuthenticationFactor { get; init; }
    }
}
