// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class AccessRule
{
    /// <summary>
    /// Represents the enumeration time-range-specifier as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TTimeRangeSpecifier : byte
    {
        /// <summary>
        /// Use the specified time range reference.
        /// </summary>
        Specified = 0,
    
        /// <summary>
        /// Always valid; no time range restriction.
        /// </summary>
        Always = 1
    }
}
