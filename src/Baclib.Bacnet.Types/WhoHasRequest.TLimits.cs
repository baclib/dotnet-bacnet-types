// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class WhoHasRequest
{
    /// <summary>
    /// Represents the sequence limits as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TLimits
    {
        /// <summary>
        /// The lower limit of the device instance range.
        /// </summary>
        public required TDeviceInstanceRangeLowLimit DeviceInstanceRangeLowLimit { get; init; }
        
        /// <summary>
        /// The upper limit of the device instance range.
        /// </summary>
        public required TDeviceInstanceRangeHighLimit DeviceInstanceRangeHighLimit { get; init; }
        }
}
