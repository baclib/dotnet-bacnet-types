// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAddressBinding as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AddressBinding
{
    /// <summary>
    /// The object identifier of the device.
    /// </summary>
    public required ObjectIdentifier DeviceIdentifier { get; init; }
    
    /// <summary>
    /// The network address of the device.
    /// </summary>
    public required Address DeviceAddress { get; init; }
    }
