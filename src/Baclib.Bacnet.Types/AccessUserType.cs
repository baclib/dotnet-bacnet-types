// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAccessUserType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AccessUserType : ushort
{
    /// <summary>
    /// User type is an asset.
    /// </summary>
    Asset = 0,

    /// <summary>
    /// User type is a group.
    /// </summary>
    Group = 1,

    /// <summary>
    /// User type is a person.
    /// </summary>
    Person = 2
}
