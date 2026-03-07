// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ReadRangeRequest
{
    public partial record class TRange
    {
        /// <summary>
        /// Represents the sequence by-sequence-number as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TBySequenceNumber
        {
            /// <summary>
            /// Reference sequence number for the range.
            /// </summary>
            public required Unsigned ReferenceSequenceNumber { get; init; }
            
            /// <summary>
            /// Number of items to read from the reference sequence number.
            /// </summary>
            public required Integer16 Count { get; init; }
            }
    }
}
