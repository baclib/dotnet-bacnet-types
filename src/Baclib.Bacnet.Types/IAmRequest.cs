// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence I-Am-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class IAmRequest
{
    /// <summary>
    /// The object identifier of the device making the announcement.
    /// </summary>
    public required ObjectIdentifier IAmDeviceIdentifier { get; init; }
    
    /// <summary>
    /// The maximum APDU length in octets that this device can accept.
    /// </summary>
    public required Unsigned MaxApduLengthAccepted { get; init; }
    
    /// <summary>
    /// The level of segmentation support provided by this device.
    /// </summary>
    public required Segmentation SegmentationSupported { get; init; }
    
    /// <summary>
    /// The vendor identifier assigned to the manufacturer of this device.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }
    }
