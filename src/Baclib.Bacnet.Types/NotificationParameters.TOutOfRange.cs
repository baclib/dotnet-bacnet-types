// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence out-of-range as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TOutOfRange
    {
        /// <summary>
        /// The value that exceeded the limit.
        /// </summary>
        public required float ExceedingValue { get; init; }
        
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
        
        /// <summary>
        /// The deadband value used to prevent rapid toggling of the event state.
        /// </summary>
        public required float Deadband { get; init; }
        
        /// <summary>
        /// The limit value that was exceeded.
        /// </summary>
        public required float ExceededLimit { get; init; }
        }
}
