// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-life-safety as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultLifeSafety
    {
        /// <summary>
        /// A list of life safety states that indicate a fault condition.
        /// </summary>
        public required TListOfFaultValues ListOfFaultValues { get; init; }
        
        /// <summary>
        /// Reference to the mode property that affects fault detection.
        /// </summary>
        public required DeviceObjectPropertyReference ModePropertyReference { get; init; }
        }
}
