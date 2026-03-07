// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class FaultParameter
{
    /// <summary>
    /// Represents the sequence fault-extended as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TFaultExtended
    {
        /// <summary>
        /// The vendor identifier for the vendor-specific fault type.
        /// </summary>
        public required Unsigned16 VendorId { get; init; }
        
        /// <summary>
        /// The vendor-specific fault type identifier.
        /// </summary>
        public required Unsigned ExtendedFaultType { get; init; }
        
        /// <summary>
        /// A series of parameters for the extended fault type, which can be of various data types.
        /// </summary>
        public required TParameters Parameters { get; init; }
        }
}
