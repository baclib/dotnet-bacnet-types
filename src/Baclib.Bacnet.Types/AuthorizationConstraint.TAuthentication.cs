// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuthorizationConstraint
{
    /// <summary>
    /// Represents the enumeration authentication as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TAuthentication : byte
    {
        /// <summary>
        /// Client must be authenticated using a certified method.
        /// </summary>
        Certified = 0,
    
        /// <summary>
        /// Client must be authenticated over a secure communication path.
        /// </summary>
        SecurePath = 1,
    
        /// <summary>
        /// Client can use any authentication method.
        /// </summary>
        AnyMethod = 2
    }
}
