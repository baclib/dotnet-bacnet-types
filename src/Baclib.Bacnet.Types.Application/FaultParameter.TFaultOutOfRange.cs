// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-out-of-range as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultOutOfRange
    {
        /// <summary>
        /// The minimum value of the normal operating range.
        /// </summary>
        public required TMinNormalValue MinNormalValue { get; init; }
    
        /// <summary>
        /// The maximum value of the normal operating range.
        /// </summary>
        public required TMaxNormalValue MaxNormalValue { get; init; }
    }
}
