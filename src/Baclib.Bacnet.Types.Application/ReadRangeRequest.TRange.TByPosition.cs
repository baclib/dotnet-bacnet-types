// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class ReadRangeRequest
{
    public partial record class TRange
    {
        /// <summary>
        /// Represents the sequence by-position as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TByPosition
        {
            /// <summary>
            /// Reference index for the range.
            /// </summary>
            public required Unsigned ReferenceIndex { get; init; }
        
            /// <summary>
            /// Number of items to read from the reference index.
            /// </summary>
            public required Integer16 Count { get; init; }
        }
    }
}
