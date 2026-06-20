// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence change-of-timer as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfTimer
    {
        /// <summary>
        /// The new state of the timer.
        /// </summary>
        public required TimerState NewState { get; init; }
        
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
        
        /// <summary>
        /// The date and time when the timer state was updated.
        /// </summary>
        public required DateTime UpdateTime { get; init; }
        
        /// <summary>
        /// Optional information about the last state transition of the timer.
        /// </summary>
        public Optional<TimerTransition> LastStateChange { get; init; }
    
        /// <summary>
        /// Optional initial timeout value in seconds.
        /// </summary>
        public Optional<Unsigned> InitialTimeout { get; init; }
    
        /// <summary>
        /// Optional date and time when the timer will expire.
        /// </summary>
        public Optional<DateTime> ExpirationTime { get; init; }
    }
}
