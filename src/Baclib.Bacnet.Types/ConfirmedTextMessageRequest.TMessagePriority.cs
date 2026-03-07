// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ConfirmedTextMessageRequest
{
    /// <summary>
    /// Represents the enumeration message-priority as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TMessagePriority : byte
    {
        /// <summary>
        /// Normal priority message.
        /// </summary>
        Normal = 0,
    
        /// <summary>
        /// Urgent priority message.
        /// </summary>
        Urgent = 1
    }
}
