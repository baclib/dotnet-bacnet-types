// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthenticationDecision as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthenticationDecision : byte
{
    /// <summary>
    /// Authentication allowed due to a match.
    /// </summary>
    AllowMatch = 0,

    /// <summary>
    /// Authentication denied due to mismatch.
    /// </summary>
    DenyMismatch = 1,

    /// <summary>
    /// Authentication denied due to non-relay.
    /// </summary>
    DenyNonRelay = 2
}
