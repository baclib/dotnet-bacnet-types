// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the enumeration BACnetLoggingType as defined in ANSI/ASHRAE 135-2024 Clause 21.
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
