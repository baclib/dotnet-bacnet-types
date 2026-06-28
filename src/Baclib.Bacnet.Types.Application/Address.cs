// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAddress as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Address
{
    /// <summary>
    /// The BACnet network number (0 for the local network).
    /// </summary>
    public required Unsigned16 NetworkNumber { get; init; }

    /// <summary>
    /// The MAC address on the specified network.
    /// </summary>
    public required OctetString MacAddress { get; init; }
}
