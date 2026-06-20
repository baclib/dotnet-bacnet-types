// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetSCConnectionState as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum ScConnectionState : byte
{
    /// <summary>
    /// The device is not currently connected.
    /// </summary>
    NotConnected = 0,

    /// <summary>
    /// The device is currently connected.
    /// </summary>
    Connected = 1,

    /// <summary>
    /// The device is disconnected due to errors.
    /// </summary>
    DisconnectedWithErrors = 2,

    /// <summary>
    /// The device failed to establish a connection.
    /// </summary>
    FailedToConnect = 3
}
