// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetBinaryPV as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum BinaryPv : byte
{
    /// <summary>
    /// The value is INACTIVE.
    /// </summary>
    Inactive = 0,

    /// <summary>
    /// The value is ACTIVE.
    /// </summary>
    Active = 1
}
