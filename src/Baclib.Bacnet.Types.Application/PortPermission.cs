// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetPortPermission as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class PortPermission
{
    /// <summary>
    /// The identifier of the port.
    /// </summary>
    public required Unsigned8 PortId { get; init; }

    /// <summary>
    /// Indicates if the port is enabled.
    /// </summary>
    public required Boolean Enabled { get; init; }
}
