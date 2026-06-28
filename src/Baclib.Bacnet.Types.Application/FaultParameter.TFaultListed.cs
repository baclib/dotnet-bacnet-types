// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-listed as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultListed
    {
        /// <summary>
        /// Reference to the property containing the list of fault values.
        /// </summary>
        public required DeviceObjectPropertyReference FaultListReference { get; init; }
    }
}
