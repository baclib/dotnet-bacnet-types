// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence You-Are-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class YouAreRequest
{
    /// <summary>
    /// The vendor identifier of the device.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }
    
    /// <summary>
    /// The model name of the device.
    /// </summary>
    public required CharacterString ModelName { get; init; }
    
    /// <summary>
    /// The serial number of the device.
    /// </summary>
    public required CharacterString SerialNumber { get; init; }
    
    /// <summary>
    /// The BACnet device identifier. Optional.
    /// </summary>
    public Optional<ObjectIdentifier> DeviceIdentifier { get; init; }

    /// <summary>
    /// The MAC address of the device. Optional.
    /// </summary>
    public Optional<OctetString> DeviceMacAddress { get; init; }
}
