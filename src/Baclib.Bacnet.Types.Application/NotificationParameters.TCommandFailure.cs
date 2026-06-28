// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence command-failure as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TCommandFailure
    {
        /// <summary>
        /// The value of the command that was issued.
        /// </summary>
        public required Any CommandValue { get; init; }
    
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
    
        /// <summary>
        /// The actual feedback value received, indicating the command failure.
        /// </summary>
        public required Any FeedbackValue { get; init; }
    }
}
