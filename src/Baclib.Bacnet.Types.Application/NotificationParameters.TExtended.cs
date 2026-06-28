// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class NotificationParameters
{
    /// <summary>
    /// Represents the sequence extended as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TExtended
    {
        /// <summary>
        /// The vendor identifier for the vendor-specific event type.
        /// </summary>
        public required Unsigned16 VendorId { get; init; }
    
        /// <summary>
        /// The vendor-specific event type identifier.
        /// </summary>
        public required Unsigned ExtendedEventType { get; init; }
    
        /// <summary>
        /// A series of parameters for the extended event, which can be of various data types.
        /// </summary>
        public required SequenceOf<TParametersItem> Parameters { get; init; }
    }
}
