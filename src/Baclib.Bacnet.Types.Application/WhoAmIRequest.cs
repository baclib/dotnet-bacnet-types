// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence Who-Am-I-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WhoAmIRequest
{
    /// <summary>
    /// The vendor identifier of the device.
    /// </summary>
    public required Unsigned16 VendorId { get; init; }

    /// <summary>
    /// The model name of the device.
    /// </summary>
    public required CharacterString ModelName { get; init; }

    /// <summary>
    /// The serial number of the device.
    /// </summary>
    public required CharacterString SerialNumber { get; init; }
}
