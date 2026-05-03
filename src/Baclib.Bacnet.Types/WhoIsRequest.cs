// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence Who-Is-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WhoIsRequest
{
    /// <summary>
    /// Optional lower limit of the device instance range to search for.
    /// </summary>
    public Optional<TDeviceInstanceRangeLowLimit> DeviceInstanceRangeLowLimit { get; init; }

    /// <summary>
    /// Optional upper limit of the device instance range to search for.
    /// </summary>
    public Optional<TDeviceInstanceRangeHighLimit> DeviceInstanceRangeHighLimit { get; init; }
}
