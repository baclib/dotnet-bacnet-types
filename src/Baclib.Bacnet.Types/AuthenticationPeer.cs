// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuthenticationPeer as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationPeer
{
    /// <summary>
    /// The network host address and port of the peer device.
    /// </summary>
    public required HostNPort Host { get; init; }
    
    /// <summary>
    /// The device identifier of the peer.
    /// </summary>
    public required Unsigned32 Device { get; init; }
    
    /// <summary>
    /// Indicates whether the peer is authentication-aware.
    /// </summary>
    public required Boolean AuthAware { get; init; }
    
    /// <summary>
    /// Indicates whether the peer functions as a router.
    /// </summary>
    public required Boolean Router { get; init; }
    
    /// <summary>
    /// Indicates whether the peer functions as a hub.
    /// </summary>
    public required Boolean Hub { get; init; }
    }
