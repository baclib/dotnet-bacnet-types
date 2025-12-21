// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetNodeType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum NodeType : byte
{
    /// <summary>
    /// Node type is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// System node type.
    /// </summary>
    System = 1,

    /// <summary>
    /// Network node type.
    /// </summary>
    Network = 2,

    /// <summary>
    /// Device node type.
    /// </summary>
    Device = 3,

    /// <summary>
    /// Organizational node type.
    /// </summary>
    Organizational = 4,

    /// <summary>
    /// Area node type.
    /// </summary>
    Area = 5,

    /// <summary>
    /// Equipment node type.
    /// </summary>
    Equipment = 6,

    /// <summary>
    /// Point node type.
    /// </summary>
    Point = 7,

    /// <summary>
    /// Collection node type.
    /// </summary>
    Collection = 8,

    /// <summary>
    /// Property node type.
    /// </summary>
    Property = 9,

    /// <summary>
    /// Functional node type.
    /// </summary>
    Functional = 10,

    /// <summary>
    /// Other node type.
    /// </summary>
    Other = 11,

    /// <summary>
    /// Subsystem node type.
    /// </summary>
    Subsystem = 12,

    /// <summary>
    /// Building node type.
    /// </summary>
    Building = 13,

    /// <summary>
    /// Floor node type.
    /// </summary>
    Floor = 14,

    /// <summary>
    /// Section node type.
    /// </summary>
    Section = 15,

    /// <summary>
    /// Module node type.
    /// </summary>
    Module = 16,

    /// <summary>
    /// Tree node type.
    /// </summary>
    Tree = 17,

    /// <summary>
    /// Member node type.
    /// </summary>
    Member = 18,

    /// <summary>
    /// Protocol node type.
    /// </summary>
    Protocol = 19,

    /// <summary>
    /// Room node type.
    /// </summary>
    Room = 20,

    /// <summary>
    /// Zone node type.
    /// </summary>
    Zone = 21
}
