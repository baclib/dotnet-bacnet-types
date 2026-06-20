// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-characterstring as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultCharacterstring
    {
        /// <summary>
        /// A list of character string values that indicate a fault condition.
        /// </summary>
        public required TListOfFaultValues ListOfFaultValues { get; init; }
        }
}
