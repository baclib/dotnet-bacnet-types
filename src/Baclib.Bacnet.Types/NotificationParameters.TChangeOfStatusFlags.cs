// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence change-of-status-flags as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfStatusFlags
    {
        /// <summary>
        /// Optional present value of the object at the time the status flags changed.
        /// </summary>
        public Optional<Any> PresentValue { get; init; }
    
        /// <summary>
        /// The status flags that have changed.
        /// </summary>
        public required StatusFlags ReferencedFlags { get; init; }
        }
}
