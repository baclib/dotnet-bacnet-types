// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetAccessToken as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AccessToken
{
    /// <summary>
    /// The identifier of the token issuer.
    /// </summary>
    public required Unsigned32 Issuer { get; init; }
    
    /// <summary>
    /// The date and time the token was issued.
    /// </summary>
    public required DateTime Issued { get; init; }
    
    /// <summary>
    /// A list of audience identifiers for which the token is valid.
    /// </summary>
    public required TAudience Audience { get; init; }
    
    /// <summary>
    /// The token is not valid before this date and time.
    /// </summary>
    public Optional<DateTime> NotBefore { get; init; }

    /// <summary>
    /// The token is not valid after this date and time.
    /// </summary>
    public Optional<DateTime> NotAfter { get; init; }

    /// <summary>
    /// The identifier of the client to which the token applies.
    /// </summary>
    public required Unsigned32 Client { get; init; }
    
    /// <summary>
    /// Constraints on origin and authentication requirements for using the token.
    /// </summary>
    public required AuthorizationConstraint Constraint { get; init; }
    
    /// <summary>
    /// The authorization scope granted by the token.
    /// </summary>
    public required AuthorizationScope Scope { get; init; }
    
    /// <summary>
    /// Identifier of the signing key used to create the token.
    /// </summary>
    public required Unsigned8 KeyId { get; init; }
    
    /// <summary>
    /// The cryptographic signature of the token.
    /// </summary>
    public required OctetString Signature { get; init; }
    }
