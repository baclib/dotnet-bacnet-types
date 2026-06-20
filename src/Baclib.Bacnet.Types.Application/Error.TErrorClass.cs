// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class Error
{
    /// <summary>
    /// Represents the enumeration error-class as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TErrorClass : byte
    {
        /// <summary>
        /// Device-related error.
        /// </summary>
        Device = 0,
    
        /// <summary>
        /// Object-related error.
        /// </summary>
        Object = 1,
    
        /// <summary>
        /// Property-related error.
        /// </summary>
        Property = 2,
    
        /// <summary>
        /// Resource-related error.
        /// </summary>
        Resources = 3,
    
        /// <summary>
        /// Security-related error.
        /// </summary>
        Security = 4,
    
        /// <summary>
        /// Service-related error.
        /// </summary>
        Services = 5,
    
        /// <summary>
        /// Virtual terminal (VT) related error.
        /// </summary>
        Vt = 6,
    
        /// <summary>
        /// Communication-related error.
        /// </summary>
        Communication = 7
    }
}
