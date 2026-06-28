// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence change-of-life-safety as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfLifeSafety
    {
        /// <summary>
        /// The new life safety state.
        /// </summary>
        public required LifeSafetyState NewState { get; init; }
    
        /// <summary>
        /// The new life safety mode.
        /// </summary>
        public required LifeSafetyMode NewMode { get; init; }
    
        /// <summary>
        /// The status flags indicating the state of the object at the time of notification.
        /// </summary>
        public required StatusFlags StatusFlags { get; init; }
    
        /// <summary>
        /// The life safety operation expected to be performed.
        /// </summary>
        public required LifeSafetyOperation OperationExpected { get; init; }
    }
}
