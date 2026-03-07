// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class RouterEntry
{
    /// <summary>
    /// Represents the enumeration status as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TStatus : byte
    {
        /// <summary>
        /// Router is available.
        /// </summary>
        Available = 0,
    
        /// <summary>
        /// Router is busy.
        /// </summary>
        Busy = 1,
    
        /// <summary>
        /// Router is disconnected.
        /// </summary>
        Disconnected = 2
    }
}
