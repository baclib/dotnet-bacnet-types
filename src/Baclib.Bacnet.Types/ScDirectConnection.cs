// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetSCDirectConnection as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ScDirectConnection
{
    /// <summary>
    /// The URI of the direct connection.
    /// </summary>
    public required CharacterString Uri { get; init; }
    
    /// <summary>
    /// The current state of the direct connection.
    /// </summary>
    public required ScConnectionState ConnectionState { get; init; }
    
    /// <summary>
    /// Timestamp when the connection was established.
    /// </summary>
    public required DateTime ConnectTimestamp { get; init; }
    
    /// <summary>
    /// Timestamp when the connection was disconnected.
    /// </summary>
    public required DateTime DisconnectTimestamp { get; init; }
    
    /// <summary>
    /// Network address of the peer device. Optional.
    /// </summary>
    public HostNPort? PeerAddress { get; init; }

    /// <summary>
    /// Virtual MAC address of the peer device. Optional.
    /// </summary>
    public TPeerVmac? PeerVmac { get; init; }

    /// <summary>
    /// UUID of the peer device. Optional.
    /// </summary>
    public TPeerUuid? PeerUuid { get; init; }

    /// <summary>
    /// Error code if the connection failed. Optional.
    /// </summary>
    public Error? Error { get; init; }

    /// <summary>
    /// Additional error details if available. Optional.
    /// </summary>
    public CharacterString? ErrorDetails { get; init; }
}
