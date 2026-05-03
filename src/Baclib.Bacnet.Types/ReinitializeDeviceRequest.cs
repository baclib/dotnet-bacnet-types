// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ReinitializeDevice-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ReinitializeDeviceRequest
{
    /// <summary>
    /// The state to which the device should be reinitialized.
    /// </summary>
    public required TReinitializedStateOfDevice ReinitializedStateOfDevice { get; init; }
    
    /// <summary>
    /// Optional password required for reinitialization.
    /// </summary>
    public Optional<TPassword> Password { get; init; }
}
