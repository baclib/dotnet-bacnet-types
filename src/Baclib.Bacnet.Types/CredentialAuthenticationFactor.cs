// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetCredentialAuthenticationFactor as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class CredentialAuthenticationFactor
{
    /// <summary>
    /// Indicates whether this authentication factor is disabled.
    /// </summary>
    public required AccessAuthenticationFactorDisable Disable { get; init; }
    
    /// <summary>
    /// The authentication factor details.
    /// </summary>
    public required AuthenticationFactor AuthenticationFactor { get; init; }
    }
