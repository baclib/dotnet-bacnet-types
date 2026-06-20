// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class EventParameter
{
    /// <summary>
    /// Represents the sequence extended as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TExtended
    {
        /// <summary>
        /// The vendor identification code indicating the provider of the extended event type.
        /// </summary>
        public required Unsigned16 VendorId { get; init; }
        
        /// <summary>
        /// The vendor-specific event type identifier.
        /// </summary>
        public required Unsigned ExtendedEventType { get; init; }
        
        /// <summary>
        /// A list of vendor-specific parameter values for the extended event type.
        /// </summary>
        public required TParameters Parameters { get; init; }
        }
}
