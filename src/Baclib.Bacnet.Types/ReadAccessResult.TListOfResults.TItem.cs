// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class ReadAccessResult
{
    public partial record class TListOfResults
    {
        /// <summary>
        /// Represents the sequence ??? as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TItem
        {
            /// <summary>
            /// The property identifier specifying the property read.
            /// </summary>
            public required PropertyIdentifier PropertyIdentifier { get; init; }
            
            /// <summary>
            /// Optional array index for the property.
            /// </summary>
            public Unsigned? PropertyArrayIndex { get; init; }
        
            /// <summary>
            /// The result of reading the property, either a value or an error.
            /// </summary>
            public required TReadResult ReadResult { get; init; }
            }
    }
}
