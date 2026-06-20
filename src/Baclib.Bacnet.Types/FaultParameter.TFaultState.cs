// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-state as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultState
    {
        /// <summary>
        /// A list of property states that indicate a fault condition.
        /// </summary>
        public required TListOfFaultValues ListOfFaultValues { get; init; }
        }
}
