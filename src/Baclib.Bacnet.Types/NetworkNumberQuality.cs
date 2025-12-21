// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetNetworkNumberQuality as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum NetworkNumberQuality : byte
{
    /// <summary>
    /// Network number quality is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Network number is learned.
    /// </summary>
    Learned = 1,

    /// <summary>
    /// Network number is learned and configured.
    /// </summary>
    LearnedConfigured = 2,

    /// <summary>
    /// Network number is configured.
    /// </summary>
    Configured = 3
}
