// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetHostNPort as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class HostNPort
{
    /// <summary>
    /// The host address, which can be an IP address, a name, or unspecified.
    /// </summary>
    public required HostAddress Host { get; init; }
    
    /// <summary>
    /// The port number for the network connection.
    /// </summary>
    public required Unsigned16 Port { get; init; }
    }
