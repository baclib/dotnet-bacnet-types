// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetNetworkType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum NetworkType : byte
{
    /// <summary>
    /// Ethernet network type.
    /// </summary>
    Ethernet = 0,

    /// <summary>
    /// ARCNET network type.
    /// </summary>
    Arcnet = 1,

    /// <summary>
    /// MS/TP network type.
    /// </summary>
    Mstp = 2,

    /// <summary>
    /// Point-to-point (PTP) network type.
    /// </summary>
    Ptp = 3,

    /// <summary>
    /// LonTalk network type.
    /// </summary>
    Lontalk = 4,

    /// <summary>
    /// IPv4 network type.
    /// </summary>
    Ipv4 = 5,

    /// <summary>
    /// Zigbee network type.
    /// </summary>
    Zigbee = 6,

    /// <summary>
    /// Virtual network type.
    /// </summary>
    Virtual = 7,

    /// <summary>
    /// IPv6 network type.
    /// </summary>
    Ipv6 = 9,

    /// <summary>
    /// Serial network type.
    /// </summary>
    Serial = 10,

    /// <summary>
    /// Secure Connect network type.
    /// </summary>
    SecureConnect = 11
}
