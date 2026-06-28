// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAuthenticationFactor as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthenticationFactor
{
    /// <summary>
    /// The type of authentication factor format.
    /// </summary>
    public required AuthenticationFactorType FormatType { get; init; }

    /// <summary>
    /// The class or variant within the format type.
    /// </summary>
    public required Unsigned FormatClass { get; init; }

    /// <summary>
    /// The actual authentication credential value.
    /// </summary>
    public required OctetString Value { get; init; }
}
