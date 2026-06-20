// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence buffer-ready as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TBufferReady
    {
        /// <summary>
        /// Reference to the buffer property that is ready.
        /// </summary>
        public required DeviceObjectPropertyReference BufferProperty { get; init; }
        
        /// <summary>
        /// The record number of the previous buffer-ready notification.
        /// </summary>
        public required Unsigned32 PreviousNotification { get; init; }
        
        /// <summary>
        /// The record number of the current buffer-ready notification.
        /// </summary>
        public required Unsigned32 CurrentNotification { get; init; }
        }
}
