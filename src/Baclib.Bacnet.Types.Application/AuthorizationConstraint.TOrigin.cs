// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuthorizationConstraint
{
    /// <summary>
    /// Represents the enumeration origin as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TOrigin : byte
    {
        /// <summary>
        /// Client must be directly connected to the device.
        /// </summary>
        DirectConnect = 0,
    
        /// <summary>
        /// Client must be on the same network segment.
        /// </summary>
        SameNetwork = 1,
    
        /// <summary>
        /// Client can be on any network.
        /// </summary>
        AnyNetwork = 2
    }
}
