// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetPolarity as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public enum Polarity : byte
{
    /// <summary>
    /// Normal polarity.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Reverse polarity.
    /// </summary>
    Reverse = 1
}
