// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetDeviceAddressProxyTableEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeviceAddressProxyTableEntry
{
    /// <summary>
    /// The network address of the BACnet device.
    /// </summary>
    public required Address Address { get; init; }
    
    /// <summary>
    /// The last I-Am message received from this device.
    /// </summary>
    public required IAmRequest IAm { get; init; }
    
    /// <summary>
    /// The date and time when the last I-Am message was received.
    /// </summary>
    public required DateTime LastIAmTime { get; init; }
    }
