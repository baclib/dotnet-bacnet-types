// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetNetworkPortCommand as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum NetworkPortCommand : byte
{
    /// <summary>
    /// Idle command.
    /// </summary>
    Idle = 0,

    /// <summary>
    /// Discard changes command.
    /// </summary>
    DiscardChanges = 1,

    /// <summary>
    /// Renew FD registration command.
    /// </summary>
    RenewFdRegistration = 2,

    /// <summary>
    /// Restart subordinate discovery command.
    /// </summary>
    RestartSubordinateDiscovery = 3,

    /// <summary>
    /// Renew DHCP command.
    /// </summary>
    RenewDhcp = 4,

    /// <summary>
    /// Restart autonegotiation command.
    /// </summary>
    RestartAutonegotiation = 5,

    /// <summary>
    /// Disconnect command.
    /// </summary>
    Disconnect = 6,

    /// <summary>
    /// Restart port command.
    /// </summary>
    RestartPort = 7,

    /// <summary>
    /// Restart device discovery command.
    /// </summary>
    RestartDeviceDiscovery = 8,

    /// <summary>
    /// Generate CSR file command.
    /// </summary>
    GenerateCsrFile = 9,

    /// <summary>
    /// Validate changes command.
    /// </summary>
    ValidateChanges = 10
}
