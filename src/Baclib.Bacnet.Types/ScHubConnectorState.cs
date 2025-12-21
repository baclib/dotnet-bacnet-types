// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetSCHubConnectorState as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ScHubConnectorState : byte
{
    /// <summary>
    /// No connection to any hub is established.
    /// </summary>
    NoHubConnection = 0,

    /// <summary>
    /// Connected to the primary hub.
    /// </summary>
    ConnectedToPrimary = 1,

    /// <summary>
    /// Connected to the failover hub.
    /// </summary>
    ConnectedToFailover = 2
}
