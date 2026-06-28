// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetSCHubConnection as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ScHubConnection
{
    /// <summary>
    /// The current state of the SC hub connection.
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
    /// Error code if the connection failed. Optional.
    /// </summary>
    public Optional<Error> Error { get; init; }

    /// <summary>
    /// Additional error details if available. Optional.
    /// </summary>
    public Optional<CharacterString> ErrorDetails { get; init; }
}
