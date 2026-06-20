// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class ReadRangeRequest
{
    public partial record class TRange
    {
        /// <summary>
        /// Represents the sequence by-time as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TByTime
        {
            /// <summary>
            /// Reference time for the range.
            /// </summary>
            public required DateTime ReferenceTime { get; init; }
            
            /// <summary>
            /// Number of items to read from the reference time.
            /// </summary>
            public required Integer16 Count { get; init; }
            }
    }
}
