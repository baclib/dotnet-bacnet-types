// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence change-of-state as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfState
    {
        /// <summary>
        /// The new state value of the object.
        /// </summary>
        public required PropertyStates NewState { get; init; }
        
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
        }
}
