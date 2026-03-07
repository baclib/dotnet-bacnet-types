// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAuthenticationFactorFormat as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationFactorFormat
{
    /// <summary>
    /// The type of authentication factor format.
    /// </summary>
    public required AuthenticationFactorType FormatType { get; init; }
    
    /// <summary>
    /// The vendor identifier for vendor-specific formats.
    /// </summary>
    public Unsigned16? VendorId { get; init; }

    /// <summary>
    /// The vendor-specific format identifier.
    /// </summary>
    public Unsigned16? VendorFormat { get; init; }
}
