// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAction as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum Action : byte
{
    /// <summary>
    /// Direct action.
    /// </summary>
    Direct = 0,

    /// <summary>
    /// Reverse action.
    /// </summary>
    Reverse = 1
}
