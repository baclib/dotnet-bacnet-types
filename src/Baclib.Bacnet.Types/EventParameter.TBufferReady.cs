// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence buffer-ready as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TBufferReady
    {
        /// <summary>
        /// The number of log records required to trigger a notification.
        /// </summary>
        public required Unsigned NotificationThreshold { get; init; }
        
        /// <summary>
        /// The count from the previous notification for detecting unconfirmed buffers.
        /// </summary>
        public required Unsigned32 PreviousNotificationCount { get; init; }
        }
}
