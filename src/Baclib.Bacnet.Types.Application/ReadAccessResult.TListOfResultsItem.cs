// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class ReadAccessResult
{
    /// <summary>
    /// Represents the sequence list-of-results as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TListOfResultsItem
    {
        /// <summary>
        /// The property identifier specifying the property read.
        /// </summary>
        public required PropertyIdentifier PropertyIdentifier { get; init; }
    
        /// <summary>
        /// Optional array index for the property.
        /// </summary>
        public Optional<Unsigned> PropertyArrayIndex { get; init; }
    
        /// <summary>
        /// The result of reading the property, either a value or an error.
        /// </summary>
        public required TReadResult ReadResult { get; init; }
    }
}
