// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence change-of-bitstring as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TChangeOfBitstring
    {
        /// <summary>
        /// The minimum time in seconds that the condition must persist before triggering the event.
        /// </summary>
        public required Unsigned TimeDelay { get; init; }
    
        /// <summary>
        /// A bit mask indicating which bits in the monitored value are significant for comparison.
        /// </summary>
        public required BitString Bitmask { get; init; }
    
        /// <summary>
        /// A list of bit string values that trigger the event when matched.
        /// </summary>
        public required SequenceOf<BitString> ListOfBitstringValues { get; init; }
    }
}
