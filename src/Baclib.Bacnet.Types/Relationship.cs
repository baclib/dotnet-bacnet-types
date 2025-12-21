// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetRelationship as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum Relationship : ushort
{
    /// <summary>
    /// Relationship is unknown.
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// Default relationship.
    /// </summary>
    Default = 1,

    /// <summary>
    /// Contains relationship.
    /// </summary>
    Contains = 2,

    /// <summary>
    /// Contained by relationship.
    /// </summary>
    ContainedBy = 3,

    /// <summary>
    /// Uses relationship.
    /// </summary>
    Uses = 4,

    /// <summary>
    /// Used by relationship.
    /// </summary>
    UsedBy = 5,

    /// <summary>
    /// Commands relationship.
    /// </summary>
    Commands = 6,

    /// <summary>
    /// Commanded by relationship.
    /// </summary>
    CommandedBy = 7,

    /// <summary>
    /// Adjusts relationship.
    /// </summary>
    Adjusts = 8,

    /// <summary>
    /// Adjusted by relationship.
    /// </summary>
    AdjustedBy = 9,

    /// <summary>
    /// Ingress relationship.
    /// </summary>
    Ingress = 10,

    /// <summary>
    /// Egress relationship.
    /// </summary>
    Egress = 11,

    /// <summary>
    /// Supplies air relationship.
    /// </summary>
    SuppliesAir = 12,

    /// <summary>
    /// Receives air relationship.
    /// </summary>
    ReceivesAir = 13,

    /// <summary>
    /// Supplies hot air relationship.
    /// </summary>
    SuppliesHotAir = 14,

    /// <summary>
    /// Receives hot air relationship.
    /// </summary>
    ReceivesHotAir = 15,

    /// <summary>
    /// Supplies cool air relationship.
    /// </summary>
    SuppliesCoolAir = 16,

    /// <summary>
    /// Receives cool air relationship.
    /// </summary>
    ReceivesCoolAir = 17,

    /// <summary>
    /// Supplies power relationship.
    /// </summary>
    SuppliesPower = 18,

    /// <summary>
    /// Receives power relationship.
    /// </summary>
    ReceivesPower = 19,

    /// <summary>
    /// Supplies gas relationship.
    /// </summary>
    SuppliesGas = 20,

    /// <summary>
    /// Receives gas relationship.
    /// </summary>
    ReceivesGas = 21,

    /// <summary>
    /// Supplies water relationship.
    /// </summary>
    SuppliesWater = 22,

    /// <summary>
    /// Receives water relationship.
    /// </summary>
    ReceivesWater = 23,

    /// <summary>
    /// Supplies hot water relationship.
    /// </summary>
    SuppliesHotWater = 24,

    /// <summary>
    /// Receives hot water relationship.
    /// </summary>
    ReceivesHotWater = 25,

    /// <summary>
    /// Supplies cool water relationship.
    /// </summary>
    SuppliesCoolWater = 26,

    /// <summary>
    /// Receives cool water relationship.
    /// </summary>
    ReceivesCoolWater = 27,

    /// <summary>
    /// Supplies steam relationship.
    /// </summary>
    SuppliesSteam = 28,

    /// <summary>
    /// Receives steam relationship.
    /// </summary>
    ReceivesSteam = 29
}
