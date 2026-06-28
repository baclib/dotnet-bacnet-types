// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuthRequestRequest
{
    /// <summary>
    /// Represents the sequence token-request as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TTokenRequest
    {
        /// <summary>
        /// The identifier of the client requesting authentication.
        /// </summary>
        public required Unsigned32 Client { get; init; }
    
        /// <summary>
        /// A list of intended audience identifiers for the token.
        /// </summary>
        public required SequenceOf<Integer32> Audience { get; init; }
    
        /// <summary>
        /// The requested authorization scope for the token.
        /// </summary>
        public required AuthorizationScope Scope { get; init; }
    }
}
