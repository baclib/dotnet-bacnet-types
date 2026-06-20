// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetSCFailedConnectionRequest as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ScFailedConnectionRequest
{
    /// <summary>
    /// Timestamp when the connection attempt failed.
    /// </summary>
    public required DateTime Timestamp { get; init; }
    
    /// <summary>
    /// Network address of the peer device.
    /// </summary>
    public required HostNPort PeerAddress { get; init; }
    
    /// <summary>
    /// Virtual MAC address of the peer device. Optional.
    /// </summary>
    public Optional<TPeerVmac> PeerVmac { get; init; }

    /// <summary>
    /// UUID of the peer device. Optional.
    /// </summary>
    public Optional<TPeerUuid> PeerUuid { get; init; }

    /// <summary>
    /// Error code for the failed connection attempt.
    /// </summary>
    public required Error Error { get; init; }
    
    /// <summary>
    /// Additional error details if available. Optional.
    /// </summary>
    public Optional<CharacterString> ErrorDetails { get; init; }
}
