// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetLoggingType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum LoggingType : byte
{
    /// <summary>
    /// Polled logging type.
    /// </summary>
    Polled = 0,

    /// <summary>
    /// Change of value (COV) logging type.
    /// </summary>
    Cov = 1,

    /// <summary>
    /// Triggered logging type.
    /// </summary>
    Triggered = 2
}
