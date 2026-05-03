// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence DeviceCommunicationControl-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeviceCommunicationControlRequest
{
    /// <summary>
    /// The duration in minutes for which the communication control should remain in effect. Optional.
    /// </summary>
    public Optional<Unsigned16> TimeDuration { get; init; }

    /// <summary>
    /// Indicates whether to enable or disable communication.
    /// </summary>
    public required TEnableDisable EnableDisable { get; init; }
    
    /// <summary>
    /// An optional password for authentication. Maximum length of 20 characters.
    /// </summary>
    public Optional<TPassword> Password { get; init; }
}
