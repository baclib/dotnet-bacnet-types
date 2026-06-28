// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetVMACEntry as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VmacEntry
{
    /// <summary>
    /// The virtual MAC address used in BACnet networks.
    /// </summary>
    public required OctetString VirtualMacAddress { get; init; }

    /// <summary>
    /// The native (physical) MAC address corresponding to the virtual MAC address.
    /// </summary>
    public required OctetString NativeMacAddress { get; init; }
}
